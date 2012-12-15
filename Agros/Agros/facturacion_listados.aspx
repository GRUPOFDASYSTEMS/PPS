<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facturacion_listados.aspx.cs" MasterPageFile="~/Site1.master" Inherits="Agros.facturacion_listados" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Facturación - Listados</a></h2>


	<form id="form1" runat="server">
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


    <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource2" AllowPaging="True" 
        onselectedindexchanged="dgvdatos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField HeaderText="Marcar" SelectText="-&gt;" ShowHeader="True" 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados where tema='facturacion'" 
                Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:Label ID="Label1" runat="server" Text="Ha Seleccionado La Factura: "></asp:Label>
     <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>



    

    
    <br />
    <br />



    

    <asp:Button ID="informar" runat="server" Text="Informar" 
        onclick="informar_Click" />
    <asp:Button ID="desinformar" runat="server" Text="Desinformar" 
        onclick="desinformar_Click" />
    <asp:Button ID="Detalles" runat="server" Text="Ver Detalles" onclick="Detalles_Click" 
         />

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



    
        <asp:Button ID="Button1" runat="server" Text="Volver"  PostBackUrl="~/indice_cliente.aspx"  />

<br />
<asp:Label ID="LabelInfo" runat="server" Text="" ForeColor="Red" ></asp:Label>
    
</form>
    </asp:Content>
