using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slothhtml.src
{
    class Interpretador
    {

        private static ListaComandos listaComandos = new ListaComandos();        
        
        
        public static void Comando(string[] args) {           

            Parser.input(args);   
            
        }

        public static void ListaComandos()
        {
            Console.WriteLine("COMANDO       DESCRIÇÃO");
            Console.WriteLine("-------------------------------------------------------------");

            listaComandos.Comandos.ForEach(cmd => {

                if (cmd.GetNome.Length <= 4)
                {
                    Console.Write($"{cmd.GetNome}          ");
                    Console.WriteLine($"{cmd.GetDescricao}");
                }
                else
                {
                    string space = "          ";
                    space = space.Remove(0, cmd.GetNome.Length-4);
                    Console.Write($"{cmd.GetNome}{space}");
                    Console.WriteLine($"{cmd.GetDescricao}");
                }
                

            });

            
        }

    }
}
