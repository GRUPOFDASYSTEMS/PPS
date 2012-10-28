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
                  &nbsp;&nbsp;&nbsp; Razón social:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>   
          </td>
         </tr>         
         
         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Dirección:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>   
          </td>
         </tr>         
         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Condición Fiscal:</p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList1" runat="server">
              </asp:DropDownList>     
          </td>
         </tr>         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; E-mail:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
              <asp:RegularExpressionValidator 
              ControlToValidate="TextBox5" 
              ID="validamail" runat="server"
              
              Display="Dynamic" SetFocusOnError="True" 
                  ErrorMessage="Debe Especificar una dirección de correo válida." 
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
          </td>
         </tr>              
         
         <tr> 
          <td>
              <asp:Button ID="Button1" runat="server" Text="Registrar" />       
          </td>
         </tr>
         </table>   
 <asp:Button ID="backtoindexcliente" runat="server" Text="Volver Al Indice Clientes"  PostBackUrl="~/indice_cliente.aspx" />  
    </form>
</asp:Content>
