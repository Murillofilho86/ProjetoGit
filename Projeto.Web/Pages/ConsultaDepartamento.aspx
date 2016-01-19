<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ConsultaDepartamento.aspx.cs" Inherits="Projeto.Web.Pages.ConsultaDepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPrincipal" runat="server">

    <h4>Consulta de Departamentos</h4>
    Relação de despartamentos cadastrados.
    <hr />

    <p>
        <asp:Label ID="lblMensagem" runat="server" />
    </p>

    <asp:GridView ID="gridDepartamentos" runat="server"
        CssClass="table table-hover" GridLines="None">
        
    </asp:GridView>


</asp:Content>
