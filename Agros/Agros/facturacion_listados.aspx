<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facturacion_listados.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.facturacion_listados" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Facturación - Listados</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">

                  &nbsp;&nbsp;&nbsp; Listar facturas</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server"
                  DataSourceID="ObjectDataSource1" DataTextField="descripcion" 
                  DataValueField="id" 
                  onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                  AutoPostBack="True"       
              >
              </asp:DropDownList>
          </td>
          
          
          
        </tr>  
    
         </table>   


    <asp:GridView ID="dgvdatos" runat="server" 
        DataSourceID="ObjectDataSource2">
    </asp:GridView>
    


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados where tema='facturacion'" 
                Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from facturas f  where 1=1 and f.id_estado=" 
            
                Name="consulta" 
                Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="id" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>


    <asp:Button ID="backtoindexcliente" runat="server" Text="Volver Al Indice Clientes"  PostBackUrl="~/indice_cliente.aspx" />
    <asp:Button ID="backtoindexusuario" runat="server" Text="Volver Al Indice Usuarios"  PostBackUrl="~/indice_administrativo.aspx" />
    

</asp:Content>
