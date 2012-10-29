<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmproductos_listados.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmproductos_listados" %>







<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#" />Listado de productos:</h2> 


        

(ejemplo)
        <table>
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Producto</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Unidad Medida</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Raci&oacute;n Unidad De Medida</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentario Adicional</p>
          </td>

          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Edicion</p>
          </td>


         </tr>











         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Acido Sulfurico</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Litros</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; 4</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Evitar mojar los recipientes (Balde de 5 lts)</p>
          </td>
          <td>
              <asp:Button ID="Button1" runat="server" Text=".." PostBackUrl="~/abmproductos_mod.aspx"/>
          </td>
          
          
         </tr>
         </table>   
         
<asp:Button ID="backtoabmproductos" runat="server" Text="Volver"  PostBackUrl="~/abmproductos.aspx" />   

</asp:Content>

