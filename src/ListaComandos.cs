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

            _comandos.Add(new Comando("init", "Cria um projeto no SlothHtml.", () => {

                
                Procedimentos.Init(_comandos[1].Param);               
                

            }));

            _comandos.Add(new Comando("search", "Pesquisa por bibliotecas no repositorio cdnjs.", async () => {

                Procedimentos.LibsSearch(_comandos[1].Param).Wait();
                Console.ReadKey();

            }));

        }

        
        public List<Comando> Comandos
        {
            get => _comandos;
        }
         
    }
}
