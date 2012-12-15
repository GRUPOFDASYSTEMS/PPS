<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulo_servicios_listado_detalle_orden.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.modulo_servicios_listado_detalle_orden" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Detalles De Orden De Servicio:</a></h2>







    





    <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="dgvDatos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField HeaderText="Marcar" SelectText="-&gt;" 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:Label ID="LabelIds" runat="server" Text=""></asp:Label>    
    
    
    <asp:GridView ID="dgvDatosServicioEspecifico" runat="server" 
        DataSourceID="ObjectDataSource2" onselectedindexchanged="dgvDatosServicioEspecifico_SelectedIndexChanged" 
         >
        <Columns>
            <asp:CommandField HeaderText="Marcar" SelectText="-&gt;" 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    
    
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <asp:Label ID="LabelSe" runat="server" Text=""></asp:Label>

    <br />
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select dos.id, 
                                            isnull(ds.descripcion,'') as 'Servicio Especifico', 
                                            dos.fecha_inicio as 'Fecha Inicio', 
                                            dos.fecha_fin as 'Fecha Final', 
                                            dos.cantidad as 'Cantidad Hectareas', 
                                            dos.costo as 'Precio Del Servicio', 
                                            dos.comentario as 'Comentario', 
                                            e.descripcion as 'Estado' 

                                            from detalle_orden_de_servicio dos, estados e, detalle_servicio ds


                                            where ds.id=dos.id_detalle_servicio
                                            and e.id=dos.id_estado and dos.id_os=" Name="consulta" 
                Type="String" />
            <asp:SessionParameter DefaultValue="" Name="id" SessionField="id_os" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
         
         
  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_por_id_y_consulta" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select dos.id, 
                                        isnull(s.nombre_servicio,'') as 'Pack Servicio', 
                                        dos.fecha_inicio as 'Fecha Inicio', 
                                        dos.fecha_fin as 'Fecha Final', 
                                        dos.cantidad as 'Cantidad Hectareas', 
                                        dos.costo as 'Precio Del Servicio', 
                                        dos.comentario as 'Comentario', 
                                        e.descripcion as 'Estado' 

                                        from detalle_orden_de_servicio dos, estados e, servicio s
                                        where s.id=dos.id_servicio
                                        and e.id=dos.id_estado and dos.id_os=" Name="consulta" 
                Type="String" />
            <asp:SessionParameter DefaultValue="" Name="id" SessionField="id_os" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
         
         
         
         
         
         

         
    <asp:Button ID="Aprobar" runat="server" Text="~ Aprobar ~" 
        onclick="Aprobar_Click" />     
         
    <asp:Button ID="Desaprobar" runat="server" Text="¬¬ Desaprobar ¬¬" 
        onclick="Desaprobar_Click" />    
    <br />

    <asp:TextBox ID="comentario" runat="server"></asp:TextBox>
         
    <asp:Button ID="com" runat="server" Text="'' Dejar Comentario ''" 
        onclick="com_Click" />   
    <br />
    
<asp:Button ID="Button2" runat="server" Text="Volver" PostBackUrl="~/modulo_servicios_cliente_listados.aspx" />  

<br />
<asp:Label ID="Label3" runat="server" Text="Comentarios De La Operacion :" ForeColor="DarkKhaki" ></asp:Label>         
<br />
<asp:Label ID="LabelInfo" runat="server" Text="" ForeColor="Red" ></asp:Label>         
<br />


  
    </form>
</asp:Content>

