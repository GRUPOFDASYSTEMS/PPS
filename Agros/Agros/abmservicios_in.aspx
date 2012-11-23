<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_in.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios_in" %>










<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Alta de nuevos servicios </a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  Nombre Servicio:
                 </p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
                  Descripcion:
                </p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          </td>
         </tr>

         <tr>
          <td>
            
              <p class="meta">
                  Descuento:
                </p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox> %
          </td>
         </tr>




         <tr>
         <td>
          <input id="Reset1" type="reset" value="Limpiar" />
         </td>
           
         <td>
         <asp:Button ID="Button1" runat="server" Text="Agregar" onclick="Button1_Click" />
             <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
         </td>
         
         </tr>
         
         
         </table>   


    
<asp:Button ID="backtoabmservicios" runat="server" Text="Volver"  PostBackUrl="~/abmservicios.aspx"  />   

    
</asp:Content>