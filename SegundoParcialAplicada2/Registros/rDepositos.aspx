<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="SegundoParcialAplicada2.Registros.rDepositos" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="form-row justify-content-center">
        
            <div class="card">
                <div class="card-header text-uppercase text-center">Depósitos</div>
                <article class="card-body">
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                    <asp:TextBox class="form-control" ID="depositoIdTextBox" type="number" Text="0" runat="server" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="depositoIdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ValidationExpression="^[0-9]*$" ControlToValidate="depositoIdTextBox" ForeColor="Red" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server" Width="180px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Cuenta"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="cuentaDropDownList" runat="server" Width="180px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Concepto"></asp:Label>
                                    <asp:TextBox class="form-control" ID="conceptoTextBox" runat="server" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="conceptoRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="conceptoTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="conceptoREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="conceptoTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Monto"></asp:Label>
                                    <asp:TextBox class="form-control" ID="montoTextBox" type="number" Text="0" runat="server" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="montoRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="montoTextBox" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="montoREV" runat="server" ErrorMessage="Solo Números" ValidationExpression="^[0-9]*$" ControlToValidate="montoTextBox" ForeColor="Red" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <asp:ValidationSummary ID="DepositoVS" runat="server" />
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block; height: 33px;">
                                    <asp:Button Text="Nuevo" class="btn btn-dark btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click1"  />
                                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton"  ValidationGroup="Guardar" OnClick="GuadarButton_Click" />
                                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton"  />
                                </div>
                            </div>
                        </div>
                  
                </article>
            </div>
            <!-- card.// -->
    </div>
    <br>
</asp:Content>
