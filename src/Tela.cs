using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slothhtml.src
{
    class Tela
    {
        public Tela() {
            
        }

        public static void Sobre() {

            LetraConsole.IniciarAlfabeto();
            LetraConsole.DrawString("Sloth html");

            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("SlothHTML v0.1");
            Console.WriteLine("Gerenciador de projetos HTML5.");
            Console.WriteLine("Dev: https://github.com/rafaelsouzars");
            Console.WriteLine("Repositório: https://github.com/rafaelsouzars/slothhtml");
            Console.WriteLine("----------------------------------------------------------------------------\n\n");
        }

        

    }
}
