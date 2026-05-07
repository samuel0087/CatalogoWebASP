<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="WebAppCatalogo.Formulario_web11" %>
<asp:Content ID="PerfilContent" ContentPlaceHolderID="MainContent" runat="server">

<main class="profile-page">
    <section class="profile-card">

        <div class="profile-card__header">
            <h1 class="profile-card__title">Mi perfil</h1>
            <p class="profile-card__subtitle">Visualizá y modificá tus datos personales</p>
        </div>

        <div class="profile-card__body">

            <!-- DATOS -->
            <section class="profile-form">
                <div class="profile-form__group">
                    <label class="profile-form__label" for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="profile-form__input" />
                </div>

                <div class="profile-form__group">
                    <label class="profile-form__label" for="txtApellido">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="profile-form__input" />
                </div>

                <div class="profile-form__group">
                    <label class="profile-form__label" for="txtEmail">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="profile-form__input" TextMode="Email" />
                </div>

                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="profile-form__button" />
            </section>

            <!-- FOTO -->
            <aside class="profile-photo">
                <h2 class="profile-photo__title">Foto de perfil</h2>

                <div class="profile-photo__preview">
                    <asp:Image ID="imgPerfil" runat="server" CssClass="profile-photo__image" ImageUrl="~/Content/img/default-user.png" />
                </div>

                <label class="profile-photo__label" for="fuFotoPerfil">Cargar nueva imagen</label>

                <asp:FileUpload ID="fuFotoPerfil" runat="server" CssClass="profile-photo__upload" />

                <p class="profile-photo__hint">Formatos recomendados: JPG, PNG o WEBP.</p>
            </aside>

        </div>
    </section>
</main>

</asp:Content>
