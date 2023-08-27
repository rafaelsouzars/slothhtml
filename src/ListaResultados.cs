using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace slothhtml.src
{
    class ListaResultados
    {
        private List<Result> _results;
        public ListaResultados()
        {
            
            
        }

        public List<Result> results {

            get {
                return _results;
            }

            set {
                _results = value;
            }       
        
        }
    }
}
