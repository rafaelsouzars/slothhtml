using System;
using slothhtml.src;

namespace slothhtml
{
    class Program
    {
        static void Main(string[] args)
        {
                       

            if (args.Length>0)
            {
                Interpretador.Comando(args);
            }
            else
            {
                Tela.Sobre();
                Interpretador.ListaComandos();
            }





        }
    }
}
