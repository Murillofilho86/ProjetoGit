using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.Entities; //entidades..
using Projeto.DAL.Persistence; //aceso a banco..

namespace Projeto.Web.Pages
{
    public partial class CadastroDepartamento : System.Web.UI.Page
    {
        //Evento executado quando a página é carregada..
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        //Evento executado quando o botão é clicado..
        protected void btnCasdastro_Click(object sender, EventArgs e)
        {
            try
            {
                Departamento depto = new Departamento(); //entidade..
                depto.Nome = txtNome.Text;
                depto.Descricao = txtDescricao.Text;

                DepartamentoDal d = new DepartamentoDal(); //persistencia..
                d.Insert(depto); //gravando..

                lblMensagem.Text = "Departamento " + depto.Nome + ", cadastrado com sucesso.";

                //limpar os campos..
                txtNome.Text = string.Empty; //vazio..
                txtDescricao.Text = string.Empty; //vazio..
            }
            catch(Exception ex)
            {
                //imprimir mensagem de erro..
                lblMensagem.Text = ex.Message;
            }
        }
    }
}