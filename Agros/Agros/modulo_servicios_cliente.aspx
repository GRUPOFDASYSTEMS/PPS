<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_cliente.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.modulo_servicios_cliente" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Nueva Orden De Servicio:</a></h2>


        <table>

            
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; A Realizarse En Fecha (Propuesta):</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>   
          </td>
         </tr>
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentarios:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>   
          </td>
         </tr>         
         
         
         

         
         

         
         
         
         <tr> 
          <td>
              <asp:Button ID="Button1" runat="server" Text="Registrar" />       
          </td>
         </tr>
         </table>   
<asp:Button ID="Button2" runat="server" Text="Cancelar" />    
    </form>
</asp:Content>
