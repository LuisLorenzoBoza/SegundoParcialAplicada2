<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cDeposito.aspx.cs" Inherits="SegundoParcialAplicada2.Consultas.cDepositos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="h2">Consulta de Depositos</h2>
        <hr />
        <form runat="server">
            <div class="row" >
                <div class="col-md-2">
                    <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>Todo</asp:ListItem>
                        <asp:ListItem>DepositoId</asp:ListItem>
                        <asp:ListItem>CuentaId</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="FiltroTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="BuscarButton" runat="server" Class="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click" />
                </div>
            </div>
            <br />
            <%--GRID--%>
            <div class="col-md-12">
                <asp:GridView ID="DatosGridView"
                    runat="server"
                    class="table table-condensed table-bordered table-responsive"
                    CellPadding="4" ForeColor="#333333" GridLines="None">

                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField ControlStyle-ForeColor="Black"
                            DataNavigateUrlFields="CuentaId"
                            DataNavigateUrlFormatString="rCuentas.aspx?Id={0}">
                        </asp:HyperLinkField>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
            </div>


            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                     <asp:Button ID="ImprimirButton" CssClass="btn btn-outline-info mt-4" runat="server" Text="Imprimir" OnClick="ImprimirButton_Click" />
                        <span class="fas fa-print"></span>
                            
                        
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
