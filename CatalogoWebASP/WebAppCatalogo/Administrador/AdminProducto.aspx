<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminProducto.aspx.cs" Inherits="WebAppCatalogo.AdminProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="admin-products-page">

        <section class="admin-products-panel">

            <header class="admin-products-header">
                <div>
                    <h1 class="admin-products-header__title">Administrar productos</h1>
                    <p class="admin-products-header__subtitle">Listado general de artículos del catálogo</p>
                </div>

<%--                <asp:Button
                    ID="btnNuevoProducto"
                    runat="server"
                    Text="+ Crear producto"
                    CssClass="admin-products-header__button" />--%>
                <a  href="FormProducto.aspx" class="admin-products-header__button">+ Crear producto</a>
                    
            </header>

            <section class="admin-products-filter">
                <asp:TextBox
                    ID="txtBuscar"
                    runat="server"
                    CssClass="admin-products-filter__input"
                    placeholder="Buscar por nombre o código..." />

                <asp:DropDownList
                    ID="ddlMarca"
                    runat="server"
                    CssClass="admin-products-filter__select" />

                <asp:DropDownList
                    ID="ddlCategoria"
                    runat="server"
                    CssClass="admin-products-filter__select" />

                <asp:Button
                    ID="btnBuscar"
                    runat="server"
                    Text="Buscar"
                    CssClass="admin-products-filter__button" />
            </section>

            <div class="admin-products-table-wrapper">

                <table class="admin-products-table">
                    <thead>
                        <tr>
                            <th>Código</th>
                            <th>Imagen</th>
                            <th>Producto</th>
                            <th>Marca</th>
                            <th>Categoría</th>
                            <th>Precio</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="rtrProductos" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <span class="admin-products-table__code">
                                            <%# Eval("Codigo") %>
                                        </span>
                                    </td>

                                    <td>
                                        <img
                                            src='<%# Eval("UrlImagen") %>'
                                            alt="Producto"
                                            class="admin-products-table__image" />
                                    </td>

                                    <td>
                                        <strong class="admin-products-table__name">
                                            <%# Eval("Nombre") %>
                                        </strong>

                                        <p class="admin-products-table__description">
                                            <%# Eval("Descripcion") %>
                                        </p>
                                    </td>

                                    <td>
                                        <span class="admin-products-table__badge">
                                            <%# Eval("Marca.Nombre") %>
                                        </span>
                                    </td>

                                    <td>
                                        <span class="admin-products-table__badge admin-products-table__badge--soft">
                                            <%# Eval("Categoria.Nombre") %>
                                        </span>
                                    </td>

                                    <td>
                                        <span class="admin-products-table__price">$ <%# string.Format("{0:N2}", Eval("Precio")) %>
                                        </span>
                                    </td>

                                    <td>
                                        <div class="admin-products-table__actions">

                                            <asp:Button
                                                ID="btnEditar"
                                                runat="server"
                                                Text="Editar"
                                                CssClass="admin-products-table__action admin-products-table__action--edit"
                                                CommandArgument='<%# Eval("IdArticulo") %>'
                                                OnClick="btnEditar_Click"/>

                                            <asp:Button
                                                ID="btnEliminar"
                                                runat="server"
                                                Text="Eliminar"
                                                CssClass="admin-products-table__action admin-products-table__action--delete"
                                                CommandArgument='<%# Eval("IdArticulo") %>' />

                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

            </div>

        </section>

    </main>
</asp:Content>
