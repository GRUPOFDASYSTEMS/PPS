<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmrestriccion_licencias_in.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmrestriccion_licencias_in" %>






<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Alta de licencias de personal </a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              Fecha:
                 </p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              Usuario:
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
              Tiempo (en horas):
                </p>
          </td>
          <td>
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          
          </td>
          
          
         </tr>
         
         <tr>
         <td>
              <p class="meta">
              Descripcion:
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
         </td>


         </tr>
         
         <tr>
         <td>
            <asp:Button ID="Button1" runat="server" Text="Limpiar" />     
         </td>
         
         <td>
         <asp:Button ID="Button2" runat="server" Text="Agregar" />
         </td>
         
         </tr>
         
         
         </table>   


    
    <asp:Button ID="back" runat="server" Text="Cancelar" onclick="history.back()"   />

    </form>
</asp:Content>