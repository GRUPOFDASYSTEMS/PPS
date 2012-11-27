<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indice_cliente.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.indice_cliente" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Indice De Modulos Clientes </a></h2>


        <table>
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Productos" PostBackUrl="~/modulo_servicios_cliente_home.aspx" />
                       &nbsp;&nbsp;&nbsp; Modulo De Servicios</p>
          </td>
        </tr>  
            
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton6" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Stock" PostBackUrl="~/registro_clientes.aspx"/>
                       &nbsp;&nbsp;&nbsp; Editar Info Personal</p>
          </td>         
         
         
         
         </tr>   
            
            
            
            
            
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton5" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Facturacion" PostBackUrl="~/facturacion_listados.aspx"/>
                       &nbsp;&nbsp;&nbsp; Modulo De Facturacion</p>
          </td>         
         </tr>
         
         
         </table>   


    <asp:Button ID="Salir" runat="server" Text="Salir" onclick="Salir_Click" />


    </form>
</asp:Content>