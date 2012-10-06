<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.login" %>







<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Ingreso al sistema:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Nombre de usuario:</p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Clave:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>   
          </td>
         </tr>
         <tr> 
          <td>
              <asp:Button ID="Button1" runat="server" Text="Ingresar" PostBackUrl="~/indice_admin.aspx" />
          </td>
         </tr>
         </table>   

    </form>
</asp:Content>
