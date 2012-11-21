<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock_listados.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.Stock_listados" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Listado y consulta de stock:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  &amp;&nbsp&nbsp;&nbsp;&nbsp; Filtrar estados:</p>
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
                  onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="-&gt;" 
                ShowSelectButton="True" HeaderText="Marcar" ShowHeader="True" />
        </Columns>
    </asp:GridView>

        





    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados where tema='stock'" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>





    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
    SelectMethod="Seleccion_segun_id_para_consultar" TypeName="Agros.linkeo" 
        InsertMethod="insercion_de_dataset" 
        onselecting="ObjectDataSource2_Selecting" 
        UpdateMethod="actualizacion_de_dataset">
        <UpdateParameters>
            <asp:Parameter Name="tabla" Type="String" />
            <asp:Parameter Name="id" Type="String" />
            <asp:Parameter Name="campos_y_valores" Type="Object" />
        </UpdateParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="SELECT     p.id, p.descripcion AS 'Producto', u.descripcion AS 'Unidad De  Medida', p.comentario AS 'Comentario', s.indice_repo AS 'Indice de  reposición', 
                      s.cantidad - SUM(r.racion_unidad_medida) AS 'Stock Disponible', s.comentario AS 'Detalle  Stock'
FROM         unidad_medida AS u INNER JOIN
                      productos AS p ON u.id = p.unidad_medida INNER JOIN
                      stock AS s ON p.id = s.id_producto INNER JOIN
                      reservas_stock AS r ON p.id = r.id_producto
GROUP BY p.id, p.descripcion, u.descripcion, p.comentario, s.indice_repo, s.cantidad, s.comentario " 
                Name="consulta1" Type="String" />
            <asp:Parameter DefaultValue="SELECT     p.id, p.descripcion AS 'Producto', u.descripcion AS 'Unidad De  Medida', p.comentario AS 'Comentario', s.indice_repo AS 'Indice de  reposición', 
                      SUM(r.racion_unidad_medida) AS 'Stock Reservado', s.comentario AS 'Detalle  Stock'
FROM         unidad_medida AS u INNER JOIN
                      productos AS p ON u.id = p.unidad_medida INNER JOIN
                      stock AS s ON p.id = s.id_producto INNER JOIN
                      reservas_stock AS r ON p.id = r.id_producto
GROUP BY p.id, p.descripcion, u.descripcion, p.comentario, s.indice_repo, s.cantidad, s.comentario"
                Name="consulta2" Type="String" />
            <asp:Parameter DefaultValue="SELECT     p.id, p.descripcion AS 'Producto', u.descripcion AS 'Unidad De Medida', p.comentario AS 'Comentario', s.indice_repo AS 'Indice de reposición', 
                      s.cantidad AS 'Stock Total (En Deposito)',  s.comentario AS 'Detalle Stock'
FROM         stock AS s INNER JOIN
                      productos AS p ON s.id_producto = p.id INNER JOIN
                      unidad_medida AS u ON p.unidad_medida = u.id
GROUP BY p.id, p.descripcion, u.descripcion, p.comentario, s.indice_repo, s.cantidad, s.comentario"
               Name="consulta3" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" 
                
                Name="id" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="tabla" Type="String" />
            <asp:Parameter Name="campos" Type="Object" />
            <asp:Parameter Name="valores" Type="Object" />
        </InsertParameters>
    </asp:ObjectDataSource>









             
        Elemento Seleccionado:
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>








             
        <table>
         <tr>
          <td>
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
              <asp:Button ID="Button1" runat="server" Text="Agregar" 
                  onclick="Button1_Click" />
          </td>
          <td>
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  
              <asp:Button ID="Button2" runat="server" Text="Corregir" 
                  onclick="Button2_Click1" />
          </td>
          
          
          
         </tr>
         </table>   
         
<asp:Button ID="backtoindiceadministrativo" runat="server" Text="Volver" PostBackUrl="~/indice_administrativo.aspx" />    

</asp:Content>

