<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_cliente.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.modulo_servicios_cliente" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Nueva Orden De Servicio:</a></h2>


        <table>

            
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Nombre Corto:</p>
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
         
         
         

         
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>         

         
         
         
         <tr> 
          <td>
              <asp:Button ID="Button1" runat="server" Text="Registrar" 
                  onclick="Button1_Click" />       
          </td>
         </tr>
         </table>   
<asp:Button ID="Button2" runat="server" Text="Volver" PostBackUrl="~/modulo_servicios_cliente_home.aspx"/>    
    </form>
</asp:Content>
