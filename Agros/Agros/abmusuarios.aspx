<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmusuarios.aspx.cs" MasterPageFile="~/menu_administrador.master" Inherits="Agros.abmusuarios" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Usuarios (ABM)</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Alta" PostBackUrl="~/registro_usuarios.aspx" />
              &nbsp;&nbsp;&nbsp; Alta De Usuarios</p>
	      </td>
	      <td>  
	      
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" PostBackUrl="~/listar_usuarios.aspx" />
              &nbsp;&nbsp;&nbsp; Listar Usuarios (Modificacion/Baja)</p>
          </td>
          <td> 
            
          </td>
         </tr>
         <tr> 
          <td>

          </td>
         </tr>
         </table>   


</asp:Content>
