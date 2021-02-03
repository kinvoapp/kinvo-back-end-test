<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Aliquota.Domain._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Ativo Rendimento 100% do CDI
    </h2>
    <p>
        Aporte Inicial<br />
        <asp:TextBox ID="TbAp1" runat="server"></asp:TextBox>
    </p>
    <p>
        Aportes Mensais<br />
        <asp:TextBox ID="TbAp2" runat="server"></asp:TextBox>
    </p>
    <p>
        Meses Investido<br />
        <asp:TextBox ID="TbMsI" runat="server" MaxLength="3"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="BtnCalcular" runat="server" Text="Calcular" 
            onclick="BtnCalcular_Click" />
    </p>
    <p>
        Valor Total sem IR:
        <asp:Label ID="LbResgate" runat="server" Text="R$ 0,00"></asp:Label><br />
        IR (%):
        <asp:Label ID="LbPIR" runat="server" Text="0%"></asp:Label><br />
        Valor de Resgate descontando IR:
        <asp:Label ID="LbResgateIR" runat="server" Text="R$ 0,00"></asp:Label>
    </p>
</asp:Content>
