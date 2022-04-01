<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="PrimerParcialASPNET2.Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">

        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Ordenar" class="btn btn-primary" OnClick="Button1_Click"/>

        <asp:Button ID="Button2" runat="server" Text="Total de alumnos" class="btn btn-warning" OnClick="Button2_Click"/>
        
    </div>
</asp:Content>
