<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ConsultaFuncionario.aspx.cs" Inherits="Projeto.Web.Pages.ConsultaFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPrincipal" runat="server">

    <!-- Ativar o gerador de javascript para Ajax -->
    <asp:ScriptManager ID="ajax" runat="server" />

    <h4>Consulta de Funcionarios</h4>
    Para pesquisar funcionarios, informe os filtros abaixo:
    <hr />

    <!-- Painel para eventos Ajax -->
    <asp:UpdatePanel ID="painelAjax" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-md-3">

                    Selecione o periodo de contratação dos funcionarios:
                    <br /><br />

                    <label>Data de Inicio</label>
                    <asp:TextBox ID="txtDataIni" runat="server"
                        CssClass="form-control" type="date" />
                    <br />

                    <label>Data de Termino</label>
                    <asp:TextBox ID="txtDataFim" runat="server"
                        CssClass="form-control" type="date" />
                    <br />

                    <asp:Button ID="btnPesquisa" runat="server"
                        Text="Pesquisar Funcionarios"
                        CssClass="btn btn-primary btn-block"
                        OnClick="btnPesquisa_Click" />

                </div>
                <div class="col-md-9">

                    <p>
                        <asp:Label ID="lblMensagem" runat="server" />
                    </p>

                    <asp:GridView ID="gridFuncionarios" runat="server">
                    </asp:GridView>

                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
