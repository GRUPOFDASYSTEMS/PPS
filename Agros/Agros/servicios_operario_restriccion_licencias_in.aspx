﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="servicios_operario_restriccion_licencias_in.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.servicios_operario_restriccion_licencias_in" %>







<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Alta de licencias de personal </a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  Fecha Inicial:
                 </p>
	      </td>
	      <td>  
              <asp:Calendar ID="Calendar1" runat="server" 
                  onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
              <asp:Label ID="f_in" runat="server" Text="Fecha Seleccionada:"></asp:Label>
          </td>
        </tr>  
            
                <tr>
          <td>
              <p class="meta">
                  Fecha Final:
                 </p>
	      </td>
	      <td>  
              <asp:Calendar ID="Calendar2" runat="server" 
                  onselectionchanged="Calendar2_SelectionChanged"></asp:Calendar>
              <asp:Label ID="f_out" runat="server" Text="Fecha Seleccionada:"></asp:Label>
          </td>
                </tr>
            
         <tr>
          <td>
            
              &nbsp;</td>
          <td> 
                  &nbsp;</td>
         </tr>
            
         <tr>
          <td>
            
              <p class="meta">
                  Usuario: <asp:Label ID="lusuario" runat="server" Text="."></asp:Label>   </p>
          </td>
          <td> 
                  <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="nombre" 
                  DataValueField="id" enabled="false"
                  >
              </asp:DropDownList>

          </td>
         </tr>
         
        <tr>
         <td>
              <p class="meta">
                  Descripcion:
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
         </td>


         </tr>         
         
         
         <tr>
         <td>
            <asp:Button ID="limpiar" runat="server" Text="Limpiar" />     
         </td>
         
         <td>
         <asp:Button ID="agregar" runat="server" Text="Agregar" onclick="Button2_Click" />
         </td>
         
         </tr>
         
         
         </table>   


    
    <%--<asp:Button < input type=button  ID="back" runat="server"     Text="Cancelar" onclick="history.back()"   />   --%>
    
    <input id="Volver" type="button" value="Volver" onclick="history.back()" />
    <asp:Label ID="Label1" runat="server" Text="L1"></asp:Label>
 
 <asp:Label ID="Label3" runat="server" Text="L3"></asp:Label>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from usuario where 1=1 and id=" Name="consulta" 
                Type="String" />
            <asp:SessionParameter DefaultValue="-1" Name="id" SessionField="usuario" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>   
    </form>
 

    </asp:Content>