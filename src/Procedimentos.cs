using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace slothhtml.src
{
    class Procedimentos
    {
        
        public static void Init(string projeto)
        {            

            try
            {
                Console.WriteLine($"Variável projeto: {projeto}");
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
                sw.WriteLine("\t<meta charset=\"utf - 8\">");
                sw.WriteLine("\t<meta http-equiv=\"X - UA - Compatible\" content=\"ie = edger\">");
                sw.WriteLine("\t<meta http-equiv=\"Content - type\" content=\"text / html; charset = UTF - 8\">");
                sw.WriteLine("\t<link href=\"assets / css / style.css\" rel=\"stylesheet\" type=\"text / css\">");
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
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new System.Uri("https://api.cdnjs.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync($"libraries?search={query}");

                    if (response.IsSuccessStatusCode)
                    {
                        //pegando o cabeçalho
                        Console.WriteLine(response.Headers.Location);

                        //Pegando os dados do Rest e armazenando na variável usuários
                        var usuarios = await response.Content.ReadAsStringAsync();

                        //preenchendo a lista com os dados retornados da variável

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
