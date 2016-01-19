using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.Entities; //entidades
using Projeto.DAL.Persistence; //acesso a banco

namespace Projeto.Web.Pages
{
    public partial class ConsultaFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                //resgatar os campos de data...
                DateTime DataIni = DateTime.Parse(txtDataIni.Text);
                DateTime DataFim = DateTime.Parse(txtDataFim.Text);

                FuncionarioDal d = new FuncionarioDal(); //persistencia..

                //populando o gridview..
                gridFuncionarios.DataSource = d.Find(DataIni, DataFim);
                gridFuncionarios.DataBind(); //exibir o conteudo..
            }
            catch(Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}