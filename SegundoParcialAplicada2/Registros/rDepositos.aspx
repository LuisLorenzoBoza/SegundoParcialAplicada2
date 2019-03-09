<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="SegundoParcial.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="h2">Registro de Depositos</h2>
        <hr />
        <form runat="server">

            <div class="row">
                <div class="form-group col-lg-3 col-sm-12">
                    <asp:Label runat="server">Deposito ID</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="depositoIdTextbox" TextMode="Number" Text="0" min="0"></asp:TextBox>
                </div>
                <div class="form-group col-lg-3 col-md-12">
                    <br />
                    <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info col-lg-4 col-md-12" Text="Buscar" OnClick="BuscarButton_Click"/>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Fecha</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="fechaTextbox" TextMode="Date"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Cuenta ID</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" TextMode="Number" ID="cuentaIdTextbox" Text="1" min="1"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Concepto</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="conceptoTextbox" placeholder="Concepto"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Monto</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="montoTextbox" Text="0" min="0"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-5 col-sm-12">
                    <asp:Button ID="NuevoButtton" runat="server" CssClass="btn btn-success col-lg-3 col-md-12" Text="Nuevo" OnClick="NuevoButton_Click"/>
                    <asp:Button ID="GuardarButton" runat="server" CssClass="btn btn-warning col-lg-3 col-md-12" Text="Guardar" OnClick="GuardarButton_Click"/>
                    <asp:Button ID="EliminarButton" runat="server" CssClass="btn btn-danger col-lg-3 col-md-12" Text="Eliminar" OnClick="EliminarButton_Click"/>
                </div>
            </div>

        </form>
    </div>
</asp:Content>

