<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormProducto.aspx.cs" Inherits="WebAppCatalogo.FormProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main class="product-form-page">
        <section class="product-form-card">

            <header class="product-form-card__header">
                <h1 class="product-form-card__title">Agregar producto</h1>
                <p class="product-form-card__subtitle">
                    Completá los datos del artículo para incorporarlo al catálogo.
               
                </p>
            </header>

            <section class="product-form-card__body">

                <div class="product-form">

                    <div class="product-form__row">
                        <div class="product-form__group">
                            <label class="product-form__label" for="txtCodigo">Código de artículo</label>
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="product-form__input" />
                        </div>

                        <div class="product-form__group">
                            <label class="product-form__label" for="txtNombre">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="product-form__input" />
                        </div>
                    </div>

                    <div class="product-form__group">
                        <label class="product-form__label" for="txtDescripcion">Descripción</label>
                        <asp:TextBox
                            ID="txtDescripcion"
                            runat="server"
                            CssClass="product-form__textarea"
                            TextMode="MultiLine"
                            Rows="4" />
                    </div>

                    <div class="product-form__row">
                        <div class="product-form__group">
                            <label class="product-form__label" for="ddlMarca">Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="product-form__select" />
                        </div>

                        <div class="product-form__group">
                            <label class="product-form__label" for="ddlCategoria">Categoría</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="product-form__select" />
                        </div>
                    </div>

                    <div class="product-form__row">
                        <div class="product-form__group">
                            <label class="product-form__label" for="txtImagenUrl">Imagen URL</label>
                            <asp:TextBox
                                ID="txtImagenUrl"
                                runat="server"
                                CssClass="product-form__input"
                                AutoPostBack="true"
                                OnTextChanged="txtImagenUrl_TextChanged"
                                placeholder="https://..." />
                        </div>

                        <div class="product-form__group">
                            <label class="product-form__label" for="txtPrecio">Precio</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="product-form__input" placeholder="0,00" />
                        </div>
                    </div>

                    <div class="product-form__actions">
                        <asp:Button
                            ID="btnCancelar"
                            runat="server"
                            Text="Cancelar"
                            CssClass="product-form__button product-form__button--secondary" />

                        <asp:Button
                            ID="btnGuardar"
                            runat="server"
                            Text="Guardar producto"
                            CssClass="product-form__button product-form__button--primary" />

                        <asp:Button
                        ID="btnEliminar"
                        runat="server"
                        Text="Eliminar producto"
                        CssClass="product-form__button-delete" />
                    </div>


                </div>



                <aside class="product-preview">
                    <h2 class="product-preview__title">Vista previa</h2>

                    <div class="product-preview__image-box">
                        <asp:Image
                            ID="imgPreview"
                            runat="server"
                            CssClass="product-preview__image"
                            ImageUrl="~/Content/img/producto-default.png" />
                    </div>

                    <p class="product-preview__hint">
                        La imagen se actualizará al cargar una URL válida.
                   
                    </p>
                </aside>

                <div class="product-form__danger-zone">

                    

                </div>


            </section>

        </section>
    </main>

</asp:Content>
