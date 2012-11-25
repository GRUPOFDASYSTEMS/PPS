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
                      oncheckedchanged="RS_CheckedChanged" /> &nbsp;&nbsp;&nbsp; Elegir 
                  Pack Servicio:<asp:DropDownList ID="DD_Servicio" runat="server"  >
              </asp:DropDownList>
              </p>
	      </td>
          <td>
                  <asp:RadioButton ID="RDS" runat="server" GroupName="r1" 
                      oncheckedchanged="RDS_CheckedChanged"  /> Elegir Servicio 
              Especifico:<asp:DropDownList ID="DDD_Servicio" runat="server" Enabled="false">
              </asp:DropDownList>
	      </td>
	      <td>  
              &nbsp;</td>


          <td>
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; </p>
	      </td>
	      <td>  
              &nbsp;</td>



        </tr>  





            
         <tr>
          <td>
            
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Detalle Cantidad Hectareas():  </p> 
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
            
              <asp:DropDownList ID="DD_Operario" runat="server"  >
              </asp:DropDownList>

          </td>
          <td> 
              &nbsp;</td>
         </tr>         
                  
         <tr> 
          <td>
              &nbsp;</td>
          <td>
              <asp:Button ID="agregar" runat="server" Text="Agregar" 
                  onclick="agregar_Click" />       
             </td>
         </tr>
         </table>   
         
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>         
              <asp:Button ID="fin" runat="server" Text="Finalizar Edicion" />       
<asp:Button ID="Button2" runat="server" Text="Volver" PostBackUrl="~/modulo_servicios_cliente_listados.aspx" />    
    </form>
</asp:Content>

