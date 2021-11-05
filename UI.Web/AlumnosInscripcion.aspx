<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" 
    AutoEventWireup="true" CodeBehind="AlumnosInscripcion.aspx.cs" Inherits="UI.Web.Alumnos" Title="AlumnosInscripcion" %>


<asp:Content ID="content1" ContentPlaceHolderID="cuerpoContent" runat="server">
        
       <br />
        
        <div class="position-relative">
            <div class="position-absolute top-0 end-0" style="height: 16px">
                <asp:Button ID="BtnCerrar" runat="server" class="btn-close btn-danger btn-lg" CausesValidation="false" OnClick="BtnCerrar_Click" />
            </div>
        </div>


        <!-- Parte del GridView -->
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false"
                SelectedRowStyle-BackColor="Darkgray"
                SelectedRowStyle-ForeColor="White" CellPadding="4" ForeColor="#333333" GridLines="None"
                DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="Id inscripción" DataField="ID" />
                    <asp:BoundField HeaderText="Id alumno" DataField="IdAlumno" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Id curso" DataField="IdCurso" />
                    <asp:BoundField HeaderText="Nota" DataField="Nota" />
                    <asp:BoundField HeaderText="Condición" DataField="Condicion" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
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
                    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                </p>
                </div>
            </div>
        </asp:Panel>
        <!-- Parte de los botones del GridView -->

        <br />

        <!-- Parte del formulario -->
        <asp:Panel ID="formPanel" Visible="false" runat="server">
        <table  style="text-align: right; margin:0 auto ;">
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="idInscripcionLabel" runat="server" Text="Id inscripción :"></asp:Label>
                </td>
                <td class="auto-style20" style="text-align: left">
                    <asp:TextBox ID="idInscripcionTextBox" runat="server" disabled></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="idAlumnoLabel" runat="server" Text="Id alumno: "></asp:Label>
                </td>
                <td class="auto-style20" style="text-align: left">
                    <asp:TextBox ID="idAlumnoTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="idAlumnoTextBoxValidator" runat="server"
                        ControlToValidate="idAlumnoTextBox" ErrorMessage="Por favor ingrese el id de alumno"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="idCursoLabel" runat="server" Text="Id curso: "></asp:Label>
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
                    <asp:Label ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
                </td>
                <td class="auto-style20" style="text-align: left">
                    <asp:TextBox ID="notaTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="condicionLabel" runat="server" Text="Condición: "></asp:Label>
                </td>
                <td class="auto-style20" style="text-align: left">
                    <asp:TextBox ID="condicionTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        </asp:Panel>
        <!-- Parte del formulario -->

        <br />

        <!-- Parte de los botones del formulario -->
        <asp:Panel ID="formActionsPanel" runat="server" HorizontalAlign="Center" Visible="false">
            <asp:Button ID="aceptarButton" runat="server" class="btn btn-outline-primary" Text="Aceptar" OnClick="acceptaButton_Click" />
            <asp:Button ID="cancelarButton" runat="server" class="btn btn-outline-primary" CausesValidation="false" Text="Cancelar" OnClick="cancelarButton_Click" />
        </asp:Panel>
        <!-- Parte de los botones del formulario -->

</asp:Content>
