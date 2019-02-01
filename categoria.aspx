<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="categoria.aspx.cs" Inherits="WebFrases.categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de categorias">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
         <br />
        &nbsp;<asp:TextBox ID="txtID" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome da categoria"></asp:Label>
         <br />
        &nbsp;<asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnInserir" runat="server" Text="Inserir" Width="74px" OnClick="btnInserir_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <br />
        <br />
       
        <br />
    </asp:Panel>
    <br />
    
     <asp:Panel ID="Panel2" runat="server" GroupingText="Registro das categorias">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  Width="385px" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="categoria" HeaderText="categoria" SortExpression="categoria" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>    
     </asp:Panel>
</asp:Content>
