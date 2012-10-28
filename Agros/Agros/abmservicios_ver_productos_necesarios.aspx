<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_ver_productos_necesarios.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmservicios_ver_productos_necesarios" %>








<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#" />Listado de productos necesarios para el servicio especifico 
    <asp:Label ID="labelProductoEspecifico" runat="server" Text="Ejemplo"></asp:Label>  </h2> 


        

(ejemplo)
        <table>
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Producto</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Cantidad De Unidades Necesarias</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Raci&oacute;n Unidad De Medida</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Unidad De Medida</p>
          </td>

          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentario Adicional</p>
          </td>


         </tr>











         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Acido Sulfurico</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; 2</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; 5</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Litros</p>
          </td>
          <td>
              Evitar mojar los recipientes (Balde de 5 lts)
          </td>
          
          
         </tr>
         </table>   
         
<asp:Button ID="backtoabmservicios" runat="server" Text="Volver A Servicios"  PostBackUrl="~/abmservicios.aspx" />
<input id="back" type="button" value="Volver Atras" onclick="history.back();"/>
<asp:Button ID="toaddnewp" runat="server" Text="Agregar Nuevo Producto Necesario A Este Servicio"  PostBackUrl="~/abmservicios_agregar_producto_necesario.aspx" />

    </form>
</asp:Content>

