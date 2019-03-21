<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cCuentaBancaria.aspx.cs" Inherits="SegundoParcialAplicada2.Consultas.cCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <h2 class="h2">Consulta de Cuentas</h2>
    <hr />
    <form runat="server">
            <div class="row" >
                <div class="col-md-2">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>Todo</asp:ListItem>
                        <asp:ListItem>Todo por Fecha</asp:ListItem>
                        <asp:ListItem>Id del Depósito</asp:ListItem>
                        <asp:ListItem>Id de la Cuenta</asp:ListItem>
                        <asp:ListItem>Concepto</asp:ListItem>
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


        <%--Criterio--%>
                <div class="form-group col-md-3">
                    <asp:Label ID="Label1" runat="server">Criterio</asp:Label>
                    <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
                </div>    
        <%--GRID--%>
            <div class="form-row justify-content-center">
            </div>
        <%--Rango fecha--%>
            <div class="form-row justify-content-center">
                <div class="form-group col-md-2">
                    <asp:Label Text="Desde" runat="server" />
                    <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />

                </div>
                <div class="form-group col-md-2">
                    <asp:Label Text="Hasta" runat="server" />
                 <asp:GridView ID="CuentaBancariaGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="763px">
                            <AlternatingRowStyle BackColor="LightSkyBlue" />
                            <Columns>
                                <asp:BoundField DataField="DepositoId" HeaderText="Id Depósito" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="CuentaId" HeaderText="Id de Cuenta" />
                                <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                                <asp:BoundField DataField="Monto" HeaderText="Monto Depositado" />
                            </Columns>
                            <HeaderStyle BackColor="LightBlue" Font-Bold="True" />
                 </asp:GridView>
                    <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
            </div>
        <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                     <asp:Button ID="ImprimirButton" CssClass="btn btn-outline-info mt-4" runat="server" Text="Imprimir" OnClick="ImprimirButton_Click" />
                        <span class="fas fa-print"></span>
                            
                        
                    </div>
                </div>
            </div>

      </form >  
        
    </div>

</asp:Content>

