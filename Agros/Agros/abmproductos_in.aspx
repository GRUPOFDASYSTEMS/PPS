<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmproductos_in.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmproductos_in" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Alta De Productos </a></h2>


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
                  Unidad Medida:
                </p>
          </td>
          <td> 
              <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="descripcion" 
                  DataValueField="id" >
              </asp:DropDownList>
          </td>
         </tr>
         <tr> 
          <td>
              <p class="meta">
                  Racion Unidad Medida:
                </p>
          </td>
          <td>
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          
          </td>
          
          
         </tr>
         
         <tr>
         <td>
              <p class="meta">
                  Stock inicial:
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
         </td>

        </tr>
         <tr>
         <td>
              <p class="meta">
                  Indice reposicion:
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
         </td>

        </tr>
         <tr>
         <td>
              <p class="meta">
                  Comentarios:
                </p>
         
         
         </td>
         <td>
         
             <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
         </td>


         
         </tr>
         
         
         <tr>
         <td>
              
         </td>
             
         <td>
         <asp:Button ID="Button1" runat="server" Text="Agregar" onclick="Button1_Click" />
         <input id="Reset1" type="reset" value="Limpiar" /> 
             <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                 SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
                 <SelectParameters>
                     <asp:Parameter DefaultValue="select * from unidad_medida" Name="consulta" 
                         Type="String" />
                 </SelectParameters>
             </asp:ObjectDataSource>
            l1 <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            l2 <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
         </td>
         
         </tr>
         
         
         </table>   


    

<asp:Button ID="backtoabmproductos" runat="server" Text="Volver"  PostBackUrl="~/abmproductos.aspx" />   

</asp:Content>
