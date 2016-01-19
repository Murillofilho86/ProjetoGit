using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //acesso ao sqlserver..
using System.Configuration; //connectionstring

namespace Projeto.DAL.DataSource
{
    public class Conexao
    {
        //atributos..
        protected SqlConnection Con;    //conexão com o banco..
        protected SqlCommand Cmd;       //executar comandos sql..
        protected SqlDataReader Dr;     //ler dados de consultas..
        protected SqlTransaction Tr;    //transações (commit / rollback)

        //métodos..
        protected void OpenConnection() //abrir conexão..
        {
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["aula"].ConnectionString);
            Con.Open(); //conectado..
        }

        protected void CloseConnection() //fechar conexão..
        {
            Con.Close(); //desconectado..
        }
    }
}
