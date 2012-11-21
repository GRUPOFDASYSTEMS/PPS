<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmproductos_listados.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmproductos_listados" %>







<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#" />Listado de productos:</h2> 


        

     
    <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="X" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from productos" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>



<asp:Button ID="backtoabmproductos" runat="server" Text="Volver"  PostBackUrl="~/abmproductos.aspx" />   

</asp:Content>

