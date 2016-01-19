<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="CadastroFuncionario.aspx.cs" Inherits="Projeto.Web.Pages.CadastroFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPrincipal" runat="server">

    <h4>Cadastro de Funcionarios</h4>
    Para incluir um funcionario, informe os dados abaixo:
    <hr />

    <div class="row">

        <div class="col-md-3">

            <label>Nome do Funcionario:</label>
            <asp:TextBox ID="txtNome" runat="server"
                placeholder="Digite aqui" required="required"
                CssClass="form-control" />
            <br />

            <label>Salário:</label>
            <asp:TextBox ID="txtSalario" runat="server"
                placeholder="Digite aqui" required="required"
                CssClass="form-control" />
            <br />

            <label>Data de Admissão:</label>
            <asp:TextBox ID="txtDataAdmissao" runat="server"
                type="date" required="required"
                CssClass="form-control" />
            <br />

            <label>Selecione o Departamento:</label>
            <asp:DropDownList ID="ddlDepartamentos" runat="server"
                CssClass="form-control" />
            <br />

            <asp:Button ID="btnCadastro" runat="server"
                Text="Cadastrar Funcionario"
                CssClass="btn btn-primary"
                OnClick="btnCadastro_Click" />

        </div>

        <div class="col-md-3">

            <label>Logradouro:</label>
            <asp:TextBox ID="txtLogradouro" runat="server"
                CssClass="form-control" TextMode="MultiLine"
                placeholder="Digite aqui" required="required" />
            <br />

            <label>Cidade:</label>
            <asp:TextBox ID="txtCidade" runat="server"
                CssClass="form-control" placeholder="Digite aqui"
                required="required" />
            <br />

            <label>Estado:</label>
            <asp:TextBox ID="txtEstado" runat="server"
                CssClass="form-control" placeholder="Digite aqui"
                required="required" />
            <br />

            <label>Cep:</label>
            <asp:TextBox ID="txtCep" runat="server"
                CssClass="form-control" placeholder="Digite aqui"
                required="required" />
            <br />

        </div>

    </div>

    <p>
        <asp:Label ID="lblMensagem" runat="server" />
    </p>

</asp:Content>
