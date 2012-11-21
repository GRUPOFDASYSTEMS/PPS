<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_cliente_listados.aspx.cs" MasterPageFile="~/Site1.Master"  Inherits="Agros.modulo_servicios_cliente_listados" %>






<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado De Ordenes De Servicios:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Filtrar Ordenes:</p>
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
        DataSourceID="ObjectDataSource2">
    </asp:GridView>
         
         
         

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados where tema='ordenes_servicio' " Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>




<%--doble parametro de entrada, para el select--%>

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
    SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo" 
        InsertMethod="insercion_de_dataset" 
        onselecting="ObjectDataSource2_Selecting" 
        UpdateMethod="actualizacion_de_dataset">
        <UpdateParameters>
            <asp:Parameter Name="tabla" Type="String" />
            <asp:Parameter Name="id" Type="String" />
            <asp:Parameter Name="campos_y_valores" Type="Object" />
        </UpdateParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from orden_de_servicio where id_cliente=@param1 and id_estado=" 
                Name="consulta" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" 
                
                Name="id" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="tabla" Type="String" />
            <asp:Parameter Name="campos" Type="Object" />
            <asp:Parameter Name="valores" Type="Object" />
        </InsertParameters>
    </asp:ObjectDataSource>

         
         
         
         (ejemplo)
         <table>   
         <tr>
          <td>
            
              <p class="meta">
               1&nbsp;&nbsp;&nbsp;</p>
          </td>
          
           <td>
            
              <p class="meta">
               01/10/2012&nbsp;&nbsp;&nbsp;</p>
          </td>         
          
          
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
              Informar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	                <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
               Desinformar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	      
	      
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton3" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
               Aprobar &nbsp;&nbsp;&nbsp;</p>
	      </td>	      
	      
	      
	      
	       <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton4" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
               Desaprobar &nbsp;&nbsp;&nbsp;</p>
	      </td>
	      
	       <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton5" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" PostBackUrl="~/modulo_servicios_listado_detalle_orden.aspx" />
               Editar &nbsp;&nbsp;&nbsp;</p>
	      </td>	      
	      
	      
         </tr>
         
   
         
         
         

         </table>   
  
    </form>
</asp:Content>
