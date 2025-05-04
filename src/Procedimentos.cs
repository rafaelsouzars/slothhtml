using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace slothhtml.src
{
    class Procedimentos
    {       
        
        public static void Init(string projectName)
        {            

            try
            {

                string projectDirectory;

                if (projectName == null)
                {
                    projectDirectory = $"{Directory.GetCurrentDirectory()}";
                    projectName = "meu-projeto";
                }
                else
                {
                    projectDirectory = $"{Directory.GetCurrentDirectory()}\\{projectName}";
                }

                //Cria os diretorios do projeto na pasta corrente                
                Procedimentos.makeDirectorys(projectDirectory);

                //Cria os arquivos do projeto em seus respectivos diretorios                               
                Procedimentos.makeFiles(projectDirectory);

                //Prepara o arquivo para escrita
                Procedimentos.makeIndexFile(projectDirectory, projectName);

                ConsoleColor currentForengroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"O projeto \'{projectName}\' foi criado com sucesso em {projectDirectory}");

                Console.ForegroundColor = currentForengroundColor;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Seu projeto foi criado com sucesso. Mãos a obra, DEV.");
            }

            
        }

        public static async Task LibsSearch(string query)
        {
            try
            {
                //Inicia o cliente http
                using (var client = new HttpClient())
                {
                    //Configurações base do cliente
                    client.BaseAddress = new System.Uri("https://api.cdnjs.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync($"libraries?search={query}");

                    //Caso a resposta da requisição GET assíncrona retorna o código 200
                    if (response.IsSuccessStatusCode)
                    {
                        //pegando o cabeçalho
                        Console.WriteLine(response.Headers.Location);

                        //Pegando os dados da resposta e armazenando na variável 'results'
                        var results = await response.Content.ReadAsStringAsync();
                        
                        //Inicia a lista de resultados
                        ListaResultados listaResultados = new ListaResultados();

                        //Alimenta a lista de resultados com o Json
                        listaResultados = JsonSerializer.Deserialize<ListaResultados>(results);

                        //Console.WriteLine(listaResultados.results);

                        foreach (Result libs in listaResultados.results) {

                            //Seleciona apenas a biblioteca que corresponde com a consulta
                            if (libs.name == query) {
                                Console.WriteLine($"Biblioteca: {libs.name} , Versão: {libs.latest.Split("/")[6]}");
                                Console.WriteLine($"URI: {libs.latest}");
                                Console.Write("Deseja incluir no projeto? [S/N] :");
                                ConsoleKeyInfo tecla = Console.ReadKey();
                                //Console.WriteLine(tecla.Key);
                                if (tecla.Key.ToString().Equals("s") || tecla.Key.ToString().Equals("S"))
                                {
                                    Arquivos.InserirBiblioteca("index",libs.latest);
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Código de status: {response.StatusCode}");
                        Console.WriteLine(client.BaseAddress);
                    }

                }
            }
            catch (Exception e) 
            {
                errorMessage(e);
            }
            
            
                        
            
        }

        private static void errorMessage(Exception ex)
        {
            ConsoleColor currentForengroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Mensagem de Erro: {ex.Message}", Console.ForegroundColor);
            Console.ForegroundColor = currentForengroundColor;            
        }

        public static void InsertLib()
        {
            //Arquivos.InserirBiblioteca("index","lib");
        }

        private static void makeDirectorys(string directory) 
        {
            ConsoleColor currentForengroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("--Create Paths--");
            Console.WriteLine($"Create: {directory}\\vendor", Directory.CreateDirectory($"{directory}\\vendor"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\js", Directory.CreateDirectory($"{directory}\\assets\\js"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\css", Directory.CreateDirectory($"{directory}\\assets\\css"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\font", Directory.CreateDirectory($"{directory}\\assets\\font"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\scss", Directory.CreateDirectory($"{directory}\\assets\\scss"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\img", Directory.CreateDirectory($"{directory}\\assets\\img"), Console.ForegroundColor);

            Console.ForegroundColor = currentForengroundColor;
        }

        private static void makeFiles(string directory) 
        {
            ConsoleColor currentForengroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            //File.Create($"{currentDir}\\{projeto}\\index.html");
            Console.WriteLine("--Create Files--");
            Console.WriteLine($"Create: {directory}\\assets\\js\\scripts.js", File.Create($"{directory}\\assets\\js\\scripts.js"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\css\\styles.css", File.Create($"{directory}\\assets\\css\\styles.css"), Console.ForegroundColor);

            Console.ForegroundColor = currentForengroundColor;
        }

        private static void makeIndexFile(string directory, string projectName)
        {
            StreamWriter sw = new StreamWriter($"{directory}\\index.html");

            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html lang=\"pt-br\">");
            sw.WriteLine("<head>");
            sw.WriteLine("\t<meta charset=\"utf-8\">");
            sw.WriteLine("\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            sw.WriteLine("\t<meta http-equiv=\"X-UA-Compatible\" content=\"ie=edger\">");
            sw.WriteLine("\t<meta http-equiv=\"Content-type\" content=\"text/html;charset=UTF-8\">");
            sw.WriteLine("\t<link href=\"assets/css/styles.css\" rel=\"stylesheet\"type=\"text/css\">");
            sw.WriteLine($"\t<title>{projectName}</title>");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<h1>Sloth HTML v1.0.0</h1>");
            /*
             
                Desenvolver um script para iniciar projetos pré definidos como: login pages, dashboards, formulários e etc.
             
            */
            sw.WriteLine("</body>");
            sw.WriteLine("\t<script src=\"assets/js/scripts.js\"></script>");
            sw.WriteLine("</html>");

            //Fecha o arquivo
            sw.Close();

            ConsoleColor currentForengroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine($"Create: {directory}\\index.html");

            Console.ForegroundColor = currentForengroundColor;
        }


    }
}
