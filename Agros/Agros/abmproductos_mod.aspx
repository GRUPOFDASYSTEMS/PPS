<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmproductos_mod.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmproductos_mod" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Edicion De Productos </a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              Descripcion:
                 </p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              Unidad Medida:
                </p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList2" runat="server">
              </asp:DropDownList>
          </td>
         </tr>
         <tr> 
          <td>
              <p class="meta">
              Racion Unidad Medida:
                </p>
          </td>
          <td
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          
          </td>
          
          
         </tr>
         
         <tr>
         <td>
              <p class="meta">
              Stock inicial:
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
         </td>


         <tr>
         <td>
              <p class="meta">
              Indice reposicion:
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
         </td>
        </tr>
        
         <tr>
         <td>
              <p class="meta">
              Comentarios:
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
         </td>


         
         </tr>
         
         
         <tr>
         <td>
            <asp:Button ID="Button1" runat="server" Text="Modificar" />     
         </td>
         
         <td>
         <asp:Button ID="Button2" runat="server" Text="Eliminar" />
         </td>
         
         </tr>
         
         
         </table>   


    <asp:Button ID="Button3" runat="server" Text="Cancelar" />


    </form>
</asp:Content>
