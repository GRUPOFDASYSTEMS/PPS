<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="servicios_operarios_general.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.servicios_operarios_general" %>











<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Listado De Servicios Que Me Afectan</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              &nbsp;&nbsp;&nbsp;  Filtrar estados:</p>
	      </td>
	      <td>  
              <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                  DataSourceID="ObjectDataSource1" DataTextField="descripcion" 
                  DataValueField="id">
              </asp:DropDownList>
          </td>
        </tr>  
            
        </table>
        



            <asp:GridView ID="dgvDatos" runat="server" AllowPaging="True" 
                DataSourceID="ObjectDataSource2" 
                onselectedindexchanged="dgvDatos_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField HeaderText="Marcar" SelectText="-&gt;" ShowHeader="True" 
                        ShowSelectButton="True" />
                </Columns>
            </asp:GridView>


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo" 
        onselecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados where tema='detalle_orden' " Name="consulta" 
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
            <asp:Parameter DefaultValue="select c.id as 'id',c.fecha as 'Fecha de ingreso solicitud', c.fecha_inicio as 'Fecha Inicio', e.descripcion as 'Estado', cli.razon_social as 'Razon Social',  c.comentario as 'Comentario Del Cliente' 
                                        from detalle_orden_de_servicio c, orden_de_servicio o, estados e, cliente cli 
                                        where 1=1 and c.id_estado=e.id and c.id_os=o.id and o.id_cliente=cli.id and c.id_usuario=" 
                Name="consulta" Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="cond1" SessionField="usuario" 
                Type="String" />
            <asp:Parameter DefaultValue=" and 1=1 and c.id_estado=" Name="cond2" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" 
                
                Name="cond3" PropertyName="SelectedValue" Type="String" DefaultValue="0" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="tabla" Type="String" />
            <asp:Parameter Name="campos" Type="Object" />
            <asp:Parameter Name="valores" Type="Object" />
        </InsertParameters>
    </asp:ObjectDataSource>

     <asp:Label ID="Label2" runat="server"  Text="Ha seleccionado el item: "></asp:Label>        <asp:Label ID="LabelSe" runat="server"  Text=""></asp:Label>        

    <br />

    <asp:Button ID="PreAprobar" runat="server" Text="~ Pre-Aprobar ~" onclick="PreAprobar_Click" 
         />     
         
   <br />
    <asp:TextBox ID="comentario" runat="server" Height="59px" Width="348px"></asp:TextBox>
         
    <asp:Button ID="com" runat="server" Text="'' Dejar Comentario ''" onclick="com_Click" 
         />

   <br />

    <asp:Label ID="Label1" runat="server" ForeColor="DarkKhaki" 
        Text="Comentarios De La Operacion:"></asp:Label>
    <br />
    <asp:Label ID="LabelInfo" runat="server" ForeColor="Red" Text=""></asp:Label>
 

    <br />


<asp:Button ID="backtoindexoperario" runat="server" Text="Volver"  PostBackUrl="~/indice_operario.aspx"/>    


    </form>
</asp:Content>