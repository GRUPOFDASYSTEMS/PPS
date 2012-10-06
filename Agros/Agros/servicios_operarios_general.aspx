<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="servicios_operarios_general.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.servicios_operarios_general" %>











<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado De Servicios Que Me Afectan</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Filtrar estados:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server">
              </asp:DropDownList>
          </td>
        </tr>  
            
        </table>
        

(ejemplo)
        <table>
        <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Fecha</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Servicio a realizar</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Estado</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Raz&oacute;n Social</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentario Del Cliente</p>
          </td>
          
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Composici&oacute;n</p>
          </td>
          
          
          
          
         </tr>

        <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; 01/10/2012</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Limpieza Integral</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Pendiente</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Agromendoza SRL</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; No olvidar quitar trampas anteriores.</p>
          </td>
          
          <td>
              <asp:Button ID="Button1" runat="server" Text=".." PostBackUrl="~/servicios_operario_detalle.aspx" />
          </td>
                    
          
          
         </tr>
         
         
         </table>   


    


    </form>
</asp:Content>