<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" Title="Profesor" CodeBehind="Profesores.aspx.cs" Inherits="UI.Web.Profesores" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cuerpoContent" runat="server">
         
        <br />

        <div class="position-relative">
            <div class="position-absolute top-0 end-0">
                <asp:Button ID="btnCerrar" runat="server" class="btn-close btn-danger btn-lg"  CausesValidation="false" OnClick="BtnCerrar_Click"/>
            </div>
        </div>

        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false"
                SelectedRowStyle-BackColor="Darkgray"
                SelectedRowStyle-ForeColor="White" CellPadding="4" ForeColor="#333333" GridLines="None"
                DataKeyNames="ID" OnSelectedIndexChanged="girdView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID Dictado" DataField="ID" />
                    <asp:BoundField HeaderText="Curso" DataField="Curso" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Cargo" DataField="Cargo" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>
                <HeaderStyle BackColor="#0d6efd" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#ced4da" />
                <AlternatingRowStyle BackColor="#f8f9fa" />
            </asp:GridView>
        </asp:Panel>

        <br />
        <br />

        <asp:Panel ID="gridActionsPanel" runat="server">
            <div class="container" style="background-color: darkgray">
                <div class="jumbotron text-center"> 
                <p class="fs-5">
                    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton> 
                    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click1">Editar</asp:LinkButton>
                    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click1">Eliminar</asp:LinkButton>
                </p>
                </div>
            </div>
        </asp:Panel>
        

        <asp:Panel ID="formPanel" Visible="false" HorizontalAlign="Center" runat="server">
            <table  style="text-align: right; margin:0 auto ;">
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="idDictadoLabel" runat="server" Text="Id de dictado: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idDictadoTextBox" runat="server" disabled></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="idCursoLabel" runat="server" Text="Id de curso: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idCursoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="idCursoTextBoxValidator" runat="server"
                        ControlToValidate="idCursoTextBox" ErrorMessage="Por favor ingrese el id de curso"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="idDocenteLabel" runat="server" Text="Id de docente: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idDocenteTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="idDocenteTextBoxValidator" runat="server"
                        ControlToValidate="idDocenteTextBox" ErrorMessage="Por favor ingrese el id de docente"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="cargoLabel" runat="server" Text="Cargo: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="cargoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="cargoTextBoxValidator" runat="server"
                        ControlToValidate="cargoTextBox" ErrorMessage="Por favor ingrese el cargo"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <br />

        <asp:Panel ID="FormActionsPanel" HorizontalAlign="Center" Visible="false" runat="server">
            <asp:Button ID="aceptarButton" runat="server" Text="Aceptar" class="btn btn-outline-primary" OnClick="aceptarButton_Click"/>
            <asp:Button ID="cancelarButton" runat="server" Text="Cancelar" class="btn btn-outline-primary"  CausesValidation="false" OnClick="cancelarButton_Click" />
        </asp:Panel>

</asp:Content>