<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="WebAppCatalogo.MenuAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main class="admin-page">
        <section class="admin-panel">

            <header class="admin-panel__header">
                <h1 class="admin-panel__title">Panel de administración</h1>
                <p class="admin-panel__subtitle">
                    Gestioná los artículos, marcas y categorías del catálogo.
               
                </p>
            </header>

            <section class="admin-menu">

                <a href="AdminProducto.aspx" class="admin-card">
                    <span class="admin-card__icon">📦</span>
                    <h2 class="admin-card__title">Artículos</h2>
                    <p class="admin-card__text">
                        Agregar, modificar o eliminar productos del catálogo.
                   
                    </p>
                    <span class="admin-card__action">Administrar</span>
                </a>

                <a href="AdminTipos.aspx?tipo=marca" class="admin-card">
                    <span class="admin-card__icon">🏷️</span>
                    <h2 class="admin-card__title">Marcas</h2>
                    <p class="admin-card__text">
                        Gestionar marcas disponibles para los productos.
                   
                    </p>
                    <span class="admin-card__action">Administrar</span>
                </a>

                <a href="AdminTipos.aspx?tipo=categoria" class="admin-card">
                    <span class="admin-card__icon">🗂️</span>
                    <h2 class="admin-card__title">Categorías</h2>
                    <p class="admin-card__text">
                        Crear y editar categorías del catálogo.
                   
                    </p>
                    <span class="admin-card__action">Administrar</span>
                </a>

            </section>

        </section>
    </main>
</asp:Content>
