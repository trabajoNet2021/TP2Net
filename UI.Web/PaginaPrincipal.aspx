<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master"
    CodeBehind="PaginaPrincipal.aspx.cs" Inherits="UI.Web.PaginaPrincipal1" %>

<asp:Content ID="bodyPaginaPrincipal" ContentPlaceHolderID="cuerpoContent" runat="server">


        <div class="container" style="background-color: darkgray">
        <ul class="nav nav-fill justify-content-center">
            <li class="nav-item">
                    <a class="nav-link active" aria-current="page" href="Planes.aspx">Plan</a>
            </li>
            <li class="nav-item">
                    <a class="nav-link" href="/Cursos.aspx">Curso</a>
            </li>
            <li class="nav-item">
                    <a class="nav-link" href="/Comisiones.aspx">Comision</a>
            </li>
            <li class="nav-item">
                    <a class="nav-link" href="/Materias.aspx">Materia</a>
            </li>
            <li class="nav-item">
                    <a class="nav-link" href="/Especialidades.aspx">Especialidades</a>
            </li>
        </ul>
        </div>
        <br />
        <br />
        <br />
        <h2>
            <div class="jumbotron text-center">
                <span class="badge rounded-pill bg-primary">
                    <asp:Label ID="bvNombreApellido" runat="server" Text=""></asp:Label>
                </span>
            </div>
        </h2>
    
        <div class="d-grid gap-2 col-2 mx-auto">
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnPersona" class="btn btn-outline-primary btn-lg" runat="server" Text="Personas" OnClick="btnPersona_Click" />
            <br />
            <br />
            <asp:Button ID="btnProfesor" class="btn btn-outline-primary btn-lg" runat="server" Text="Profesores" OnClick="btnProfesor_Click" />
            <br />
            <br />
            <asp:Button ID="btnInscripcionCursado" class="btn btn-outline-primary btn-lg" runat="server" Text="Inscripción a cursado" OnClick="btnInscripcionCursado_Click" />
            <br />
            <br />
            <asp:Button ID="btnReporteCursos" class="btn btn-outline-primary btn-lg" runat="server" OnClick="btnReporteCursos_Click" Text="Reporte Cursos"/>
            <br />
            <br />
            <asp:Button ID="btnReportePlanes" class="btn btn-outline-primary btn-lg" runat="server" OnClick="btnReportePlanes_Click" Text="Reporte Planes" />
            <br />
            <br />
            <asp:Button ID="btnCerrarSesion" CssClass="btn btn-danger btn-lg" runat="server" Text="Cerrar Sesión"  a OnClick="btnCerrarSesion_Click" />
            <br />
            <br />
        </div>
        


        

        
        

</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="headContent">
</asp:Content>