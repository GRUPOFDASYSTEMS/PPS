<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro_usuarios.aspx.cs" MasterPageFile="~/menu_administrador.master" Inherits="Agros.registro_usuarios" %>
<%@ Register Src="Controles/ControlNum.ascx" TagName="ControlN" TagPrefix="CN"%>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Registro De Usuarios:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Nombre Completo:</p>
	      </td>
	      <td>  
              <asp:TextBox ID="nom" runat="server"></asp:TextBox>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Perfil:</p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="descripcion" 
                  DataValueField="id">
              </asp:DropDownList> 
          </td>
         </tr>
         
         
       
         
         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Clave:</p>
          </td>
          <td> 
            <CN:ControlN runat="server" ID="clave" />
              
          </td>
         </tr>         
         
         

         
         
         
         <tr> 
          <td>
              <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                  SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
                  <SelectParameters>
                      <asp:Parameter DefaultValue="select * from perfiles where id<>3" Name="consulta" 
                          Type="String" />
                  </SelectParameters>
              </asp:ObjectDataSource>
              <asp:Button ID="Button1" runat="server" Text="Registrar" 
                  onclick="Button1_Click" />       
          </td>
         </tr>
         </table>   


</asp:Content>
