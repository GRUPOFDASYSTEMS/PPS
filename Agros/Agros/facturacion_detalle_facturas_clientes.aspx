<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facturacion_detalle_facturas_clientes.aspx.cs" MasterPageFile="~/Site1.master" Inherits="Agros.facturacion_detalle_facturas" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Detalle de factura</a></h2>


<form id="formc" runat="server">


<table>
    <tr>
    <td>

        <table>
         <tr>
          <td>
              <p class="meta">

                  &nbsp;&nbsp;&nbsp; Numero factura</p>
	      </td>
          <td>
              <asp:Label ID="id_factura" runat="server" Text=""></asp:Label>
          </td>  

          <td>
              <p class="meta">

                  &nbsp;&nbsp;&nbsp; Cliente</p>
	      </td>
          
          <td>
              <asp:Label ID="cliente" runat="server" Text=""></asp:Label>
          </td>
        </tr>  

    
         </table>   

    </td>
    </tr>
    <tr>
    <td>

    <asp:GridView ID="dgvDatos" runat="server" DataSourceID="ObjectDataSource1">
    </asp:GridView>
    </td>
    </tr>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from detalle_de_facturas where 1=1 and id_factura=" 
                Name="consulta" Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="id" SessionField="id_factura" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <tr>
    <td>
    <asp:Button ID="VolverC" runat="server" Text="Volver a la lista de facturas" PostBackUrl="~/facturacion_listados.aspx" />
    
    </td>
    </tr>
</table>
</form>

</asp:Content>
