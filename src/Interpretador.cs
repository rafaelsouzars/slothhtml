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

            listaComandos.Comandos.ForEach(cmd => {

                if (args[0] == cmd.GetNome)
                {
                    if (args.Length > 1)
                    {
                        cmd.Param = args[1];
                        //Console.WriteLine($"Numero de Arqgumentos: {args.Length}, Segundo Argumento: {cmd.Param}");
                    }
                    cmd.Executar();
                }                
                else
                {
                    Console.WriteLine($"{args[0]} - Comando não encontrado!!!");
                    throw new Exception($"{args[0]} - Comando não encontrado!!!");                    
                }
                
                
            });
            
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
