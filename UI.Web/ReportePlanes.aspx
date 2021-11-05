<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master"
    CodeBehind="ReportePlanes.aspx.cs" Inherits="UI.Web.ReportePlanes" Title="Reporte de cursos" %>

<asp:Content ID="content1" ContentPlaceHolderID="cuerpoContent" runat="server">
      
        <br /> 
     
        <div class="position-relative">
            <div class="position-absolute top-0 end-0">
                <asp:Button ID="BtnCerrar" runat="server" class="btn-close btn-danger btn-lg" OnClick="BtnCerrar_Click" />
            </div>
        </div>
   
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false"
                SelectedRowStyle-BackColor="Darkgray"
                SelectedRowStyle-ForeColor="White" GridLines="None"  CellPadding="4"
                DataKeyNames="ID">
                <Columns>
                    <asp:BoundField HeaderText="Id plan" DataField="ID" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Especialidad" DataField="DescripcionEspecialidad" />
                </Columns>
                <HeaderStyle BackColor="#0d6efd" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#ced4da" />
                <AlternatingRowStyle BackColor="#f8f9fa" />
            </asp:GridView>
    </asp:Panel>

    <br />

    <asp:Panel ID="formActionsPanel" runat="server" HorizontalAlign="Center">
            <asp:Button ID="btnDescargarPDF" runat="server"  class="btn btn-outline-primary" OnClick="btnDescargarPDF_Click" Text="Descargar PDF" />
    </asp:Panel>
            



</asp:Content>