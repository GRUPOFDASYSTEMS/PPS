<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_detalle_in.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmservicios_detalle_in" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Alta de Detalle de servicios </a></h2>


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
          <td
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


         </tr>
         
         <tr>
         <td>
            <asp:Button ID="Button1" runat="server" Text="Ver Productos Necesarios"  />     
         </td>
         
         <td>
         <asp:Button ID="Button3" runat="server" Text="Agregar Productos Necesarios" PostBackUrl="~/abmproductos_listados.aspx" />     
         </td>
         
         </tr>
         
         
         </table>   


    <asp:Button ID="Button2" runat="server" Text="Salvar" />


    </form>
</asp:Content>