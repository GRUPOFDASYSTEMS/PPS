<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listar_usuarios.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.listar_usuarios" %>








<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado De Usuarios:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Nombre Completo:</p>
	      </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Perfil:</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Estado:</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Clave:</p>
          </td>
          <td> 
              Editar:   
          </td>
          
          <td> 
              Eliminar:   
          </td>
          
          
          
         </tr>         
         

         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Favio Andrada</p>
	      </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Administrador</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Activo</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; **#%?la_54</p>
          </td>
          <td> 
              <asp:Button ID="Button3" runat="server" Text=".." PostBackUrl="~/registro_usuarios.aspx" />              
          </td>
          
          
          <td> 
              <asp:Button ID="Button4" runat="server" Text="X" />              
          </td>
          
         </tr>         















         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Gabriel Bielsa</p>
	      </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Administrativo</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Activo</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; 123456</p>
          </td>
          <td> 
              <asp:Button ID="Button1" runat="server" Text=".." PostBackUrl="~/registro_usuarios.aspx"/>              
          </td>
          
          <td> 
              <asp:Button ID="Button5" runat="server" Text="X" />              
          </td>
          
          
         </tr>         
         

         
         
         
         </table>   
<asp:Button ID="backtoabmusuarios" runat="server" Text="Volver" PostBackUrl="~/abmusuarios.aspx" />    
    </form>
</asp:Content>
