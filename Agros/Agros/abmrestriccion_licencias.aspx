<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmrestriccion_licencias.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmrestriccion_licencias" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="formlicencias" runat="server">
    <h2 class="title"><a href="#">Restricci&oacute;n de licencias(ABM)</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              <asp:ImageButton  runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Nueva" PostBackUrl="~/abmrestriccion_licencias_in.aspx"/>
              &nbsp;&nbsp;&nbsp; Alta De Nueva Restricci&oacute;n</p>
	      </td>
	      <td>  
	      
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              <asp:ImageButton  runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" PostBackUrl="~/abmrestriccionlicencias_listado.aspx"/>
              &nbsp;&nbsp;&nbsp; Edicion De Restricciones (Modificacion/Baja)</p>
          </td>
          <td> 
            
          </td>
         </tr>
         <tr> 
          <td>

          </td>
         </tr>
         </table>   

    </form>
</asp:Content>
