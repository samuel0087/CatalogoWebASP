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

                    <asp:Repeater runat="server" ID="rtrArticulos">
                        <ItemTemplate>
                            <article class="product-card">
                                <div class="product-card__image-box">
                                    <img src="<%# Eval("UrlImagen") == "" ? "https://all.chapanegra.com/shop/" : Eval("UrlImagen") %>" alt="Producto" class="product-card__image" />
                                </div>

                                <div class="product-card__content">
                                    <h3 class="product-card__title"><%# Eval("Nombre") %></h3>
                                    <p class="product-card__description"><%# Eval("Descripcion") %></p>

                                    <div class="product-card__footer">
                                        <span class="product-card__price">$<%# string.Format(new System.Globalization.CultureInfo("es-AR"), "{0:N2}", Eval("Precio")) %></span>
                                        <asp:Button ID="btnDetalle" runat="server" CommandArgument='<%# Eval("IdArticulo") %>' Text="Ver detalle" CssClass="product-card__button" OnClick="btnDetalle_Click" />
                                    </div>
                                </div>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                   
                </section>

            </div>
        </section>

    </main>

</asp:Content>


<%--            <asp:Repeater runat="server" ID="repRepeater">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img src="<%# Eval("UrlImagen") == "" ? "https://www.vhv.rs/dpng/d/424-4249607_poke-ball-png-pokeball-png-transparent-png.png" : Eval("UrlImagen") %>" class="card-img-top" alt="<%# Eval("Nombre")%>">
                            <div class="card-body">
                                <h5 class="card-title"><%#  Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion")%></p>
                                <a href="detalles.aspx?id=<%# Eval("Id") %>" class="btn btn-primary">Ver detalles</a>
                                <asp:Button Text="Ejemplo" ID="btnEjemplo" CssClass="btn btn-danger"  runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="pokemonId" OnClick="btnEjemplo_Click" />
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>--%>
