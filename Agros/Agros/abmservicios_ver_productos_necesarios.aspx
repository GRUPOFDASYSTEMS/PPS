<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_ver_productos_necesarios.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios_ver_productos_necesarios" %>








<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#" />Listado de productos necesarios para el servicio 
        especifico 
    <asp:Label ID="labelProductoEspecifico" runat="server" Text="Ejemplo"></asp:Label>  </h2> 

    <asp:GridView ID="dgvDatos" runat="server" DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="dgvdatos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="X" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>



    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from producto_necesario" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>      
         
<asp:Button ID="backtoabmservicios" runat="server" Text="Volver A Servicios"  PostBackUrl="~/abmservicios.aspx" />
<input id="back" type="button" value="Volver Atras" onclick="history.back();"/>
<asp:Button ID="toaddnewp" runat="server" Text="Agregar Nuevo Producto Necesario A Este Servicio"  PostBackUrl="~/abmservicios_agregar_producto_necesario.aspx" />


</asp:Content>

