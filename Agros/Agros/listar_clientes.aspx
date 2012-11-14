<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listar_clientes.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.listar_clientes" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Listar Clientes:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Filtrar estados:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="descripcion" 
                  DataValueField="id_estado" 
                  onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                  AutoPostBack="True">
              </asp:DropDownList>
          </td>
        </tr>  
            
        </table>
        

              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
         
    <asp:GridView ID="dgvDatos" runat="server" DataSourceID="ObjectDataSource2" 
        AllowPaging="True" AllowSorting="True" >
        <Columns>
            <asp:HyperLinkField HeaderImageUrl="~/images/img10.gif" HeaderText="Configurar" 
                NavigateUrl="~/configurar_cliente.aspx" Text="~" />
        </Columns>
    
    </asp:GridView>        
          
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
<%-- DefaultValue="select c.id_cliente as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id_usuario and c.condicion_iva=i.id_condicion" --%>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
    SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select c.id_cliente as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id_usuario and c.condicion_iva=i.id_condicion and c.id_estado=" 
                Name="consulta" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" 
                
                Name="id" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

<asp:Button ID="btnMostrar" runat="server" Text="mostrar" />  
         
<asp:Button ID="Button2" runat="server" Text="Volver" />    

</asp:Content>

