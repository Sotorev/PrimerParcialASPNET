<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimerParcialASPNET2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Primer parcial en ASP.NET</h1>
    <div class="container">
        <div class="row glyphicon-align-center jumbotron">
            <div class="col-lg-4">
                <asp:Label ID="Label1" runat="server" Text="Seleccione un alumno"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>   
            </div>
            <div class="col-lg-8">
                <asp:Label ID="Label2" runat="server" Text="Seleccione un grado"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                </asp:DropDownList>   
            </div>
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Ingresar datos" class="btn btn-primary" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" class="btn btn-primary" OnClick="Button2_Click" Text="Ver resumen" />
    </div>
    
    
</asp:Content>
