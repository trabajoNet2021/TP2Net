<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="content2" ContentPlaceHolderID="cuerpoContent" runat="server">
      

<div class="jumbotron text-center">

        <h2 class="form-signin-heading">&nbsp;</h2>
        <h2 class="form-signin-heading">&nbsp;</h2>
        <h2 class="form-signin-heading">Iniciar Sesión</h2>
        <p class="form-signin-heading">&nbsp;</p>

    <table  style="text-align: right; margin:0 auto ;">
        <tr>
            <td class="auto-style19">
                <asp:Label ID="usuarioLabel" runat="server" Text="Usuario"></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="usuarioTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="usuarioTextBoxValidator" runat="server"
                        ControlToValidate="usuarioTextBox" ErrorMessage="Por favor ingrese el nombre de usuario"
                        Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
        </tr>

        <tr>
            <td class="auto-style19">
                <asp:Label ID="claveLabel" runat="server" Text="Clave"></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="claveTextBox" type="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="claveTextBoxValidator" runat="server"
                        ControlToValidate="claveTextBox" ErrorMessage="Por favor ingrese la clave"
                        Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
   
    <br />

    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" />
     <asp:Label ID="lblIngresoIncorrecto" Visible="false" runat="server" ForeColor="Red" Text="Usuario y/o clave incorrectos"></asp:Label>

</div>
</asp:Content>