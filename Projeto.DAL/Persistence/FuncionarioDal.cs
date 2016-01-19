using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL.DataSource; //conexão..
using Projeto.Entities; //entidades..
using System.Data.SqlClient; //ADO.Net

namespace Projeto.DAL.Persistence
{
    public class FuncionarioDal : Conexao
    {
        //método para gravar o funcionario na tabela..
        public void Insert(Funcionario f)
        {
            try
            {
                OpenConnection(); //abrir conexão..
                Tr = Con.BeginTransaction(); //abrindo transação..

                //Passo 1) gravar o funcionario..
                Cmd = new SqlCommand("insert into Funcionario(Nome, Salario, DataAdmissao, IdDepartamento) values(@v1, @v2, @v3, @v4) select scope_identity()", Con, Tr);
                Cmd.Parameters.AddWithValue("@v1", f.Nome);
                Cmd.Parameters.AddWithValue("@v2", f.Salario);
                Cmd.Parameters.AddWithValue("@v3", f.DataAdmissao);
                Cmd.Parameters.AddWithValue("@v4", f.Departamento.IdDepartamento); //foreign key..
                f.IdFuncionario = Convert.ToInt32(Cmd.ExecuteScalar());

                //Passo 2) gravar o endereco..
                Cmd = new SqlCommand("insert into Endereco(Logradouro, Cidade, Estado, Cep, IdFuncionario) values(@v1, @v2, @v3, @v4, @v5)", Con, Tr);
                Cmd.Parameters.AddWithValue("@v1", f.Endereco.Logradouro);
                Cmd.Parameters.AddWithValue("@v2", f.Endereco.Cidade);
                Cmd.Parameters.AddWithValue("@v3", f.Endereco.Estado);
                Cmd.Parameters.AddWithValue("@v4", f.Endereco.Cep);
                Cmd.Parameters.AddWithValue("@v5", f.IdFuncionario); //foreign key..
                Cmd.ExecuteNonQuery(); //executar..

                Tr.Commit(); //executar a transação..
            }
            catch(Exception e)
            {
                if(Tr != null) //se há transação criada..
                {
                    Tr.Rollback(); //desfazer a transação..
                }

                throw new Exception("Erro ao inserir Funcionario: " + e.Message);
            }
            finally
            {
                CloseConnection(); //fechar conexão..
            }
        }


        //método para listar os funcionarios da view pela data de admissão
        public List<Funcionario> Find(DateTime DataIni, DateTime DataFim)
        {
            try
            {
                OpenConnection(); //abrir conexão..
                Cmd = new SqlCommand("select * from vwFuncionarios where DataAdmissao between @v1 and @v2", Con);
                Cmd.Parameters.AddWithValue("@v1", DataIni);
                Cmd.Parameters.AddWithValue("@v2", DataFim);
                Dr = Cmd.ExecuteReader(); //executando a consulta e lendo os registros..

                List<Funcionario> lista = new List<Funcionario>(); //lista vazia..

                while(Dr.Read()) //enquanto houver registros..
                {
                    Funcionario f = new Funcionario(); //instanciando..
                    f.Endereco = new Endereco(); //instanciando
                    f.Departamento = new Departamento(); //instanciando

                    f.IdFuncionario = (Int32) Dr["IdFuncionario"];
                    f.Nome = (String) Dr["Nome"];
                    f.Salario = (Decimal) Dr["Salario"];
                    f.DataAdmissao = (DateTime) Dr["DataAdmissao"];
                    f.Departamento.Nome = (String) Dr["Depto"];
                    f.Departamento.Descricao = (String) Dr["Descricao"];
                    f.Endereco.Logradouro = (String) Dr["Logradouro"];
                    f.Endereco.Cidade = (String)Dr["Cidade"];
                    f.Endereco.Estado = (String)Dr["Estado"];
                    f.Endereco.Cep = (String)Dr["Cep"];

                    lista.Add(f); //adicionar dentro da lista..
                }

                return lista; //retornar a lista..
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao listar funcionarios: " + e.Message);
            }
            finally
            {
                CloseConnection(); //fechar conexão..
            }
        }

    }
}
