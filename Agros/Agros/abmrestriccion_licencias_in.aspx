<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmrestriccion_licencias_in.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmrestriccion_licencias_in" %>






<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Alta de licencias de personal </a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              FechFecha:
                 </p>
	      </td>
	      <td>  
              <asp:Calendar ID="Calendar1" runat="server" 
                  onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
              <asp:Label ID="Label2" runat="server" Text="Fecha Seleccionada:"></asp:Label>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
                  Usuario:      </p>
          </td>
          <td> 
                  <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="nombre" 
                  DataValueField="id" 
                  >
              </asp:DropDownList>

          </td>
         </tr>
         <tr> 
          <td>
              <p class="meta">
              Tiempo (inicial):
                </p>
          </td>
          <td>
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          
          </td>
          
          
         </tr>
         
         <tr>
         <td>
              <p class="meta">
              Tiempo (final):
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
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
            <asp:Button ID="Button1" runat="server" Text="Limpiar" />     
         </td>
         
         <td>
         <asp:Button ID="Button2" runat="server" Text="Agregar" onclick="Button2_Click" />
         </td>
         
         </tr>
         
         
         </table>   


    
    <%--<asp:Button < input type=button  ID="back" runat="server"     Text="Cancelar" onclick="history.back()"   />   --%>
    
    <input id="Button3" type="button" value="Cancelar" onclick="history.back()" />
    <asp:Label ID="Label1" runat="server" Text="L1"></asp:Label>
 
 <asp:Label ID="Label3" runat="server" Text="L3"></asp:Label>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from usuario" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>   
    </form>
 

    </asp:Content>