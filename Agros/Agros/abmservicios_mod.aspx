<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_mod.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmservicios_mod" %>












<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Modificacion de servicios </a></h2>


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
          </td>
         </tr>
         <tr>
         <td>
            <asp:Button ID="Button1" runat="server" Text="Eliminar" />     
         </td>
         
         <td>
         <asp:Button ID="Button2" runat="server" Text="Modificar" />
         </td>
         
         </tr>
         
         
         </table>   


    <asp:Button ID="Button3" runat="server" Text="Cancelar" />


    </form>
</asp:Content>