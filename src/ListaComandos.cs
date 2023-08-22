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

            _comandos.Add(new Comando("search", "Pesquisa por bibliotecas no repositório cdnjs.", () => {

                Procedimentos.LibsSearch(_comandos[2].Param).Wait();                

            }));

            _comandos.Add(new Comando("require", "Requisita uma biblioteca do repositório cdnjs.com.", () => {

                Procedimentos.Require(_comandos[3].Param);

            }));

        }

        
        public List<Comando> Comandos
        {
            get => _comandos;
        }
         
    }
}
