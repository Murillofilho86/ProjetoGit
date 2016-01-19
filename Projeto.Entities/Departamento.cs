using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        #region Relacionamentos

        public ICollection<Funcionario> Funcionarios { get; set; }

        #endregion
   
    
    }
}
