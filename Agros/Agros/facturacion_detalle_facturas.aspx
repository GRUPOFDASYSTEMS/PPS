<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facturacion_detalle_facturas.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.facturacion_detalle_facturas" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Detalle de factura</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">

              &nbsp;&nbsp;&nbsp; Numero factura</p>
	      </td>
          <td>
          001-0000106
          </td>  

          <td>
              <p class="meta">

              &nbsp;&nbsp;&nbsp; Cliente</p>
	      </td>
          
          <td>
          Agromendoza SRL
          </td>
        </tr>  

    
         </table>   

(ejemplo)
   <table>   
         <tr>
          <td>
            
              <p class="meta">
               Detalle Item&nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               Monto Unitario&nbsp;&nbsp;&nbsp;</p>
          </td>         
          
           <td>
            
              <p class="meta">
               Cantidad &nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               Total Item&nbsp;&nbsp;&nbsp;</p>
          </td>         
                    
          
         </tr>
         
         <tr>
          <td>
            
              <p class="meta">
               Desratizacion&nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               500&nbsp;&nbsp;&nbsp;</p>
          </td>         
          
           <td>
            
              <p class="meta">
               100 &nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               50000&nbsp;&nbsp;&nbsp;</p>
          </td>         
                 
                 
         <tr>
          <td>
            
              <p class="meta">
               Riego&nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               2000&nbsp;&nbsp;&nbsp;</p>
          </td>         
          
           <td>
            
              <p class="meta">
               10&nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               20000&nbsp;&nbsp;&nbsp;</p>
          </td>         
                    
          
         </tr>
                    
          
         </tr>
   
         
         
         

         </table>

    <asp:Button ID="Button1" runat="server" Text="Volver" PostBackUrl="~/facturacion_listados.aspx" />

    </form>
</asp:Content>
