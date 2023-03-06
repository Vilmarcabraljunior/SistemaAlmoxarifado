<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInterna.master" AutoEventWireup="true" CodeBehind="pgFornecedorNovo.aspx.cs" Inherits="CamadaApresentacao.pgFornecedorNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConteudoInterno" runat="server">
    <!--Área do Fornecedor--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Panel para gravar ou buscar um Fornecedor-->
    <asp:Panel ID="pnlPesquisar" runat="server">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title">Fornecedor</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:LinkButton ID="lkbNovo" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbNovo_Click"><i class="fa fa-plus-circle"> Novo Fornecedor</i></asp:LinkButton>
                        <asp:LinkButton ID="lkbConsultar" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarFornecedorModal"><i class="fa fa-search">Buscar Fornecedor</i></asp:LinkButton>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </asp:Panel>

    <!--Script para reabrir modal Novo Fornecedor-->
    <script type="text/javascript">
        function openNovoFornecedorModal() {
            $('#NovoFornecedorModal').modal('show');
        }
    </script>

    <!-- Modal Novo Fornecedor -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoFornecedorModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblFornecedorNovoTitulo" runat="server" Text="Novo Fornecedor" CssClass="fa fa-plus-circle"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdFornecedorID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-9 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Data do Cadastro"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastro" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="*Fornecedor:"></asp:Label>
                                        <asp:TextBox ID="txtFornecedorNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do Fornecedor."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvar" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvar_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbExcluirModal" runat="server" CssClass="btn btn-danger btn-sm" data-toggle="modal" data-target="#ExcluirModal"><i class="fa fa-times"> Excluir</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelar" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelar_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Script para reabrir modal Novo Fornecedor-->
    <script type="text/javascript">
        function openGridViewFornecedorModal() {
            $('#GridViewFornecedorModal').modal('show');
        }
    </script>

    <!-- Modal GridView com os dados do Fornecedor -->
    <div class="modal fade" id="GridViewFornecedorModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Fornecedor</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvFornecedor" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_FornecedorID" OnSelectedIndexChanged="gvFornecedor_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_FornecedorNome" HeaderText="Fornecedor" />

                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum Fornecedor Encontrado.</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Opções de Buscar Fornecedor -->
    <div class="modal fade" id="BuscarFornecedorModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Opções de Busca</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome do fornecedor."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarFornecedor" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal para excluir um Fornecedor-->
    <div class="modal fade" id="ExcluirModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 450px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Excluir ?</h3>
                        </div>
                        <div class="panel-body">
                            <h5><strong>Tem Certeza que Deseja Excluir este Fornecedor ?</strong></h5>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:LinkButton ID="lkbExcluir" runat="server" CssClass="btn btn-danger btn-sm" OnClick="lkbExcluir_Click"><i class="fa fa-times"> Excluir</i></asp:LinkButton>
                                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
