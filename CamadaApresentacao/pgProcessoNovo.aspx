<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInterna.master" AutoEventWireup="true" CodeBehind="pgProcessoNovo.aspx.cs" Inherits="CamadaApresentacao.pgProcessoNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConteudoInterno" runat="server">

    <!--Panel com as opções de gravar ou bucsar um processo-->
    <asp:Panel ID="pnlPesquisar" runat="server">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title">Processo</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:LinkButton ID="lkbNovo" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoProcessoModal"><i class="fa fa-plus-circle"> Novo Processo</i></asp:LinkButton>
                        <asp:LinkButton ID="lkbConsultar" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarProcessoModal"><i class="fa fa-search"> Buscar Processo</i></asp:LinkButton>
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

    <!--Script para reabrir modal Novo Processo-->
    <script type="text/javascript">
        function openNovoProcessoModal() {
            $('#NovoProcessoModal').modal('show');
        }
    </script>

    <!-- Modal Novo Processo-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoProcessoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 450px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblProcessoNovoTitulo" runat="server" Text="Novo processo" CssClass="fa fa-plus-circle"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdProcessoID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="*Data do Processo"></asp:Label>
                                        <asp:TextBox ID="txtProcessoData" runat="server" CssClass="form-control input-sm datepicker" data-mask="99/99/9999" placeholder="Clique e Selecione a Data do Processo."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="*N° do Processo:"></asp:Label>
                                        <asp:TextBox ID="txtProcessoNumero" runat="server" CssClass="form-control input-sm" placeholder="Digite o N° do Processo."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
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

    <!--Script para reabrir modal Novo Acampado-->
    <script type="text/javascript">
        function openGridViewProcessoModal() {
            $('#GridViewProcessoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Processo -->
    <div class="modal fade" id="GridViewProcessoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Processo</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvProcesso" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ProcessoID" OnSelectedIndexChanged="gvProcesso_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_ProcessoData" HeaderText="Data do Processo" />
                                                <asp:BoundField DataField="_ProcessoNumero" HeaderText="N° do Processo" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum Processo Encontrado.</EmptyDataTemplate>
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

    <!-- Modal Opções de Buscar Processo -->
    <div class="modal fade" id="BuscarProcessoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 600px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Opções de Busca</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-8 col-md-offset-1">
                                    <asp:TextBox ID="txtBuscarPorData" runat="server" CssClass="form-control input-sm datepicker" Width="377px" placeholder="Digite a Data do Processo." data-mask="99/99/9999"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="lkbBuscarPorData" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorNumero" runat="server" CssClass="form-control input-sm" placeholder="Digite o N° do processo."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarPorNumero" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!-- Modal excluir Processo -->
    <div class="modal fade" id="ExcluirModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 400px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Excluir?</h3>
                        </div>
                        <div class="panel-body">
                            <h5><strong>Tem Certeza que Deseja Excluir este Processo ?</strong></h5>

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
