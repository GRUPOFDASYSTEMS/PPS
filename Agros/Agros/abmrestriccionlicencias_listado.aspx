<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmrestriccionlicencias_listado.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmrestriccionlicencias_listado" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado de licencias de personal </a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              Fecha:
                 </p>
	      </td>
	      <td>
            
              <p class="meta">
              Usuario:
                </p>
          </td>
          <td>
              <p class="meta">
              Tiempo (en horas):
                </p>
          </td>
         <td>
              <p class="meta">
              Descripcion:
                </p>
         
         
         </td>
     
     
     
        <td>
        Modificar
        
        </td>     
     
        <td>
        Eliminar
        
        </td>     
     
     
        </tr>
        
        <tr>
          <td>
              <p class="meta">
              08/10/2012
                 </p>
	      </td>
	      <td>
            
              <p class="meta">
              Favio Andrada
                </p>
          </td>
          <td>
              <p class="meta">
              24
                </p>
          </td>
         <td>
              <p class="meta">
              Feriado Nacional
                </p>
         
         
         </td>
     
             
     
         <td>
            <asp:Button ID="Button1" runat="server" Text=".." PostBackUrl="~/abmrestriccion_licencias_mod.aspx"/>     
         </td>
         
         <td>
         <asp:Button ID="Button2" runat="server" Text="X" />
         </td>
         
         </tr>
         
         
         </table>   


    <asp:Button ID="Button3" runat="server" Text="Volver" PostBackUrl="~/abmrestriccion_licencias.aspx" />


    </form>
</asp:Content>