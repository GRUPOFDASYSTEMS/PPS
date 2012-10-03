<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_cliente_detalle.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.modulo_servicios_cliente_detalle" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Generar Orden De Servicio:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Servicio A Solicitar:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server">
              </asp:DropDownList>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Detalle Cantidad Hectareas():</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>   
          </td>
         </tr>
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentarios Adicionales:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>   
          </td>
         </tr>         
         
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Costo:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox4" readonly="true" runat="server"></asp:TextBox>   
          </td>
         </tr>         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Tiempo Consumido:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox5" readonly="true"  runat="server"></asp:TextBox>   
          </td>
         </tr>         
                  

         
         
         
         <tr> 
          <td>
              <asp:Button ID="Button1" runat="server" Text="Agregar" />       
          </td>
         </tr>
         </table>   
<asp:Button ID="Button2" runat="server" Text="Cancelar" />    
    </form>
</asp:Content>

