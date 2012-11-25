<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_cliente_home.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.modulo_servicios_cliente_home" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Modulo Servicios - Cliente</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Nuevo" PostBackUrl="~/modulo_servicios_cliente.aspx"/>
              &nbsp;&nbsp;&nbsp; Nueva Orden De Servicio</p>
	      </td>
	      <td>  
	      
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" PostBackUrl="~/modulo_servicios_cliente_listados.aspx"/>
              &nbsp;&nbsp;&nbsp; Listado De Ordenes De Servicio</p>
          </td>
          <td> 
            
          </td>
         </tr>
         <tr> 
          <td>

          </td>
         </tr>
         </table>   
    <asp:Button ID="volver" runat="server" Text="Volver" PostBackUrl="~/indice_cliente.aspx" />
    </form>
</asp:Content>
