using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace slothhtml.src
{
    class Parser
    {

        // Regex rules
        private static Regex commandRegex = new Regex(@"(init|help|search|libs)");
        private static Regex optionRegex = new Regex(@"^[\s]{0,1}([-]{1}[a-zA-Z]{1})+$");
        private static Regex stringRegex = new Regex(@"^[\s]{0,1}([-]{0}[a-zA-Z_0-9]+([-][a-zA-Z_0-9]+)?)+");

        // Lista de comandos
        private static ListaComandos listaComandos = new ListaComandos();

        public static void input(string[] lineCommands)
        {
            
            switch (lineCommands.Length) {
                case 1:
                    try
                    {
                        if (commandRegex.Match(lineCommands[0]).Success)
                        {
                            commandExec(lineCommands[0]);
                        }
                        else {
                            throw new ArgumentException(lineCommands[0] + " é um comando desconhecido");                   
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        errorMessage(ex);                       
                    }                    
                break;
                case 2:
                    try
                    {
                        if (commandRegex.Match(lineCommands[0]).Success)
                        {
                            //Console.WriteLine(commandRegex01.Match(lineCommands[0]).Value + " executado com sucesso!");

                            if (stringRegex.Match(lineCommands[1]).Success)
                            {
                                commandExec(lineCommands[0],lineCommands[1]);
                            }
                            else
                            {
                                throw new ArgumentException(lineCommands[1] + " argumento inválido!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException(lineCommands[0] + " é um comando desconhecido");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        errorMessage(ex);
                    }
                    
                break;
                case 3:
                    try
                    {
                        if (commandRegex.Match(lineCommands[0]).Success)
                        {
                            //Console.WriteLine(commandRegex01.Match(lineCommands[0]).Value + " executado com sucesso!");

                            if (optionRegex.Match(lineCommands[1]).Success)
                            {
                                //Console.WriteLine(commandRegex01.Match(lineCommands[0]).Value + " " + commandRegex01.Match(lineCommands[1]).Value + " ok");
                                if (stringRegex.Match(lineCommands[2]).Success)
                                {
                                    //
                                }
                                else 
                                {
                                    throw new ArgumentException(lineCommands[2] + " argumento inválido!");
                                }
                            }
                            else
                            {
                                throw new ArgumentException(lineCommands[1] + " opção invalida!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException(lineCommands[0] + " é um comando desconhecido");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        errorMessage(ex);
                    }

                    break;
                default:
                break;
            }

            
        }

        
        private static void commandExec(string comando)
        {
            listaComandos.Comandos.ForEach(cmd => {
                if (comando == cmd.GetNome)
                {
                    cmd.Executar();
                }
            });
        }
        private static void commandExec(string comando, string parametro) {
            listaComandos.Comandos.ForEach(cmd => {
                if (comando == cmd.GetNome)
                {
                    cmd.Param = parametro;                    
                    cmd.Executar();
                }
            });
        }

        private static void systemGetColor () {
            ConsoleColor[] consoleColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            // Display the list 
            // of available console colors 
            Console.WriteLine("List of available " + "Console Colors:");
            foreach (var color in consoleColors)
                Console.WriteLine(color);
            
        }

        private static void errorMessage (ArgumentException ex) {
            ConsoleColor currentForengroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Mensagem de Erro: {ex.Message}", Console.ForegroundColor);
            Console.ForegroundColor = currentForengroundColor;
            //Console.WriteLine(Console.ForegroundColor);
        }

        private static void viewStringArray(Array array) 
        {
            foreach (string element in array) 
            {
                Console.WriteLine(element);
            }
        }

        private static void clearArray(Array array) 
        {
            if (array.Length > 0)
            {
                Array.Clear(array, 0, array.Length - 1);
            }
        }
    }
}
