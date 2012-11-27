<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_detalle_in.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios_detalle_in" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
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
              <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="nombre_servicio" 
                  DataValueField="id" 
                  >
              </asp:DropDownList>          </td>
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


         </tr>
         
         <tr>
         <td>
             &nbsp;</td>
         
         <td>
             &nbsp;</td>
         
         </tr>
         
         
         </table>   

    <asp:Button ID="backtoabmservicios" runat="server" Text="Volver"  PostBackUrl="~/abmservicios.aspx"/>
    <asp:Button ID="salvar" runat="server" Text="Salvar" onclick="Button2_Click" />

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from servicio" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    
</asp:Content>