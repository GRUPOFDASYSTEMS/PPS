<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_creando_detalle_orden.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.modulo_servicios_creando_detalle_orden" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Detalles De Orden De Servicio:</a></h2>







         
         
        <table>
         <tr>
          <td>
              <asp:Calendar ID="Calendar1" runat="server" 
                  onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
              
              <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
          <td>
              &nbsp;</td>
          </tr>




         <tr>
          <td>
              <p class="meta">
                  <asp:RadioButton ID="RS" runat="server"  GroupName="r1"  Checked="true" 
                      oncheckedchanged="RS_CheckedChanged" /> &nbsp;&nbsp;&nbsp; Elegir Pack Servicio:<asp:DropDownList 
                      ID="DD_Servicio" runat="server" DataSourceID="ObjectDataSource1" 
                      DataTextField="nombre_servicio" DataValueField="id"  >
              </asp:DropDownList>
              </p>
	      </td>
          <td>
                  <asp:RadioButton ID="RDS" runat="server" GroupName="r1" 
                      oncheckedchanged="RDS_CheckedChanged"  /> Elegir Servicio Especifico:<asp:DropDownList 
                      ID="DDD_Servicio" runat="server" Enabled="False" 
                      DataSourceID="ObjectDataSource2" DataTextField="descripcion" 
                      DataValueField="id">
              </asp:DropDownList>
	      </td>
	      



        </tr>  





            
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Para Cantidad Hectareas():  </p> 
          </td>
          <td>
            
              <asp:TextBox ID="cantidad" runat="server"  Text=""></asp:TextBox>   
          </td>
         </tr>
         
         
         <tr>
          <td style="height: 16px">
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Comentarios Adicionales:</p>
          </td>
          <td style="height: 16px">
            
              <asp:TextBox ID="comentario" runat="server"   Text="" ></asp:TextBox>   
          </td>
          <td style="height: 16px"> 
              &nbsp;</td>
         </tr>         
         
         
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Seleccionar Operario:</p>
          </td>
          <td>
            
              <asp:DropDownList ID="DD_Operario" runat="server" 
                  DataSourceID="ObjectDataSource3" DataTextField="nombre" DataValueField="id"  >
              </asp:DropDownList>

          </td>
          <td> 
              &nbsp;</td>
         </tr>         
                  
         <tr> 
          <td>
                <asp:Button ID="new" runat="server" Text="Nuevo" onclick="new_Click"  />       
             </td>
          <td>
              <asp:Button ID="agregar" runat="server" Text="Agregar" 
                  onclick="agregar_Click" />       
             </td>
         </tr>
         </table>   
         
<asp:Label ID="Label3" runat="server" Text="Detalle De Operacion De Insercion:" ForeColor="DarkKhaki" ></asp:Label>   
<br />   
<asp:Label ID="LabelGeneral" runat="server" Text="" ForeColor="Red" ></asp:Label>         
    <br />
<br />
<asp:Label ID="Label1" runat="server" Text="Otros Comentarios De La Operacion De Insercion:" ForeColor="DarkKhaki" ></asp:Label>         
<br />
<asp:Label ID="LabelInfo" runat="server" Text="" ForeColor="Red" ></asp:Label>         
<br />
              
<asp:Button ID="Button2" runat="server" Text="Finalizar Edicion" PostBackUrl="~/modulo_servicios_cliente_listados.aspx" />    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from servicio" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from detalle_servicio" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from usuario where perfil=3" 
                Name="consulta" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</asp:Content>

