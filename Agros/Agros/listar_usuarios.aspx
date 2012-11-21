<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listar_usuarios.aspx.cs" MasterPageFile="~/menu_administrador.master" Inherits="Agros.listar_usuarios" %>








<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Listado De Usuarios:</a></h2>


    <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:CommandField SelectText="X" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from usuario" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>


















<asp:Button ID="backtoabmusuarios" runat="server" Text="Volver" PostBackUrl="~/abmusuarios.aspx" />    

</asp:Content>
