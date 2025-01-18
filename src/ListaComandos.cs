using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slothhtml.src
{
    class ListaComandos
    {
        private List<Comando> _comandos;
        public ListaComandos()
        {
            _comandos = new List<Comando>();

            _comandos.Add(new Comando("help", "Mostra a lista de comandos do SlothHtml.", () => {

                Console.WriteLine("Comando help foi executado");

            }));

            _comandos.Add(new Comando("init", "Este comando inicia um projeto com estrutura de pastas e o arquivo index.html", () => {

                
                Procedimentos.Init(_comandos[1].Param);               
                

            }));

            _comandos.Add(new Comando("search", "Pesquisar bibliotecas no cdnjs.", () => {

                Procedimentos.LibsSearch(_comandos[2].Param).Wait();                

            }));

            _comandos.Add(new Comando("libs", "Requisitar biblioteca do cdnjs.", () => {

                Procedimentos.InsertLib();

            }));

        }

        
        public List<Comando> Comandos
        {
            get => _comandos;
        }
         
    }
}
