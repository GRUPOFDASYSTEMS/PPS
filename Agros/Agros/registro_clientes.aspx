<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro_clientes.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.registro_clientes" %>











<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Registro De Clientes:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; CUIT:</p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="req"></asp:TextBox>
              <asp:RangeValidator ID="RangeValidator1" runat="server" 
              ControlToValidate="TextBox1" 
              Display="Dynamic" SetFocusOnError="True" 
              ErrorMessage="Solo se permiten numeros sin espacios ni guiones." 
                  MaximumValue="9999999999" MinimumValue="1111111111" 
              
              ></asp:RangeValidator>
              
              
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Clave:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="req"></asp:TextBox>   
          </td>
         </tr>
         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Razón social:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox3" runat="server" ValidationGroup="req"></asp:TextBox>   
          </td>
         </tr>         
         
         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Dirección:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="req"></asp:TextBox>   
          </td>
         </tr>         
         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Condición Fiscal:</p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="descripcion" 
                  DataValueField="id_condicion">
              </asp:DropDownList>     
          </td>
         </tr>         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; E-mail:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox5" runat="server"   ValidationGroup="req"></asp:TextBox>
              <asp:RegularExpressionValidator 
              ControlToValidate="TextBox5" 
              ID="validamail" runat="server"
              
              Display="Dynamic" SetFocusOnError="True" 
                  ErrorMessage="Debe Especificar una dirección de correo válida." 
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  
              <asp:RequiredFieldValidator  ValidationGroup="req" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Requerido"
 controltovalidate="Textbox5" ></asp:RequiredFieldValidator>     
          </td>
         </tr>              
         
         <tr> 
          <td>
              <asp:Button ID="Button1" runat="server" Text="Registrar" 
                  onclick="Button1_Click" />       
              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
              <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                  SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
                  <SelectParameters>
                      <asp:Parameter DefaultValue="select * from condicion_iva" Name="consulta" 
                          Type="String" />
                  </SelectParameters>
              </asp:ObjectDataSource>
          </td>
         </tr>
         </table>   
 <asp:Button ID="backtoindexcliente" runat="server" Text="Volver Al Indice Clientes"  PostBackUrl="~/indice_cliente.aspx" />  

    </form>
</asp:Content>
