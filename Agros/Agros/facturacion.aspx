<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facturacion.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.facturacion" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Facturaci&oacute;n - Listados</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">

           &nbsp;&nbsp;&nbsp; Listar facturas</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="descripcion" 
                  DataValueField="id" AutoPostBack="True">
              </asp:DropDownList>
          </td>

          <td>
              <p class="meta">

                  &nbsp;&nbsp;&nbsp; Listar clientes</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList2" runat="server" 
                  DataSourceID="ObjectDataSource2" DataTextField="razon_social" 
                  DataValueField="id" AutoPostBack="True">
              </asp:DropDownList>
          </td>




          
          <td>
          
              &nbsp;</td>
          
          
        </tr>  

    
         </table>   

            <asp:GridView ID="dgvDatos" runat="server" AllowPaging="True" 
                DataSourceID="ObjectDataSource3" 
                onselectedindexchanged="dgvDatos_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField HeaderText="Marcar" SelectText="-&gt;" ShowHeader="True" 
                        ShowSelectButton="True" />
                </Columns>
            </asp:GridView>


    <br />
    <asp:Label ID="Label2" runat="server" Text="Ha Seleccionado La Factura N°:"></asp:Label>
    <asp:Label ID="LabelIdF" runat="server" Text=""></asp:Label>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo" 
        onselecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados where tema='facturacion' " Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    
    
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo" 
        onselecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from cliente " Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>


<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
    SelectMethod="Seleccion_por_multiple_condicion" TypeName="Agros.linkeo" 
        InsertMethod="insercion_de_dataset" 
        onselecting="ObjectDataSource2_Selecting" 
        UpdateMethod="actualizacion_de_dataset">
        <UpdateParameters>
            <asp:Parameter Name="tabla" Type="String" />
            <asp:Parameter Name="id" Type="String" />
            <asp:Parameter Name="campos_y_valores" Type="Object" />
        </UpdateParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="select f.id as 'id',f.fecha as 'Fecha', cli.razon_social as 'Razon Social', f.iva as 'Iva', f.iibb as 'IIBB', f.total as 'Total Factura'
                                        from facturas f, cliente cli 
                                        where 1=1 and f.id_cliente=cli.id and f.id_cliente=" 
                Name="consulta" Type="String" />

        
            <asp:ControlParameter ControlID="DropDownList2" 
                
                Name="cond1" PropertyName="SelectedValue" Type="String" DefaultValue="0" />
    
    <asp:Parameter DefaultValue=" and 1=1 and f.id_estado=" Name="cond2" Type="String" />                
        
        <asp:ControlParameter ControlID="DropDownList1" 
                
                Name="cond3" PropertyName="SelectedValue" Type="String" DefaultValue="0" />                
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="tabla" Type="String" />
            <asp:Parameter Name="campos" Type="Object" />
            <asp:Parameter Name="valores" Type="Object" />
        </InsertParameters>
    </asp:ObjectDataSource>
















   <table>   
         <tr>
           <td>
              <p class="meta">
              <asp:ImageButton ID="InfComoPag" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" 
                      onclick="InfComoPag_Click" />
                  Aceptar Pago &nbsp;&nbsp;&nbsp;</p>
	      </td>
	      
	      <td>
              <p class="meta">
              <asp:ImageButton ID="DesinfPago" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" 
                      onclick="DesinfPago_Click" />
                  Rechazar Pago&nbsp;&nbsp;&nbsp;</p>
	      </td>
	      
          <td>
              <p class="meta">
              <asp:ImageButton ID="Incons" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" onclick="Incons_Click" 
                      style="width: 13px" />
               Inconsistencias&nbsp;&nbsp;&nbsp;</p>
	      </td>
	      	      

	      
	       <td>
              <p class="meta">
              <asp:ImageButton ID="VerD" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" onclick="VerD_Click" 
                      style="width: 9px" />
               Editar/Ver Detalles &nbsp;&nbsp;&nbsp;</p>
	      </td>	      
	      
	      
         </tr>
         
   
         
         
         

         </table>

    <asp:Label ID="Label1" runat="server" ForeColor="DarkKhaki" 
        Text="Comentarios De La Operacion:"></asp:Label>
    <br />
    <asp:Label ID="LabelInfo" runat="server" ForeColor="Red" Text=""></asp:Label>
 


</asp:Content>
