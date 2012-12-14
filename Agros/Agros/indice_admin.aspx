<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indice_admin.aspx.cs" MasterPageFile="~/menu_administrador.master" Inherits="Agros.indice_admin" %>









<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Indice De Modulos Administradores </a></h2>


        <table>
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Productos" PostBackUrl="~/abmusuarios.aspx"/>
                       &nbsp;&nbsp;&nbsp; Modulo De Usuarios</p>
          </td>
        </tr>  
            
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton6" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Stock" PostBackUrl="~/indice_administrativo.aspx" />
                       &nbsp;&nbsp;&nbsp; Modulos Administrativos </p>
          </td>         
         
         
         
         </tr>   
            
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Stock" PostBackUrl="~/indice_cliente.aspx" />
                       &nbsp;&nbsp;&nbsp; Modulos Clientes </p>
          </td>         
         
         
         
         </tr>   
            
            
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton3" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Stock" PostBackUrl="~/indice_operario.aspx" />
                       &nbsp;&nbsp;&nbsp; Modulos Operarios </p>
          </td>         
         
         
         
         </tr>   
            
         
         </table>   


    <asp:Button ID="Salir" runat="server" Text="Salir" onclick="Salir_Click" />


    
</asp:Content>