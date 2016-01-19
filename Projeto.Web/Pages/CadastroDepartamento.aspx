<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="CadastroDepartamento.aspx.cs" Inherits="Projeto.Web.Pages.CadastroDepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPrincipal" runat="server">

    <h4>Cadastro de Departamentos</h4>
    Para inserir um novo departamento, informe os dados abaixo:
    <hr />

    <div class="row">
        <div class="col-md-4">

            <label>Nome do Departamento:</label> 
            <asp:TextBox ID="txtNome" runat="server" 
                CssClass="form-control" 
                placeholder="Digite aqui"
                required="required" 
                pattern="^[A-Za-z0-9\s]{6,50}$"
                title="Por favor informe o nome do departamento." />
            <br />

            <label>Descrição:</label>
            <asp:TextBox ID="txtDescricao" runat="server"
                CssClass="form-control" TextMode="MultiLine"
                placeholder="Digite aqui" 
                required="required"
                pattern="^[A-Za-z0-9\s]{6,150}$"
                title="Por favor, informe a descrição do departamento." />
            <br />

            <asp:Button ID="btnCasdastro" runat="server"
                Text="Cadastrar Departamento"
                CssClass="btn btn-primary btn-block"
                OnClick="btnCasdastro_Click" />
            <br /><br />

            <asp:Label ID="lblMensagem" runat="server" />

        </div>
    </div>

</asp:Content>
