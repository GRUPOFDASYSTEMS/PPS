<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_in.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmservicios_in" %>










<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
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
          <input id="Reset1" type="reset" value="Limpiar" />
         </td>
           
         <td>
         <asp:Button ID="Button1" runat="server" Text="Agregar" />
         </td>
         
         </tr>
         
         
         </table>   


    
<asp:Button ID="backtoabmservicios" runat="server" Text="Volver"  PostBackUrl="~/abmservicios.aspx"  />   

    </form>
</asp:Content>