<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indice_operario.aspx.cs" MasterPageFile="~/Site1.Master"  Inherits="Agros.indice_operario" %>







<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Indice De Modulos Operarios </a></h2>


        <table>
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Productos" PostBackUrl="~/servicios_operarios_general.aspx" />
                       &nbsp;&nbsp;&nbsp; Modulo De Servicios</p>
          </td>
        </tr>  
            
         <tr>
          <td>
                   <p class="meta">
                <asp:ImageButton ID="ImageButton6" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Stock" PostBackUrl="~/servicios_operario_restriccion_licencias_in.aspx"/>
                       &nbsp;&nbsp;&nbsp; Nueva Peticion Licencia </p>
          </td>         
         
         
         
         </tr>   
            
            
            
            
         
         </table>   


    <asp:Button ID="Salir" runat="server" Text="Salir" onclick="Salir_Click"   />


    </form>
</asp:Content>