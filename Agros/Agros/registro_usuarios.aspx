<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro_usuarios.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.registro_usuarios" %>






<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Registro De Usuarios:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Nombre Completo:</p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Perfil:</p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList1" runat="server">
              </asp:DropDownList> 
          </td>
         </tr>
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Estado:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>   
          </td>
         </tr>         
         
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Clave:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>   
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
