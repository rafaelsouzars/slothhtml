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
    public class Procedimentos
    {       
        
        public static void CreateHtmlProject(string projectName)
        {
            ConsoleColor currentForegroundColor = Console.ForegroundColor;

            try
            {
                string projectDirectory;

                if (projectName == null)
                {
                    projectDirectory = $"{Directory.GetCurrentDirectory()}";
                    projectName = "my-project";
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
                
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"O projeto \'{projectName}\' foi criado com sucesso em {projectDirectory}");

                Console.ForegroundColor = currentForegroundColor;

                Console.WriteLine("Seu projeto foi criado com sucesso. Mãos a obra, DEV.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = currentForegroundColor;
                Console.WriteLine("Exception: " + ex.Message);
            }
            
        }

        public static void CreateBrowserExtensionProject(string projectName = "my-extension") 
        {

            ConsoleColor currentForegroundColor = Console.ForegroundColor;

            try 
            {
                string projectDirectory = $"{Directory.GetCurrentDirectory()}\\{projectName}";

                Procedimentos.MakeExtensionProject(projectDirectory, projectName);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"O projeto \'{projectName}\' foi criado com sucesso em {projectDirectory}");

                Console.ForegroundColor = currentForegroundColor;

                Console.WriteLine("Seu projeto foi criado com sucesso. Mãos a obra, DEV.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = currentForegroundColor;
                Console.WriteLine("Exception: " + ex.Message);
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

        private static void MakeExtensionProject(string projectPath, string projectName) 
        {            
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("-- Create Extension Project Paths --");
            Console.WriteLine($"Create: {projectPath}\\popup", Directory.CreateDirectory($"{projectPath}\\popup"), Console.ForegroundColor);
            Console.WriteLine($"Create: {projectPath}\\assets\\js", Directory.CreateDirectory($"{projectPath}\\assets\\js"), Console.ForegroundColor);
            Console.WriteLine($"Create: {projectPath}\\assets\\css", Directory.CreateDirectory($"{projectPath}\\assets\\css"), Console.ForegroundColor);
            Console.WriteLine($"Create: {projectPath}\\assets\\font", Directory.CreateDirectory($"{projectPath}\\assets\\font"), Console.ForegroundColor);
            Console.WriteLine($"Create: {projectPath}\\assets\\scss", Directory.CreateDirectory($"{projectPath}\\assets\\scss"), Console.ForegroundColor);
            Console.WriteLine($"Create: {projectPath}\\assets\\img", Directory.CreateDirectory($"{projectPath}\\assets\\img"), Console.ForegroundColor);

            Console.WriteLine("-- Create Extension Project Files --");
            //Console.WriteLine($"Create: {projectPath}\\manifest.json", File.Create($"{projectPath}\\manifest.json"), Console.ForegroundColor);
            //Console.WriteLine($"Create: {projectPath}\\service-worker.js", File.Create($"{projectPath}\\service-worker.js"), Console.ForegroundColor);
            //Console.WriteLine($"Create: {projectPath}\\popup\\popup.html", File.Create($"{projectPath}\\popup\\popup.html"), Console.ForegroundColor);
            //Console.WriteLine($"Create: {projectPath}\\popup\\popup.js", File.Create($"{projectPath}\\popup\\popup.js"), Console.ForegroundColor);
            //Console.WriteLine($"Create: {projectPath}\\popup\\popup.css", File.Create($"{projectPath}\\popup\\popup.css"), Console.ForegroundColor);


            // Cria e escreve o código no arquivo do popup.html
            StreamWriter popupFile = new StreamWriter($"{projectPath}\\popup\\popup.html");

            popupFile.WriteLine("<!DOCTYPE html>");
            popupFile.WriteLine("<html lang=\"pt-br\">");
            popupFile.WriteLine("<head>");
            popupFile.WriteLine("\t<meta charset=\"utf-8\">");
            popupFile.WriteLine("\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            popupFile.WriteLine("\t<meta http-equiv=\"X-UA-Compatible\" content=\"ie=edger\">");
            popupFile.WriteLine("\t<meta http-equiv=\"Content-type\" content=\"text/html;charset=UTF-8\">");
            popupFile.WriteLine("\t<link href=\"popup.css\" rel=\"stylesheet\"type=\"text/css\">");
            popupFile.WriteLine($"\t<title>{projectName}</title>");
            popupFile.WriteLine("</head>");
            popupFile.WriteLine("<body>");
            popupFile.WriteLine("<h1>Sloth HTML - Browser Extension Project</h1>");

            popupFile.WriteLine("</body>");
            popupFile.WriteLine("\t<script src=\"popup.js\"></script>");
            popupFile.WriteLine("</html>");

            //Fecha o arquivo popup.html
            popupFile.Close();            
            Console.WriteLine($"Create: {projectPath}\\popup\\popup.html");

            // Cria e escreve o código no arquivo popup.css
            StreamWriter popupCssFile = new($"{projectPath}\\popup\\popup.css");

            popupCssFile.WriteLine(@"\* popup.css *\");
            popupCssFile.WriteLine("\n* {");
            popupCssFile.WriteLine("\tmargin: 0px;");
            popupCssFile.WriteLine("\tpadding: 0px;");
            popupCssFile.WriteLine("\tbox-sizing: border-box;");
            popupCssFile.WriteLine("}\n");
            popupCssFile.WriteLine("html, body {");
            popupCssFile.WriteLine("\twidth: 300px;");
            popupCssFile.WriteLine("\theight: 500px;");
            popupCssFile.WriteLine("\tbox-sizing: border-box;");
            popupCssFile.WriteLine("}");

            // Fecha o arquivo popup.css
            popupCssFile.Close();
            Console.WriteLine($"Create: {projectPath}\\popup\\popup.css");

            // Cria e escreve código no arquivo popup.js
            StreamWriter popupJsFile = new($"{projectPath}\\popup\\popup.js");

            popupJsFile.WriteLine(@"/* popup.js */");
            popupJsFile.Write("\n");
            popupJsFile.WriteLine(@"document.addEventListener('DOMContentLoaded', async () => {");
            popupJsFile.Write("\n");
            popupJsFile.WriteLine(@"})");

            // Fecha arquivo popup.js
            popupJsFile.Close();            
            Console.WriteLine($"Create: {projectPath}\\popup\\popup.js");

            // Crie e escreve o código no arquivo manifest.json
            StreamWriter manifestFile = new($"{projectPath}\\manifest.json");

            manifestFile.WriteLine("{");
            manifestFile.WriteLine("\t\"manifest_version\": 3,");
            manifestFile.WriteLine($"\t\"name\": \"{projectName}\",");
            manifestFile.WriteLine("\t\"version\": \"0.0.0\",");
            manifestFile.WriteLine("\t\"description\": \"\",");
            manifestFile.WriteLine("\t\"icons\": {},");
            manifestFile.WriteLine("\t\"action\": {");
            manifestFile.WriteLine($"\t\t\"default_title\": \"{projectName}\"");
            manifestFile.WriteLine("\t\t\"default_popup\": \"popup/popup.html\"");
            manifestFile.WriteLine("\t\t\"default_icon\": {}");
            manifestFile.WriteLine("\t},");
            manifestFile.WriteLine("\t\"background\": {");
            manifestFile.WriteLine("\t\t\"service_worker\": \"service-worker.js\"");
            manifestFile.WriteLine("\t},");
            manifestFile.WriteLine("\t\"permissions\": []");
            manifestFile.WriteLine("\t\"host_permissions\": [");
            manifestFile.WriteLine("\t\t\"http://*/*\"");
            manifestFile.WriteLine("\t\t\"https://*/*\"");
            manifestFile.WriteLine("\t]");
            manifestFile.WriteLine("}");

            // Fecha arquivo manifest.json
            manifestFile.Close();
            Console.WriteLine($"Create: {projectPath}\\manifest.json");

            // Cria e escreve o código no arquivo service-worker.js
            StreamWriter serviceWorkerFile = new($"{projectPath}\\service-worker.js");

            serviceWorkerFile.WriteLine(@"/* service-worker.js */");
            serviceWorkerFile.Write("\n");
            serviceWorkerFile.WriteLine("chrome.runtime.onInstalled.addListener(() => {");
            serviceWorkerFile.WriteLine("\tconsole.log(\'Extensão instalada. Service Worker em ação!\')");
            serviceWorkerFile.WriteLine("})");

            // Fecha arquivo service-worker.js
            serviceWorkerFile.Close();

        }

        private static void makeDirectorys(string directory) 
        {
            ConsoleColor currentForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("-- Create HTML Project Paths --");
            Console.WriteLine($"Create: {directory}\\vendor", Directory.CreateDirectory($"{directory}\\vendor"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\js", Directory.CreateDirectory($"{directory}\\assets\\js"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\css", Directory.CreateDirectory($"{directory}\\assets\\css"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\font", Directory.CreateDirectory($"{directory}\\assets\\font"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\scss", Directory.CreateDirectory($"{directory}\\assets\\scss"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\img", Directory.CreateDirectory($"{directory}\\assets\\img"), Console.ForegroundColor);

            Console.ForegroundColor = currentForegroundColor;
        }

        private static void makeFiles(string directory) 
        {
            ConsoleColor currentForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            //File.Create($"{currentDir}\\{projeto}\\index.html");
            Console.WriteLine("--Create Files--");
            Console.WriteLine($"Create: {directory}\\assets\\js\\scripts.js", File.Create($"{directory}\\assets\\js\\scripts.js"), Console.ForegroundColor);
            Console.WriteLine($"Create: {directory}\\assets\\css\\styles.css", File.Create($"{directory}\\assets\\css\\styles.css"), Console.ForegroundColor);

            Console.ForegroundColor = currentForegroundColor;
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
