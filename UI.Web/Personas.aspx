<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs"
     Title="Personas" Inherits="UI.Web.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cuerpoContent" runat="server">

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
                    <asp:BoundField HeaderText="Id persona" DataField="ID" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                    <asp:BoundField HeaderText="Fecha de nacimiento" DataField="FechaNacimiento" />
                    <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                    <asp:BoundField HeaderText="Nombre de usuario" DataField="NombreUsuario" />
                    <asp:BoundField HeaderText="Id plan" DataField="IdPlan" />
                    <asp:BoundField HeaderText="Tipo de persona" DataField="TipoPersona" />
                    <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"  />
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
                    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click1">Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                </p>
                </div>
            </div>
        </asp:Panel>
        <!-- Parte de los botones del GridView -->


       <!-- Parte del formulario -->
        <asp:Panel ID="formPanel" Visible="false" HorizontalAlign="Center" runat="server">
            <table  style="text-align: right; margin:0 auto ;">
                <tr >
                    <td class="auto-style19">
                        <asp:Label ID="idPersonaLabel" runat="server" Text="Id de persona: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idPersonaTextBox"  runat="server" disabled></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nombreTextBoxValidator" runat="server"
                        ControlToValidate="nombreTextBox" ErrorMessage="Por favor ingrese el nombre"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="apellidoTextBoxValidator" runat="server"
                        ControlToValidate="apellidoTextBox" ErrorMessage="Por favor ingrese el apellido"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="direccionLabel" runat="server" Text="Dirección: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="direccionTextBoxValidator" runat="server"
                        ControlToValidate="direccionTextBox" ErrorMessage="Por favor ingrese la dirección"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="emailTextBoxValidator" runat="server"
                        ControlToValidate="emailTextBox" ErrorMessage="Por favor ingrese el email"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="telefonoLabel" runat="server" Text="Teléfono: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="telefonoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="telefonoTextBoxValidator" runat="server"
                        ControlToValidate="telefonoTextBox" ErrorMessage="Por favor ingrese el teléfono"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de nacimiento: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="fechaNacimientoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="fechaNacimientoTextBoxValidator" runat="server"
                        ControlToValidate="fechaNacimientoTextBox" ErrorMessage="Por favor ingrese la fecha de nacimiento"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Nombre de usuario: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nombreUsuarioTextBoxValidator" runat="server"
                        ControlToValidate="nombreUsuarioTextBox" ErrorMessage="Por favor ingrese el nombre de usuario"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="idPlanLabel" runat="server" Text="Id plan: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idPlanTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo de persona: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:DropDownList ID="tipoPersonaDropDownList" runat="server">
                            <asp:ListItem Value="Admin">Admin</asp:ListItem>
                            <asp:ListItem Value="Docente">Docente</asp:ListItem>
                            <asp:ListItem Value="Alumno">Alumno</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="claveTextBox" type="password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="claveTextBoxValidator" runat="server"
                        ControlToValidate="claveTextBox" ErrorMessage="Por favor ingrese la clave"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="repetirClaveTextBox" type="password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="repetirClaveTextBoxValidator" runat="server"
                        ControlToValidate="repetirClaveTextBox" ErrorMessage="Por favor ingrese la clave de nuevo"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <!-- Parte del formulario -->

        <br />

        <!-- Parte de los botones del formulario -->
        <asp:Panel ID="formActionsPanel" Visible="false" HorizontalAlign="Center" runat="server">
            <asp:Button ID="aceptarButton" runat="server" class="btn btn-outline-primary" Text="Aceptar" OnClick="aceptarButton_Click" />
            <asp:Button ID="cancelarButton" runat="server" class="btn btn-outline-primary" Text="Cancelar"  CausesValidation="false" OnClick="cancelarButton_Click" />
        </asp:Panel>
        <!-- Parte de los botones del formulario -->

</asp:Content>