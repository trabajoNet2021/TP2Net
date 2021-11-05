<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" 
    AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" Title="Comisiones" %>

<asp:Content ID="content1" ContentPlaceHolderID="cuerpoContent" runat="server">

        <br />

        <div class="position-relative">
            <div class="position-absolute top-0 end-0">
                <asp:Button ID="BtnCerrar" runat="server" class="btn-close btn-danger btn-lg"  CausesValidation="false" OnClick="BtnCerrar_Click" />
            </div>
        </div>


        <!-- Parte del GridView -->
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false"
                SelectedRowStyle-BackColor="Darkgray"
                SelectedRowStyle-ForeColor="White" CellPadding="4" ForeColor="#333333" GridLines="None" 
                DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="ID comisión" DataField="ID" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Año especialidad" DataField="AnioEspecialidad" />
                    <asp:BoundField HeaderText="ID plan" DataField="IdPlan" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" />
                </Columns>
                <HeaderStyle BackColor="#0d6efd" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#ced4da" />
                <AlternatingRowStyle BackColor="#f8f9fa" />
            </asp:GridView>
        </asp:Panel>
        <!-- Parte del GridView -->

        <br />
        <br />

        <!-- Parte de los botones del GridView -->
        <asp:Panel ID="gridActionsPanel" runat="server">
            <div class="container" style="background-color: darkgray">
                <div class="jumbotron text-center">
                <p class="fs-5">
                    <asp:LinkButton ID="nuevaLinkButton" runat="server" OnClick="nuevaLinkButton_Click">Nueva</asp:LinkButton>
                    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                </p>
                </div>
            </div>
        </asp:Panel>
        <!-- Parte de los botones del GridView -->

        <br />

        <!-- Parte del formulario -->
        <asp:Panel ID="formPanel" Visible="false" HorizontalAlign="Center" runat="server">
        <table  style="text-align: right; margin:0 auto ;">
            <tr >
                <td class="auto-style19">
                    <asp:Label ID="idComisionLabel" runat="server" Text="ID comisión: "></asp:Label>
                </td>
                <td class="auto-style20" style="text-align: left">
                    <asp:TextBox ID="idComisionTextBox" runat="server" disabled Height="25px"></asp:TextBox> 
                </td>
            </tr>
            <tr >
                <td class="auto-style19">
                    <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
                </td>
                <td class="auto-style20" style="text-align: left">
                    <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="descripcionTextBoxValidator" runat="server"
                        ControlToValidate="descripcionTextBox" ErrorMessage="Por favor ingrese la descripción"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr >
                <td class="auto-style19">
                    <asp:Label ID="añoEspecialidadLabel" runat="server" Text="Año especialidad: "></asp:Label>
                </td>
                <td class="auto-style20" style="text-align: left">
                    <asp:TextBox ID="añoEspecialidadTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="añoEspecialidadTextBoxValidator" runat="server"
                        ControlToValidate="añoEspecialidadTextBox" ErrorMessage="Por favor ingrese el año de especialidad"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="idPlanLabel" runat="server" Text="ID de plan: "></asp:Label>
                </td>
                <td class="auto-style20" style="text-align: left">
                    <asp:TextBox ID="idPlanTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="idPlanTextBoxValidator" runat="server"
                        ControlToValidate="idPlanTextBox" ErrorMessage="Por favor ingrese el número de plan"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        </asp:Panel>
        <!-- Parte del formulario -->
        
        <br />

        <!-- Parte de los botones del formulario -->
        <asp:Panel ID="formActionsPanel" Visible="false" HorizontalAlign="Center" runat="server">
            <asp:Button ID="aceptarButton" class="btn btn-outline-primary" runat="server" Text="Aceptar" OnClick="aceptarButton_Click"></asp:Button>
            <asp:Button ID="cancelarButton" class="btn btn-outline-primary" runat="server" Text="Cancelar" CausesValidation="false" OnClick="cancelarButton_Click"></asp:Button>
        </asp:Panel>
        <!-- Parte de los botones del formulario -->

</asp:Content>