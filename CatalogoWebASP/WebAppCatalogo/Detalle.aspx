<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebAppCatalogo.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main class="product-detail-page">
        <section class="product-detail">

            <div class="product-detail__image-box">
                <asp:Image
                    ID="imgProducto"
                    runat="server"
                    CssClass="product-detail__image" />
            </div>

            <div class="product-detail__info">
                <span class="product-detail__category">Producto destacado</span>

                <h1 class="product-detail__title">
                    <asp:Label ID="lblNombre" runat="server" Text="Galaxy S10" />
                </h1>

                <div class="product-detail__price">
                    $<asp:Label ID="lblPrecio" runat="server" Text="70,00" />
                </div>

                <p class="product-detail__description">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción completa del producto." />
                </p>


                <div class="product-detail__actions">
                    <asp:Button
                        ID="btnVolver"
                        runat="server"
                        Text="Volver al catálogo"
                        CssClass="product-detail__button product-detail__button--secondary"
                        OnClick="btnVolver_Click" />

                    <asp:Button
                        ID="btnComprar"
                        runat="server"
                        Text="Comprar"
                        CssClass="product-detail__button product-detail__button--primary" />
                </div>
            </div>

        </section>
    </main>

</asp:Content>
