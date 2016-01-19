using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        #region Relacionamentos

        public Funcionario Funcionario { get; set; }

        #endregion
    }
}
