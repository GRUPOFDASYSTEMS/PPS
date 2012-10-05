<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock_listados.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.Stock_listados" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado y consulta de stock:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Filtrar estados:</p>
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
              &nbsp;&nbsp;&nbsp; Producto</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Cantidad</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Unidad Medida</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Indice Reposici&oacute;n</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentario</p>
          </td>
          <td>
              (quiza total segun racion...)
          </td>

          <td>
              Agregar Stock
          </td>

          <td>
              Corregir Stock
          </td>


         </tr>











         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Acido Sulfurico</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; 10</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Litros</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; 4</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Evitar mojar los recipientes (Balde de 5 lts)</p>
          </td>
          <td>
              50 Litros
          </td>
          <td>
              <asp:Button ID="Button1" runat="server" Text="Agregar" />
          </td>
          <td>
              <asp:Button ID="Button2" runat="server" Text="Corregir" />
          </td>
          
          
          
         </tr>
         </table>   
         
<asp:Button ID="Button3" runat="server" Text="Volver" />    
    </form>
</asp:Content>

