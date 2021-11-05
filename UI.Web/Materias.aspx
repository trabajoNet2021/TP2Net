<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" 
    AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<asp:Content ID="content1" ContentPlaceHolderID="cuerpoContent" runat="server">
        
        <br /> 

        <div class="position-relative">
            <div class="position-absolute top-0 end-0">
                <asp:Button ID="BtnCerrar" runat="server" class="btn-close btn-danger btn-lg" CausesValidation="false" OnClick="BtnCerrar_Click" />
            </div>
        </div>

        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false"
                SelectedRowStyle-BackColor="Darkgray"
                SelectedRowStyle-ForeColor="White" CellPadding="4" ForeColor="#333333" GridLines="None"
                DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="Id materia" DataField="ID" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Horas semanales" DataField="HorasSemanales" />
                    <asp:BoundField HeaderText="Horas totales" DataField="HorasTotales" />
                    <asp:BoundField HeaderText="Id plan" DataField="IdPlan" />
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
                        <asp:Label ID="idMateriaLabel" runat="server" Text="Id materia: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idMateriaTextBox" runat="server" disabled></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="descripcionTextBoxValidator" runat="server"
                        ControlToValidate="descripcionTextBox" ErrorMessage="Por favor ingrese la descripción"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="hsSemanalesLabel" runat="server" Text="Horas semanales"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="horasSemanalesTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="hsSemanalesTextBoxValidator" runat="server"
                        ControlToValidate="horasSemanalesTextBox" ErrorMessage="Por favor ingrese las horas semanales"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="hsTotalesLabel" runat="server" Text="Horas totales"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="hsTotalesTextBox" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="hsTotalesTextBoxValidator" runat="server"
                        ControlToValidate="hsTotalesTextBox" ErrorMessage="Por favor ingrese las horas totales"
                        Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                </tr>

                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="idPlanLabel" runat="server" Text="Id plan"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idPlanTextBox" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="idPlanTextBoxValidator" runat="server"
                        ControlToValidate="idPlanTextBox" ErrorMessage="Por favor ingrese el id de plan"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <br />

        <asp:Panel ID="formActionsPanel" HorizontalAlign="Center" Visible="false" runat="server">
            <asp:Button ID="aceptarButton" runat="server" class="btn btn-outline-primary" Text="Aceptar" OnClick="aceptarButton_Click" />
            <asp:Button ID="cancelarButton" runat="server" class="btn btn-outline-primary" Text="Cancelar" CausesValidation="false" OnClick="cancelarButton_Click" />
        </asp:Panel>
</asp:Content>