using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL.DataSource;
using System.Data.SqlClient; //acesso ao banco..
using Projeto.Entities; //entidades..

namespace Projeto.DAL.Persistence
{
    public class DepartamentoDal : Conexao
    {
        //método para inserir um departamento da tabela..
        public void Insert(Departamento d)
        {
            try
            {
                OpenConnection(); //abrir conexão..
                Cmd = new SqlCommand("insert into Departamento(Nome, Descricao) values(@v1, @v2)", Con);
                Cmd.Parameters.AddWithValue("@v1", d.Nome);
                Cmd.Parameters.AddWithValue("@v2", d.Descricao);
                Cmd.ExecuteNonQuery(); //executando..
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao inserir Departamento: " + e.Message);
            }
            finally
            {
                CloseConnection(); //fechar conexão..
            }
        }

        //método para listar todos os departamentos...
        public List<Departamento> FindAll()
        {
            try
            {
                OpenConnection(); //abrir conexão..
                Cmd = new SqlCommand("select * from Departamento", Con);
                Dr = Cmd.ExecuteReader(); //executando e lendo os registros da consulta..

                List<Departamento> lista = new List<Departamento>(); //lista vazia..

                while(Dr.Read()) //enquanto houver registros...
                {
                    Departamento d = new Departamento(); //instanciando..
                    d.IdDepartamento = (Int32) Dr["IdDepartamento"];
                    d.Nome = (String) Dr["Nome"];
                    d.Descricao = (String) Dr["Descricao"];
                    lista.Add(d); //adicionar na lista..
                }

                return lista; //retornar a lista..
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao listar departamentos: " + e.Message);
            }
            finally
            {
                CloseConnection(); //fechar conexão..
            }
        }

    }
}

