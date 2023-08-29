using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace slothhtml.src
{
    class Arquivos
    {

        public static void InserirBiblioteca(string nomeArquivo, string lib)
        {
            string currentDir = Directory.GetCurrentDirectory();
            
            //Cria o documento HTML
            HtmlDocument documentoHtml = new HtmlDocument();
            
            //Carrega um arquivo HTML
            documentoHtml.Load($"{currentDir}\\{nomeArquivo}.html");                        

            //Seleciona o nó do elemento html
            HtmlNode htmlNode = documentoHtml.DocumentNode.SelectSingleNode("html");            
            
            //Cria um novo elemento script no html
            HtmlNode novoElementoScript = HtmlNode.CreateNode($"\t<script src=\"{lib}\"><//script>\n");            

            //Insere o elemento no nó
            htmlNode.AppendChild(novoElementoScript);            

            //Mostra os elementos do html após a inserção
            Console.WriteLine(htmlNode.InnerHtml);  

            //Salva o documento
            documentoHtml.Save($"{currentDir}\\{nomeArquivo}.html");
            Console.WriteLine($"As alterações no arquivo \"{nomeArquivo}.html\" foram salvas!");
            Console.WriteLine($"A lib \"{lib}\" foi incluida com sucesso!");

        }

        public static void GravarHtml() {
                   
        }

        public static void LerJson() {
        
        
        }

        public static void GravarJson() {
            
        }
    }
}
