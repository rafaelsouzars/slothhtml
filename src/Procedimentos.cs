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
        
        public static void Init(string projeto)
        {            

            try
            {
                
                if (projeto == null)
                {
                    projeto = "meu-projeto";
                }

                //Cria os diretorios do projeto na pasta corrente
                string currentDir = Directory.GetCurrentDirectory();
                Directory.CreateDirectory($"{currentDir}\\{projeto}\\assets\\js");
                Directory.CreateDirectory($"{currentDir}\\{projeto}\\assets\\css");
                Directory.CreateDirectory($"{currentDir}\\{projeto}\\assets\\font");
                Directory.CreateDirectory($"{currentDir}\\{projeto}\\assets\\img");

                //Cria os arquivos do projeto em seus respectivos diretorios
                //File.Create($"{currentDir}\\{projeto}\\index.html");                
                File.Create($"{currentDir}\\{projeto}\\assets\\js\\script.js");
                File.Create($"{currentDir}\\{projeto}\\assets\\css\\style.css");

                //Prepara o arquivo para escrita
                StreamWriter sw = new StreamWriter($"{currentDir}\\{projeto}\\index.html");

                sw.WriteLine("<!DOCTYPE html>");
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("\t<meta charset=\"utf-8\">");
                sw.WriteLine("\t<meta http-equiv=\"X-UA-Compatible\" content=\"ie=edger\">");
                sw.WriteLine("\t<meta http-equiv=\"Content-type\" content=\"text/html;charset=UTF-8\">");
                sw.WriteLine("\t<link href=\"assets/css/style.css\" rel=\"stylesheet\"type=\"text/css\">");
                sw.WriteLine($"\t<title>{projeto}</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<h1>SlothHtml 1.0 :)</h1>");
                sw.WriteLine("</body>");
                sw.WriteLine("\t<script src=\"assets/js/script.js\"></script>");
                sw.WriteLine("</html>");  

                //Fecha o arquivo
                sw.Close();

                Console.WriteLine($"O projeto \'{projeto}\' foi executado com sucesso em {Directory.GetCurrentDirectory()}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Fim.");
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
                                Console.ReadKey();
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
                Console.WriteLine("Exception: " + e.Message);
            }
            
            
                        
            
        }       



    }
}
