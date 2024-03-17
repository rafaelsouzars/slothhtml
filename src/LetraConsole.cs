using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slothhtml.src
{
    class LetraConsole
    {
        public char Character { get; private set; }
        public int[,] Font { get; private set; }

        // Lista de fontes estática na classe LetraConsole
        private static List<LetraConsole> alfabeto = new List<LetraConsole>();

        public static void IniciarAlfabeto()
        {
            // Populando a lista de fontes no construtor estático
            alfabeto = Alfabeto();
        }

        public LetraConsole(char character, int[,] font)
        {
            Character = character;
            Font = font;
        }

        public static void Display()
        {
            foreach (var letra in alfabeto)
            {
                int height = letra.Font.GetLength(0);
                int width = letra.Font.GetLength(1);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write(letra.Font[i, j] == 0 ? " " : "█"); // " " para espaços em branco, "█" para espaços preenchidos
                    }
                    Console.Write("  "); // Espaço entre letras
                }
                Console.WriteLine(); // Nova linha para a próxima linha da letra
            }
            
        }

        public static void DrawString(string input)
        {
            int height = alfabeto[0].Font.GetLength(0);

            for (int i = 0; i < height; i++)
            {
                foreach (var character in input)
                {
                    var letter = alfabeto.Find(l => char.ToLower(l.Character) == char.ToLower(character));
                    if (letter != null)
                    {
                        for (int j = 0; j < letter.Font.GetLength(1); j++)
                        {
                            Console.Write(letter.Font[i, j] == 0 ? " " : "█");
                        }
                        Console.Write("  "); // Espaço entre letras
                    }
                    else
                    {
                        Console.Write("     "); // Se a letra não estiver disponível, espaço em branco
                    }
                }
                Console.WriteLine(); // Nova linha para a próxima linha da letra
            }
        }

        private static List<LetraConsole> Alfabeto()
        {
            List<LetraConsole> alfabeto = new List<LetraConsole>();

            // Representações em matriz para cada letra de "a" a "z" com array 5x5
            int[,] fontA = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new LetraConsole('a', fontA));

            int[,] fontB = {
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('b', fontB));

            int[,] fontC = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('c', fontC));

            int[,] fontD = {
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('d', fontD));

            int[,] fontE = {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new LetraConsole('e', fontE));

            int[,] fontF = {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 }
        };
            alfabeto.Add(new LetraConsole('f', fontF));

            int[,] fontG = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('g', fontG));

            int[,] fontH = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new LetraConsole('h', fontH));

            int[,] fontI = {
            { 1, 1, 1, 1, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new LetraConsole('i', fontI));

            int[,] fontJ = {
            { 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('j', fontJ));

            int[,] fontK = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 1, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new LetraConsole('k', fontK));

            int[,] fontL = {
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new LetraConsole('l', fontL));

            int[,] fontM = {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new LetraConsole('m', fontM));

            int[,] fontN = {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new LetraConsole('n', fontN));

            int[,] fontO = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('o', fontO));

            int[,] fontP = {
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 }
        };
            alfabeto.Add(new LetraConsole('p', fontP));

            int[,] fontQ = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 0 },
            { 0, 1, 1, 0, 1 }
        };
            alfabeto.Add(new LetraConsole('q', fontQ));

            int[,] fontR = {
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('r', fontR));

            int[,] fontS = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('s', fontS));

            int[,] fontT = {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };
            alfabeto.Add(new LetraConsole('t', fontT));

            int[,] fontU = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('u', fontU));

            int[,] fontV = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };
            alfabeto.Add(new LetraConsole('v', fontV));

            int[,] fontW = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new LetraConsole('w', fontW));

            int[,] fontX = {
            { 1, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new LetraConsole('x', fontX));

            int[,] fontY = {
            { 1, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };
            alfabeto.Add(new LetraConsole('y', fontY));

            int[,] fontZ = {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new LetraConsole('z', fontZ));

            // Representações em matriz para os números de 0 a 9 com array 5x5
            int[,] font0 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('0', font0));

            int[,] font1 = {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('1', font1));

            int[,] font2 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 0, 1, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new LetraConsole('2', font2));

            int[,] font3 = {
            { 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('3', font3));

            int[,] font4 = {
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('4', font4));

            int[,] font5 = {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('5', font5));

            int[,] font6 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('6', font6));

            int[,] font7 = {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };
            alfabeto.Add(new LetraConsole('7', font7));

            int[,] font8 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('8', font8));

            int[,] font9 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new LetraConsole('9', font9));

            return alfabeto;
        }

        public static List<LetraConsole> GetAlphabet()
        {
            return alfabeto;
        }
    }
}
