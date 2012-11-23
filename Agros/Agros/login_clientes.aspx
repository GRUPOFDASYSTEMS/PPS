<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_clientes.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.login_clientes" %>









<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Acceso A Clientes:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Legajo (Id):</p>
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
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>   
          </td>
         </tr>
         <tr> 
          <td>
              
          </td>
         </tr>
         </table>   
         
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
              <br />
              <asp:Button ID="Button1" runat="server" Text="Ingresar" 
                  onclick="Button1_Click" />       
         
         
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/registro_clientes.aspx" >Registro</asp:HyperLink>
    </form>
</asp:Content>
