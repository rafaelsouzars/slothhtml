using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slothhtml.src
{
    class Comando
    {
        private string _nomeComando;        
        private string _descricao;
        private string _param;
        private Action _funcao;

        public string GetNome {

            get => _nomeComando;       
        
        }
        

        public string GetDescricao
        {

            get => _descricao;

        }

        public string Param
        {

            get => _param;

            set
            {
                _param = value;
            }

        }

        public Action Funcao
        {

            get => _funcao;

            set
            {
                _funcao = value;
            }

        }


        public Comando(string nomeComando, string descricao, Action funcao)
        {
            _nomeComando = nomeComando;            
            _descricao = descricao;
            _funcao = funcao;
        }

        public Comando(string nomeComando, string descricao, string param, Action funcao)
        {
            _nomeComando = nomeComando;
            _descricao = descricao;
            _param = param;
            _funcao = funcao;
        }


        public void Executar() {
            _funcao();
        }




    }
}
