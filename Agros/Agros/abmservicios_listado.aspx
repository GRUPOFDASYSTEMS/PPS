<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_listado.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmservicios_listado" %>












<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado De Servicios </a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              Nombre Servicio:
                 </p>
	      </td>
          <td>
            
              <p class="meta">
              Descripcion:
                </p>
          </td>
          <td>
            
              <p class="meta">
              Edicion:
                </p>
          </td>

          <td>
            
              <p class="meta">
              Composicion:
                </p>
          </td>

         
         </tr>


         <tr>
          <td>
              <p class="meta">
              Pack Limpieza
                 </p>
	      </td>
          <td>
            
              <p class="meta">
              Paquete de servicio especialmente armado.
                </p>
          </td>
          <td>
              <asp:Button ID="Button1" runat="server" Text=".." PostBackUrl="~/abmservicios_mod.aspx" />      
          </td>

          <td>
              <asp:Button ID="Button2" runat="server" Text="*" PostBackUrl="~/abmservicios_listado_detalle.aspx" />            
          </td>

         
         </tr>
         

         
         
         </table>   


    


    </form>
</asp:Content>