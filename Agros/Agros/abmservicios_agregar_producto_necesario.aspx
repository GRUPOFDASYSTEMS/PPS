<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios_agregar_producto_necesario.aspx.cs" Inherits="Agros.abmservicios_agregar_producto_necesario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Agregando Productos Necesarios</title>
    <link href="style.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    
    <form id="form1" runat="server">
    
    ...quiza esta pantalla sea un popup x eso no tiene disenio...
    <h2 class="title"><a href="#" />Seleccione un producto:</h2> 

        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        

(producto seleccionado)
        <table>
         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Producto</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Unidad Medida</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Raci&oacute;n Unidad De Medida</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Comentario Adicional</p>
          </td>



         </tr>











         <tr>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Acido Sulfurico</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Litros</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; 4</p>
          </td>
          <td>
            
              <p class="meta">
              &nbsp;&nbsp;&nbsp; Evitar mojar los recipientes (Balde de 5 lts)</p>
          </td>
          
         </tr>
         </table>   
         
    <table>
         <tr>
          <td>
              <p class="meta">
              Cantidad De Unidades Necesaria:
                 </p>
	      </td>
	      <td>  
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
        </tr>  
    </table>         


<asp:Button ID="add" runat="server" Text="Agregar"   />   <%--OnClick="crearinsertymostrarmensajedeok_luegoresetearform..;"--%>
<asp:Button ID="cancel" runat="server" Text="Cancelar"  OnClick="window.close();" />   

    </form>



    
    
    
</body>
</html>
