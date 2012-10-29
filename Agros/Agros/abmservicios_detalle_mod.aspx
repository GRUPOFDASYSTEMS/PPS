<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_detalle_mod.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios_detalle_mod" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Modificacion de Detalle de servicios </a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              Descripcion:
                 </p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              Asociado al servicio:
                </p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList2" runat="server">
              </asp:DropDownList>
          </td>
         </tr>
         <tr> 
          <td>
              <p class="meta">
              Tiempo (en horas hombre):
                </p>
          </td>
          <td>
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          
          </td>
          
          
         </tr>
         
         <tr>
         <td>
              <p class="meta">
              Precio:
                </p>
         
         
         </td>
         
         
         
         
         <td>
         
             <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
         </td>


        <td>
               <p class="meta">
            Productos Necesarios
            </p>
            <asp:Button ID="pn" runat="server" Text="*" PostBackUrl="~/abmservicios_ver_productos_necesarios.aspx" />  
        </td>


         </tr>
         
         <tr>
         
         <td>
         <asp:Button ID="modi" runat="server" Text="Modificar" />
         </td>
         
         </tr>
         
         
         </table>   


    <asp:Button ID="Button3" runat="server" Text="Cancelar"  PostBackUrl="~/abmservicios_listado_detalle.aspx"/>


    
</asp:Content>