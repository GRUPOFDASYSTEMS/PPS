<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listar_clientes.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.listar_clientes" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Listar Clientes:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Filtrar estados:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1">
              </asp:DropDownList>
          </td>
        </tr>  
            
        </table>
        

    (ejemplo)
        <table>
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Razón Social</p>
          </td>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Cuit</p>
          </td>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Estado</p>
          </td>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Confianza</p>
          </td>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Favorito</p>
          </td>
          <td>
              Set
          </td>
         </tr>












         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Agromendoza SRL</p>
          </td>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; 307891234568</p>
          </td>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Activo</p>
          </td>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; 150000</p>
          </td>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Gabriel Bielsa</p>
          </td>
          <td>
              <asp:Button ID="Button1" runat="server" Text="Configurar" PostBackUrl="~/configurar_cliente.aspx" />       
          </td>
         </tr>
         </table>  
         
    <asp:GridView ID="dgvDatos" runat="server" DataSourceID="ObjectDataSource1" >
    
    </asp:GridView>        
          
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_estados" TypeName="Agros.linkeo">
    </asp:ObjectDataSource>

<asp:Button ID="btnMostrar" runat="server" Text="mostrar" />  
         
<asp:Button ID="Button2" runat="server" Text="Volver" />    

</asp:Content>

