//

namespace slothhtml.src
{
    class Result
    {
        private string _name;
        private string _latest;
        
        public Result(string name, string latest)
        {
            _name = name;
            _latest = latest;
        }
        public string name
        {
            get {
                return _name;
            }

            set {
                _name = value;            
            }        
        }

        public string latest
        {
            get
            {
                return _latest;
            }

            set
            {
                _latest = value;                
            }
        }      


    }
}
