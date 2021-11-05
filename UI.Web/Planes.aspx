<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" MasterPageFile="~/PaginaMaestra.Master" Title="Planes" %>



 <asp:Content ID="content1" ContentPlaceHolderID="cuerpoContent" runat="server"  HorizontalAlign="Center">
        
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
                    <asp:BoundField HeaderText="Id plan" DataField="ID" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Especialidad" DataField="DescripcionEspecialidad" />
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
                        <asp:Label ID="idPlanLabel" runat="server" Text="Id de plan: "></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idPlanTextBox" runat="server" disabled></asp:TextBox>
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
                        <asp:Label ID="idEspecialidadLabel" runat="server" Text="Id de especialidad"></asp:Label>
                    </td>
                    <td class="auto-style20" style="text-align: left">
                        <asp:TextBox ID="idEspecialidadTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="idEspecialidadTextBoxValidator" runat="server"
                        ControlToValidate="idEspecialidadTextBox" ErrorMessage="Por favor ingrese el id de especialidad"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <br />

        <asp:Panel ID="formActionsPanel" HorizontalAlign="Center" Visible="false" runat="server">
            <asp:Button ID="aceptarButton" runat="server" class="btn btn-outline-primary" Text="Aceptar" OnClick="aceptarButton_Click" />
            <asp:Button ID="cancelarButton" runat="server" class="btn btn-outline-primary" Text="Cancelar"  CausesValidation="false" OnClick="cancelarButton_Click" />
        </asp:Panel>


</asp:Content>