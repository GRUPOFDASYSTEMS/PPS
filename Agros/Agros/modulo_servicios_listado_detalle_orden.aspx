<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_listado_detalle_orden.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.modulo_servicios_listado_detalle_orden" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Detalles De Orden De Servicio:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Servicio Solicitado:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server" readonly="true" Enabled="false">
              </asp:DropDownList>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Detalle Cantidad Hectareas():</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox2" runat="server"   Text="10"></asp:TextBox>   
          </td>
         </tr>
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentarios Adicionales:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox3" runat="server"   Text="Sin pesticidas"></asp:TextBox>   
          </td>
         </tr>         
         
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Costo:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox4" readonly="true" runat="server"  Text="25678" ></asp:TextBox>   
          </td>
         </tr>         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Tiempo Consumido:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox5" readonly="true"  runat="server"  Text="200" ></asp:TextBox>   
          </td>
         </tr>         
                  
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Estado Tarea:</p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList2" runat="server">
              </asp:DropDownList> 
          </td>
         </tr>         

                  <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentarios / Aclaraciones para el cliente:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox6" readonly="true"  runat="server"></asp:TextBox>   
          </td>
         </tr>         

         
         
         <tr> 
          <td>
              <asp:Button ID="Button1" runat="server" Text="Aprobar" />       
          </td>
         </tr>
         </table>   
         
         
        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Servicio Solicitado:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList3" runat="server" readonly="true" Enabled="false">
              </asp:DropDownList>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Detalle Cantidad Hectareas():</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox1" runat="server"  Text="200"></asp:TextBox>   
          </td>
         </tr>
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentarios Adicionales:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox7" runat="server"   Text="Sacar trampas anteriores" ></asp:TextBox>   
          </td>
         </tr>         
         
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Costo:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox8" readonly="true" runat="server"  Text="45500" ></asp:TextBox>   
          </td>
         </tr>         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Tiempo Consumido:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox9" readonly="true"  runat="server"  Text="300" ></asp:TextBox>   
          </td>
         </tr>         
                  
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Estado Tarea:</p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList4" runat="server">
              </asp:DropDownList> 
          </td>
         </tr>         

                  <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentarios / Aclaraciones para el cliente:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox10" readonly="true"  runat="server"></asp:TextBox>   
          </td>
         </tr>         

         
         
         <tr> 
          <td>
              <asp:Button ID="Button3" runat="server" Text="Aprobar" />       
          </td>
         </tr>
         </table>   
         
         
        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Servicio Solicitado:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList5" runat="server" readonly="true" Enabled="false">
              </asp:DropDownList>
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Detalle Cantidad Hectareas():</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox11" runat="server"  Text="40" ></asp:TextBox>   
          </td>
         </tr>
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentarios Adicionales:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox12" runat="server" Text="Reparar Centinelas" ></asp:TextBox>   
          </td>
         </tr>         
         
         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Costo:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox13" readonly="true" runat="server" Text="32370"></asp:TextBox>   
          </td>
         </tr>         
         
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Tiempo Consumido:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox14" readonly="true"  runat="server" Text="100" ></asp:TextBox>   
          </td>
         </tr>         
                  
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Estado Tarea:</p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList6" runat="server">
              </asp:DropDownList> 
          </td>
         </tr>         

                  <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentarios / Aclaraciones para el cliente:</p>
          </td>
          <td> 
              <asp:TextBox ID="TextBox15" readonly="true"  runat="server"></asp:TextBox>   
          </td>
         </tr>         

         
         
         <tr> 
          <td>
              <asp:Button ID="Button4" runat="server" Text="Aprobar" />       
          </td>
         </tr>
         </table>                     
         
         
         
         
         
         
         
         
         
         
         
<asp:Button ID="Button2" runat="server" Text="Volver" PostBackUrl="~/modulo_servicios_cliente_listados.aspx" />    
    </form>
</asp:Content>

