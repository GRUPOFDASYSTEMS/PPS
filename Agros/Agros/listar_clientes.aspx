  <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listar_clientes.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.listar_clientes" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    
    <h2 class="title"><a href="#">Listar Clientes:</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
                  &nbsp;&nbsp;&nbsp; Filtrar estados:</p>
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
        

              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    
                        <br />
    
                        
    <asp:GridView ID="dgvDatos" runat="server" DataSourceID="ObjectDataSource2" 
        AllowPaging="True" AllowSorting="True" onselectedindexchanged="dgvDatos_SelectedIndexChanged" >
        <Columns>
            <asp:CommandField SelectText="-&gt;" 
                ShowSelectButton="True" HeaderText="Marcar" />
        </Columns>
    
    </asp:GridView>        
          
                        <br />
    
                        
    <asp:Label ID="ltext" runat="server" Text="Ha Seleccionado El Cliente: "></asp:Label>
    <asp:Label ID="idc" runat="server" Text=""></asp:Label>
          
    <asp:Button ID="X" runat="server" Text="Eliminar" onclick="Button3_Click" />
          
    <br />
    ...::::::::::::::::***************::::::::::::::::***************::::::::::::::::***************::::::::::::::::....<br />
    CONFIGURAR CLIENTE:<br />
    <br />
    OPERARIO FAVORITO&nbsp; :&nbsp;  
            <asp:DropDownList ID="operario" runat="server" 
        DataSourceID="ObjectDataSource3" DataTextField="nombre" 
        DataValueField="id">
            </asp:DropDownList>
          &nbsp;<asp:Button ID="of" runat="server" Text="Fijar" 
        onclick="of_Click" />
    <br />
    VALOR DE CONFIANZA :     <asp:TextBox ID="confianza" runat="server"></asp:TextBox>
    <asp:Button ID="vc" runat="server" Text="Establecer" onclick="vc_Click" />
    
    <br />
          
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from estados where tema='cliente'" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>





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
            <asp:Parameter DefaultValue="select c.id as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id and c.condicion_iva=i.id and c.id_estado=" 
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
    
    
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from usuario where perfil=3" 
                Name="consulta" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

<asp:Button ID="Button2" runat="server" Text="Volver"  PostBackUrl="~/indice_administrativo.aspx"/>    

</asp:Content>
