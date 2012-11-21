<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_listado.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmservicios_listado" %>












<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Listado De Servicios </a></h2>



    <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="dvgDatos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="X" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from servicio" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>



        <table>
         <tr>
          <td>
              <asp:Button ID="Button1" runat="server" Text=".." PostBackUrl="~/abmservicios_mod.aspx" />      
          </td>

          <td>
              <asp:Button ID="Button2" runat="server" Text="*" PostBackUrl="~/abmservicios_listado_detalle.aspx" />            
          </td>

         
         </tr>
         

         
         
         </table>   


         
<asp:Button ID="backtoabmservicios" runat="server" Text="Volver A Servicios"  PostBackUrl="~/abmservicios.aspx" />
<input id="back" type="button" value="Volver Atras" onclick="history.back();"/>
    


    
</asp:Content>