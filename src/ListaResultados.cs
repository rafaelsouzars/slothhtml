using System.Collections.Generic;

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
