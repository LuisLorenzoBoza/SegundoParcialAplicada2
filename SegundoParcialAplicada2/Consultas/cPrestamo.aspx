<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cPrestamo.aspx.cs" Inherits="SegundoParcialAplicada2.Consultas.cPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="h2">Consulta de Prestamos</h2>
        <hr />
        <form runat="server">
            <div class="row" >
                <div class="col-md-2">
                    <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>Todo</asp:ListItem>
                        <asp:ListItem>Todo por Fecha</asp:ListItem>
                        <asp:ListItem>Id del Préstamo</asp:ListItem>
                        <asp:ListItem>Id de la Cuenta</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--Criterio--%>
                <div class="form-group col-md-3">
                    <asp:Label ID="Label1" runat="server">Criterio</asp:Label>
                    <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="FiltroTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="BuscarButton" runat="server" Class="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click" />
                </div>
            </div>
            <br />
            <%--Rango fecha--%>
            <div class="form-row justify-content-center">
                <div class="form-group col-md-2">
                    <asp:Label Text="Desde" runat="server" />
                    <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Label Text="Hasta" runat="server" />
                    <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
            </div>
            
            <%--GRID--%>
            <div class="col-md-12">
                <asp:GridView ID="PrestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="LightSkyBlue" />
                            <Columns>
                                <asp:BoundField DataField="PrestamoId" HeaderText="Id del Préstamo" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="CuentaId" HeaderText="Id de la Cuenta" />
                                <asp:BoundField DataField="Capital" HeaderText="Capital" />
                                <asp:BoundField DataField="PctInteres" HeaderText="%Interés" />                                
                                <asp:BoundField DataField="TiempoMeses" HeaderText="Meses" />
                                <asp:BoundField DataField="Total" HeaderText="Total" />
                            </Columns>
                            <HeaderStyle BackColor="LightBlue" Font-Bold="True" />
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

