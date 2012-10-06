<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro_clientes.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.registro_clientes" %>











<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Registro De Clientes:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp; CUIT:</p>
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
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Raz&oacute;n social:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>   
          </td>
         </tr>         
         
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Direcci&oacute;n:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>   
          </td>
         </tr>         
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Condici&oacute;n Fiscal:</p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList1" runat="server">
              </asp:DropDownList>     
          </td>
         </tr>         
         
         
         
         <tr> 
          <td>
              <asp:Button ID="Button1" runat="server" Text="Ingresar" />       
          </td>
         </tr>
         </table>   
<asp:Button ID="Button2" runat="server" Text="Cancelar" />    
    </form>
</asp:Content>
