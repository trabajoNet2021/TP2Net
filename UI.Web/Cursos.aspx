 <%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" Title="Cursos"
    AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

    <asp:Content ID="content1" ContentPlaceHolderID="cuerpoContent" runat="server">

        <br />

        <div class="position-relative">
            <div class="position-absolute top-0 end-0">
                <asp:Button ID="BtnCerrar" runat="server" class="btn-close btn-danger btn-lg"  CausesValidation="false" OnClick="BtnCerrar_Click" />
            </div>
        </div>

        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false"
                SelectedRowStyle-BackColor="Darkgray"
                SelectedRowStyle-ForeColor="White" CellPadding="4" ForeColor="#333333" GridLines="None"
                DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="Id de curso" DataField="ID" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Materia" DataField="Materia" />
                    <asp:BoundField HeaderText="Comisión" DataField="Comision" />
                    <asp:BoundField HeaderText="Año calendario" DataField="AnioCalendario" />
                    <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
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
                    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                </p>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="formPanel" Visible="false" HorizontalAlign="Center" runat="server">
             <table  style="text-align: right; margin:0 auto ;">
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="idCursoLabel" runat="server" Text="Id de curso"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idCursoTextBox" runat="server" disabled></asp:TextBox>
                    </td>
                </tr>
    
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="idMateriaLabel" runat="server" Text="Id de materia"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idMateriaTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="idMateriaTextBoxValidator" runat="server"
                        ControlToValidate="idMateriaTextBox" ErrorMessage="Por favor ingrese el id de materia"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="idComisionLabel" runat="server" Text="Id comision"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idComisionTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="idComisionTextBoxValidator" runat="server"
                        ControlToValidate="idComisionTextBox" ErrorMessage="Por favor ingrese el id de comisión"
                        Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                </tr>
     
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="anioCalendarioLabel" runat="server" Text="Año calendario"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="anioCalendarioTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="anioCalendarioTextBoxValidator" runat="server"
                        ControlToValidate="anioCalendarioTextBox" ErrorMessage="Por favor ingrese el año"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="cupoLabel" runat="server" Text="Cupo"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="cupoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="cupoTextBoxValidator" runat="server"
                        ControlToValidate="cupoTextBox" ErrorMessage="Por favor ingrese el cupo"
                        Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="descripcionTextBoxValidator" runat="server"
                        ControlToValidate="descripcionTextBox" ErrorMessage="Por favor ingrese la descripción"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>
        </asp:Panel>

        <br />

        <asp:Panel ID="formActionsPanel" Visible="false" HorizontalAlign="Center" runat="server">
            <asp:Button ID="aceptarButton" runat="server" class="btn btn-outline-primary" Text="Aceptar" OnClick="aceptarButton_Click"></asp:Button>
            <asp:Button ID="cancelarButton" runat="server" class="btn btn-outline-primary" Text="Cancelar"  CausesValidation="false" OnClick="cancelarButton_Click"></asp:Button>
        </asp:Panel>

</asp:Content>