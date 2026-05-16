<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminTipos.aspx.cs" Inherits="WebAppCatalogo.AdminTipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="admin-types-page">

    <section class="admin-types-panel">

        <header class="admin-types-header">
            <div>
                <asp:Label ID="lblTitulo" runat="server" CssClass="admin-types-header__title" />
                <asp:Label ID="lblSubtitulo" runat="server" CssClass="admin-types-header__subtitle" />
            </div>
        </header>

        <section class="admin-types-form">

            <asp:HiddenField ID="hfId" runat="server" />

            <div class="admin-types-form__group">
                <label class="admin-types-form__label">Descripción</label>

                <asp:TextBox
                    ID="txtDescripcion"
                    runat="server"
                    CssClass="admin-types-form__input"
                    placeholder="Ingrese una descripción..." />
            </div>

            <div class="admin-types-form__actions">

                <asp:Button
                    ID="btnGuardar"
                    runat="server"
                    Text="Guardar"
                    CssClass="admin-types-form__button admin-types-form__button--save"
                    OnClick="btnGuardar_Click" />

                <asp:Button
                    ID="btnLimpiar"
                    runat="server"
                    Text="Limpiar"
                    CssClass="admin-types-form__button admin-types-form__button--clean"
                    OnClick="btnLimpiar_Click" />

            </div>

        </section>

        <section class="admin-types-list">

            <asp:Repeater ID="rtrItems" runat="server">
                <ItemTemplate>

                    <article class="admin-type-item">

                        <div class="admin-type-item__content">
                            <span class="admin-type-item__id">
                                # <%# Eval("Id") %>
                            </span>

                            <strong class="admin-type-item__name">
                                <%# Eval("Nombre") %>
                            </strong>
                        </div>

                        <div class="admin-type-item__actions">

                            <asp:Button
                                ID="btnEditar"
                                runat="server"
                                Text="Editar"
                                CssClass="admin-type-item__button admin-type-item__button--edit"
                                CommandArgument='<%# Eval("Id") + "|" + Eval("Nombre") %>'
                                OnClick="btnEditar_Click" />

                            <asp:Button
                                ID="btnEliminar"
                                runat="server"
                                Text="Eliminar"
                                CssClass="admin-type-item__button admin-type-item__button--delete"
                                CommandArgument='<%# Eval("Id") %>'
                                OnClick="btnEliminar_Click" />

                        </div>

                    </article>

                </ItemTemplate>
            </asp:Repeater>

        </section>

    </section>

</main>

</asp:Content>
