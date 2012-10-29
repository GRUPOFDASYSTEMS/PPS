<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Servicios (ABM)</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Alta" PostBackUrl="~/abmservicios_in.aspx"/>
              &nbsp;&nbsp;&nbsp; Alta De Servicios</p>
	      </td>
	      <td>  
	      
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" PostBackUrl="~/abmservicios_listado.aspx"/>
              &nbsp;&nbsp;&nbsp; Edicion Servicios (Modificacion/Baja)</p>
          </td>
          <td> 
            
          </td>
         </tr>
         <tr> 
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton3" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" PostBackUrl="~/abmservicios_detalle_in.aspx" />
              &nbsp;&nbsp;&nbsp; Alta Detalle De Servicios</p>
          </td>
          
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton4" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" PostBackUrl="~/abmservicios_listado_detalle.aspx"/>
              &nbsp;&nbsp;&nbsp; Modificacion Detalle De Servicios</p>          
          
          </td>
         </tr>
         </table>   


</asp:Content>
