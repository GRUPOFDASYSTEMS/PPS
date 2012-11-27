<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_cliente_listados.aspx.cs" MasterPageFile="~/Site1.Master"  Inherits="Agros.modulo_servicios_cliente_listados" %>






<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado De Ordenes De Servicios:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  &amp;nbs&amp;nbs&nbsp;&nbsp;&nbsp; Filtrar Ordenes:</p>
	      </td>
	      <td>  
            <asp:DropDownList ID="DropDownList1" runat="server" 
                  DataSourceID="ObjectDataSource1" DataTextField="descripcion" 
                  DataValueField="id" 
                  onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                  AutoPostBack="True">
              </asp:DropDownList>
              
           
          </td>
        </tr>  
         </table>
         
         
         
    <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource2" AllowPaging="True" 
        onselectedindexchanged="dgvDatos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField HeaderText="Marcar" SelectText="-&gt;" ShowHeader="True" 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
         
         
         

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados where tema='orden_servicio' " Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>




<%--doble parametro de entrada, para el select--%>

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
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
            <asp:Parameter DefaultValue="select c.id as 'id', c.fecha as 'Fecha', c.fecha_solicitud as 'Fecha de solicitud', c.costo_total as 'Costo Total', c.fecha_pago as 'Fecha de pago', c.comentario as 'Comentario' from orden_de_servicio c where 1=1 and id_cliente=" 
                Name="consulta" Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="cond1" SessionField="cliente" 
                Type="String" />
            <asp:Parameter DefaultValue=" and 1=1 and id_estado=" Name="cond2" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" 
                
                Name="cond3" PropertyName="SelectedValue" Type="String" DefaultValue="0" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="tabla" Type="String" />
            <asp:Parameter Name="campos" Type="Object" />
            <asp:Parameter Name="valores" Type="Object" />
        </InsertParameters>
    </asp:ObjectDataSource>

         
         
         
            <asp:Label ID="Label1" runat="server" Text="Usted Selecciono La Orden N: "></asp:Label>
       <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
       <br />
    <asp:Label ID="lerror" runat="server" Text=""></asp:Label>
       <table>   
         <tr>
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" 
                      onclick="ImageButton1_Click" style="width: 13px" />
                  &nbsp;&nbsp;Aprobar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	                <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" 
                      onclick="ImageButton2_Click" style="height: 12px" />
                  &nbsp;&nbsp;Abortar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	       
	      
	       <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton3" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" 
                      onclick="ImageButton3_Click" style="width: 13px;" />
                  &nbsp;&nbsp;Desaprobar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	      
	       <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton4" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" 
                      onclick="ImageButton4_Click"  />
                  &nbsp;&nbsp;Editar &nbsp;&nbsp;&nbsp;</p>
	      </td>	      
	      
	      
         </tr>
         
   
         
         
         

         </table>   
    <asp:Button ID="volver" runat="server" Text="Volver" PostBackUrl="~/modulo_servicios_cliente_home.aspx" />
                                                                        
    </form>
</asp:Content>
