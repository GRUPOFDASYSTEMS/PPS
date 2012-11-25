<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_listado_detalle_orden.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.modulo_servicios_listado_detalle_orden" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Detalles De Orden De Servicio:</a></h2>






    <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource2" 
        onselectedindexchanged="dgvDatos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField HeaderText="Marcar" SelectText="-&gt;" 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from detalle_orden_servicio where 1=1 and id_os=" Name="consulta" 
                Type="String" />
            <asp:SessionParameter DefaultValue="" Name="id" SessionField="id_os" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
         
         
         
         
         
         
         
         
         
<asp:Button ID="Button2" runat="server" Text="Volver" PostBackUrl="~/modulo_servicios_cliente_listados.aspx" />    
    </form>
</asp:Content>

