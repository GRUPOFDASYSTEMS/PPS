<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmproductos.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmproductos" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Productos (ABM)</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Nuevo" PostBackUrl="~/abmproductos_in.aspx"/>
              &nbsp;&nbsp;&nbsp; Alta De Productos</p>
	      </td>
	      <td>  
	      
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" PostBackUrl="~/abmproductos_listados.aspx"/>
              &nbsp;&nbsp;&nbsp; Edicion Productos (Modificacion/Baja)</p>
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
