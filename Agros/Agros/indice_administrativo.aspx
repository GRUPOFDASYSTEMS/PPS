<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indice_administrativo.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.indice_administrativo" %>






<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Indice De Modulos Administrativos </a></h2>


        <table>
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Productos" />
              &nbsp;&nbsp;&nbsp; Modulo De Productos</p>
          </td>
        </tr>  
            
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton6" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Stock" />
              &nbsp;&nbsp;&nbsp; Modulo De Stock</p>
          </td>         
         
         
         
         </tr>   
            
            
            
            
            
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Servicios" />
              &nbsp;&nbsp;&nbsp; Modulo De Servicios</p>
          </td>
         </tr>
         <tr> 
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton3" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Personal" />
              &nbsp;&nbsp;&nbsp; Modulo De Personal</p>
          </td>
          
          
         </tr>
         
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton4" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Clientes" />
              &nbsp;&nbsp;&nbsp; Modulo De Clientes</p>
          </td>

         </tr>
         
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton5" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Facturacion" />
              &nbsp;&nbsp;&nbsp; Modulo De Facturacion</p>
          </td>         
         </tr>
         
         
         </table>   


    <asp:Button ID="Button3" runat="server" Text="Salir" />


    </form>
</asp:Content>