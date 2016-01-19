using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.Entities; //classes de entidade..
using Projeto.DAL.Persistence; //acesso a banco..

namespace Projeto.Web.Pages
{
    public partial class CadastroFuncionario : System.Web.UI.Page
    {
        //Evento executado quando a página é carregada
        protected void Page_Load(object sender, EventArgs e)
        {
            //verificar se a página está sendo carregada pela 1º vez..
            if( ! IsPostBack )
            {
                try
                {
                    DepartamentoDal d = new DepartamentoDal(); //persistencia..
                    ddlDepartamentos.DataSource = d.FindAll(); //populando o dropdownlist
                    ddlDepartamentos.DataValueField = "IdDepartamento"; //valor do campo
                    ddlDepartamentos.DataTextField = "Nome"; //texto do campo
                    ddlDepartamentos.DataBind(); //exibir o conteudo..

                    //incluir um novo elemento no campo..
                    ddlDepartamentos.Items.Insert(0, new ListItem("- Escolha uma Opção -", ""));
                }
                catch(Exception ex)
                {
                    //imprimir mensagem de erro..
                    lblMensagem.Text = ex.Message;
                }
            }
        }



        //evento executado quando o botão for clicado..
        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                //instanciando as entidades..
                Funcionario f = new Funcionario();
                f.Departamento = new Departamento();
                f.Endereco = new Endereco();

                //resgatar o conteudo dos campos..
                f.Nome = txtNome.Text;
                f.Salario = Decimal.Parse(txtSalario.Text);
                f.DataAdmissao = DateTime.Parse(txtDataAdmissao.Text);
                f.Departamento.IdDepartamento = Int32.Parse(ddlDepartamentos.SelectedValue);
                f.Endereco.Logradouro = txtLogradouro.Text;
                f.Endereco.Cidade = txtCidade.Text;
                f.Endereco.Estado = txtEstado.Text;
                f.Endereco.Cep = txtCep.Text;

                FuncionarioDal d = new FuncionarioDal(); //persistencia..
                d.Insert(f); //gravando..

                lblMensagem.Text = "Funcionario " + f.Nome + ", cadastrado com sucesso.";
                LimparCampos();
            }
            catch(Exception ex)
            {
                //imprimir mensagem de erro...
                lblMensagem.Text = ex.Message;
            }
        }

        //método para limpar os campos do formulario..
        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtSalario.Text = string.Empty;
            txtDataAdmissao.Text = string.Empty;
            ddlDepartamentos.SelectedIndex = 0;
            txtLogradouro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCep.Text = string.Empty;
        }
    }
}