using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.Entities; //entidades..
using Projeto.DAL.Persistence; //acesso a dados..

namespace Projeto.Web.Pages
{
    public partial class ConsultaDepartamento : System.Web.UI.Page
    {
        //Evento executado quando a página é carregada..
        protected void Page_Load(object sender, EventArgs e)
        {
            //verificar se a página está sendo carregada pela 1º vez..
            if( ! IsPostBack )
            {
                try
                {
                    DepartamentoDal d = new DepartamentoDal(); //persistencia..
                    gridDepartamentos.DataSource = d.FindAll(); //populando o grid..
                    gridDepartamentos.DataBind(); //exibir o conteudo do grid..
                }
                catch(Exception ex)
                {
                    //exibir mensagem de erro..
                    lblMensagem.Text = ex.Message;
                }
            }
        }
    }
}