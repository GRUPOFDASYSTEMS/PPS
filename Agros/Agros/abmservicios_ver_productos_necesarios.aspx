<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_ver_productos_necesarios.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios_ver_productos_necesarios" %>








<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#" >Listado de productos necesarios para el servicio 
        especifico 
     </a> </h2> 


<asp:Label ID="Label1" runat="server" Text="Asociado al servicio: "> </asp:Label>
<asp:Label ID="Lidds" runat="server" Text=""> </asp:Label>


    <asp:GridView ID="dgvDatos" runat="server" DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="dgvdatos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="X" ShowSelectButton="True" HeaderText="Elimina" />
        </Columns>
    </asp:GridView>



    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select pn.id, p.descripcion, pn.cantidad from producto_necesario pn, productos p where pn.id_producto=p.id and pn.id_detalle_servicio=" Name="consulta" 
                Type="String" />
            <asp:SessionParameter DefaultValue="" Name="id" 
                SessionField="id_detalle_servicio" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>      
         
<asp:Button ID="backtoabmservicios" runat="server" Text="Volver A Listado De Servicios"  PostBackUrl="~/abmservicios_listado_detalle.aspx" />
&nbsp;<asp:Button ID="toaddnewp" runat="server" Text="Agregar Nuevo Producto Necesario A Este Servicio"  PostBackUrl="~/abmservicios_agregar_producto_necesario.aspx" />


</asp:Content>

