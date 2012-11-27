<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_listado_detalle.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios_listado_detalle" %>







<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Composicion Servicio - Detalle de servicios </a></h2>

          <p class="meta">
              Asociado al(los) servicio(s):
                    
        <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource1" 
                  onselectedindexchanged="dgvDatos_SelectedIndexChanged" AllowPaging="True">
            <Columns>
                <asp:CommandField SelectText="-&gt;" ShowSelectButton="True" 
                    HeaderText="Marcar" />
            </Columns>
    </asp:GridView>
    


                </p>
                
    <asp:Label ID="Label1" runat="server" Text="Usted Ha Seleccionado El Servicio Especifico: "></asp:Label>
      <asp:Label ID="Label2" runat="server" Text=""></asp:Label>


    <br />
         <asp:Button ID="add" runat="server" Text="Agregar Productos Necesarios" onclick="add_Click"  />     
            <asp:Button ID="ver" runat="server" Text="Ver Productos Necesarios"  onclick="ver_Click" />     
         <asp:Button ID="x" runat="server" Text="Eliminar" onclick="x_Click" />


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from detalle_servicio" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    
    
    
<%--        <table>
         <tr>
        <td>
            <asp:Button ID="Button2" runat="server" Text="*" PostBackUrl="~/abmservicios_ver_productos_necesarios.aspx" />
        </td>

         
         </tr>
         </table>   
--%>

    
            <input id="back" type="button" value="Volver Atras" onclick="history.back();"/>

    
</asp:Content>