<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlNum.ascx.cs" Inherits="IU.Controles.ControlNum" %>


<asp:TextBox runat="server" ID="txtIn"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" ID="rfvError" ControlToValidate="txtIn" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
<asp:RangeValidator runat="server" ID="rvError" ControlToValidate="txtIn"   Display="Dynamic"   
MinimumValue="1"
MaximumValue="9999999999"
ErrorMessage="El numero debe estar entre los valores 1 y 9999999999" ></asp:RangeValidator>


<asp:RegularExpressionValidator ID="REVError" runat="server" ControlToValidate="txtIn"  ErrorMessage="Solo se permiten numeros" ValidationExpression="\d+"></asp:RegularExpressionValidator>