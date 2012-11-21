<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facturacion_detalle_facturas.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.facturacion_detalle_facturas" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Detalle de factura</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">

                  &nbsp;&nbsp;&nbsp; Numero factura</p>
	      </td>
          <td>
              001-0000106<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
          </td>  

          <td>
              <p class="meta">

                  &nbsp;&nbsp;&nbsp; Cliente</p>
	      </td>
          
          <td>
              Agromendoza SRL<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
          </td>
        </tr>  

    
         </table>   

    <asp:GridView ID="dgvDatos" runat="server" DataSourceID="ObjectDataSource1">
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from detalle_de_facturas where 1=1 and id_factura=" 
                Name="consulta" Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="id" SessionField="id_factura" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:Button ID="Button1" runat="server" Text="Volver" PostBackUrl="~/facturacion_listados.aspx" />


</asp:Content>
