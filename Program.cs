using System;
using slothhtml.src;

namespace slothhtml
{
    class Program
    {
        static void Main(string[] args)
        {
                       
            //Se o tamanho do array de argumentos for maior que 0
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
