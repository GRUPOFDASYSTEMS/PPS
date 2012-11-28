<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_agregar_producto_necesario.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios_agregar_producto_necesario" %>








<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Composicion Servicio - Detalle de servicios - Adicion De Productos Necesarios</a></h2>

          <p class="meta">
              Asociado al servicio:<asp:Label ID="Lidds" runat="server" Text=""></asp:Label>
                    
        <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource1" 
                  onselectedindexchanged="dgvDatos_SelectedIndexChanged" AllowPaging="True">
            <Columns>
                <asp:CommandField SelectText="-&gt;" ShowSelectButton="True" 
                    HeaderText="Marcar" />
            </Columns>
    </asp:GridView>
    


                </p>
                


    <asp:Label ID="Labeltext" runat="server" Text="Producto Seleccionado"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Labelcant" runat="server" Text="Racion del producto necesaria (para 1 hectarea):    ."></asp:Label>
    <asp:TextBox ID="cantidad" runat="server"></asp:TextBox>
                



    <br />
         <asp:Button ID="add" runat="server" Text="Agregar Producto" onclick="add_Click"  />     


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select p.id, p.descripcion, u.descripcion, p.racion_unidad_medida as Racion, p.comentario from productos p, unidad_medida u where p.unidad_medida=u.id" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    
    
    
<%--        <table>
         <tr>
        <td>
            <asp:Button ID="Button2" runat="server" Text="*" PostBackUrl="~/abmservicios_ver_productos_necesarios.aspx" />
        </td>

         
         </tr>
         </table>   
--%>&nbsp;

        <asp:Button ID="Button1" runat="server" Text="Finalizar Carga"  PostBackUrl="~/abmservicios_listado_detalle.aspx"/> 

    
</asp:Content>