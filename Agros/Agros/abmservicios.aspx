﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abmservicios.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Agros.abmservicios" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Editable">
    <form id="form1" runat="server">
    <h2 class="title"><a href="#">Servicios (ABM)</a></h2>


        <table>
         <tr>
          <td>
              <p class="meta">
              <asp:ImageButton ID="ImageButton2" runat="server" 
                  ImageUrl="images/img11.gif" AlternateText="Listados" />
              &nbsp;&nbsp;&nbsp; Alta De Servicios</p>
	      </td>
	      <td>  
	      
          </td>
        </tr>  
            
         <tr>
          <td>
            
              <p class="meta">
              <asp:ImageButton ID="ImageButton1" runat="server" 
                  ImageUrl="images/img10.gif" AlternateText="Listados" />
              &nbsp;&nbsp;&nbsp; Edicion Servicios (Modificacion/Baja)</p>
          </td>
          <td> 
            
          </td>
         </tr>
         <tr> 
          <td>

          </td>
         </tr>
         </table>   

    </form>
</asp:Content>
