<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="servicios_operarios_general.aspx.cs" Inherits="Agros.servicios_operarios_general" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_in.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmservicios_in" %>










<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado De Servicios </a></h2>

filtrar...
        <table>
         <tr>
          <td>
              <p class="meta">
              Nombre Servicio:
                 </p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              Descripcion:
                </p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
              ver detalles
          </td>
         </tr>
         <tr>
         <td>
          
         </td>
         
         <td>
         
         </td>
         
         </tr>
         
         
         </table>   


    


    </form>
</asp:Content>