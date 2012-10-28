<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="configurar_cliente.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.configurar_cliente" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <form id="form1" runat="server">
    
    <h2 class="title"><a href="#">Configurar Cliente</a></h2>


        <table>
         <tr>
          <td>
	        <p class="meta">Operario Favorito</p> 
	      </td>
	      <td>  
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
          </td>
        </tr>  
            
         <tr>
          <td>
            <p class="meta">Valor De Confianza</p>
          </td>
          <td> 
              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>        
              <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          </td>
         </tr>
         <tr> 
          <td>
          <asp:Button ID="Button1" runat="server" Text="Salvar" />
          </td>
         </tr>
         </table>   
    </form>
    
</asp:Content>