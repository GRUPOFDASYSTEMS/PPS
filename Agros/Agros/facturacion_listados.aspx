<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facturacion_listados.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.facturacion_listados" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Facturaci&oacute;n - Listados</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">

              &nbsp;&nbsp;&nbsp; Listar facturas</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server">
              </asp:DropDownList>
          </td>
          
          <td>
          
              <asp:Button ID="Button1" runat="server" Text="Listar" />
          </td>
          
          
        </tr>  

    
         </table>   

(ejemplo)
   <table>   
         <tr>
          <td>
            
              <p class="meta">
               1&nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               01/10/2012&nbsp;&nbsp;&nbsp;</p>
          </td>         
          
           <td>
            
              <p class="meta">
               Vinos Mendoza&nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               $45678.90&nbsp;&nbsp;&nbsp;</p>
          </td>         
                    
          
                   
           <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
              Informar Como Pagada &nbsp;&nbsp;&nbsp;</p>
	      </td>
	                <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
               Desinformar Pago&nbsp;&nbsp;&nbsp;</p>
	      </td>
	      
	      

	      
	       <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton5" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" PostBackUrl="~/facturacion_detalle_facturas.aspx" />
               Ver Detalles &nbsp;&nbsp;&nbsp;</p>
	      </td>	      
	      
	      
         </tr>
         
   
         
         
         

         </table>

    
    <asp:Button ID="backtoindexcliente" runat="server" Text="Volver Al Indice Clientes"  PostBackUrl="~/indice_cliente.aspx" />
    <asp:Button ID="backtoindexusuario" runat="server" Text="Volver Al Indice Usuarios"  PostBackUrl="~/indice_administrativo.aspx" />
    

</asp:Content>
