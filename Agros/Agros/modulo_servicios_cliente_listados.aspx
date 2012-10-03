<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_cliente_listados.aspx.cs" MasterPageFile="~/Site1.Master"  Inherits="Agros.modulo_servicios_cliente_listados" %>






<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado De Ordenes De Servicios:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Filtrar Ordenes:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server">
              
           
                
              </asp:DropDownList>
              
              
              
              
              
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
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
              Informar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	                <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
               Desinformar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	      
	      
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton3" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
               Aprobar &nbsp;&nbsp;&nbsp;</p>
	      </td>	      
	      
	      
	      
	       <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton4" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
               Desaprobar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	      
	       <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton5" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" />
               Editar &nbsp;&nbsp;&nbsp;</p>
	      </td>	      
	      
	      
         </tr>
         
   
         
         
         

         </table>   
  
    </form>
</asp:Content>
