<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_listado_detalle.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmservicios_listado_detalle" %>







<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Composicion Servicio - Detalle de servicios </a></h2>

          <p class="meta">
              Asociado al servicio:
                </p>
                
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
        <table>
         <tr>
          <td>
              <p class="meta">
              Descripcion:
                 </p>
	      </td>
              <p class="meta">
              Tiempo (en horas hombre):
                </p>
          </td>
          
          
         <td>
              <p class="meta">
              Precio:
                </p>
         
         
         </td>
    
        <td>
            <p class="meta">
            Productos Necesarios
            </p>
        </td>

         <tr>
          <td>
              <p class="meta">
              Desratizacion
                 </p>
	      </td>
	      <td>
              <p class="meta">
              10
                </p>
          </td>
          
          
         <td>
              <p class="meta">
             500
                </p>
         
         
         </td>
    
        <td>
            <asp:Button ID="Button2" runat="server" Text="*" PostBackUrl="~/abmproductos_listados.aspx" />
        </td>

         
         
         </table>   


    
            <asp:Button ID="Button1" runat="server" Text="Volver" />     

    </form>
</asp:Content>