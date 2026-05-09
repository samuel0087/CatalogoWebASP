<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppCatalogo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="main-default">
        <section class="main-card">
            <div class="main-card__header" aria-labelledby="aspnetTitle">
                <h1 id="aspnetTitle">Catalogo inicial</h1>
                <p class="lead">Navega entre nuestros productos y selecciona tus favoritos</p>
            </div>
            <div class="main-card__body">
                <section class="products">
                    <article class="product-card">
                        <div class="product-card__image-box">
                            <img src="Content/img/producto-1.png" alt="Producto" class="product-card__image" />
                        </div>

                        <div class="product-card__content">
                            <h3 class="product-card__title">Nombre del producto</h3>
                            <p class="product-card__description">Descripción breve del producto.</p>

                            <div class="product-card__footer">
                                <span class="product-card__price">$12.500</span>
                                <asp:Button ID="btnDetalle1" runat="server" Text="Ver detalle" CssClass="product-card__button" />
                            </div>
                        </div>
                    </article>
                </section>

            </div>
        </section>

    </main>

</asp:Content>
