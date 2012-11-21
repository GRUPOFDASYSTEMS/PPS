<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmrestriccionlicencias_listado.aspx.cs" MasterPageFile="~/menu_administrativo.master" Inherits="Agros.abmrestriccionlicencias_listado" %>





<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">

    <h2 class="title"><a href="#">Listado de licencias de personal </a></h2>


    <asp:GridView ID="dgvDatos" runat="server" 
        DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="X" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Seleccion_en_dataset" TypeName="Agros.linkeo">
        <SelectParameters>
            <asp:Parameter DefaultValue="select * from restriccion_diponibilidad_usuario" Name="consulta" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>


<%--

        <table>
         <tr>

         <td>
            <asp:Button ID="Button1" runat="server" Text=".." PostBackUrl="~/abmrestriccion_licencias_mod.aspx"/>     
         </td>
         
         <td>
         <asp:Button ID="Button2" runat="server" Text="X" />
         </td>
         
         </tr>
         
         
         </table>   

--%>
    <asp:Button ID="Button3" runat="server" Text="Volver" PostBackUrl="~/abmrestriccion_licencias.aspx" />


    
</asp:Content>