<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInterna.master" AutoEventWireup="true" CodeBehind="pgRequisicaoNovo.aspx.cs" Inherits="CamadaApresentacao.pgRequisicaoNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConteudoInterno" runat="server">

    <!--Área da Requisição-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------->

    <!--textbox para receber o id retornado da requisição-->
    <div class="row">
        <div class="col-md-2">
            <asp:TextBox ID="txtRequisicaoID" runat="server" Visible="false"></asp:TextBox>
        </div>
    </div>

    <!--Panel com os contadores de requisição por situação e  as opções de gravar ou buscar uma Requisição-->
    <asp:Panel ID="pnlPesquisar" runat="server">
        <div class="panel panel-success">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-2">
                        <h3 class="panel-title"><strong>Requisição</strong></h3>
                    </div>
                    <div class="col-md-offset-6">
                        <asp:ScriptManager ID="ScriptManagerGeral" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanelContadores" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="TimerAtualizacaoContadores" runat="server" Interval="1000" OnTick="TimerAtualizacaoContadores_Tick"></asp:Timer>
                                <button class="btn btn-warning btn-sm" type="button">
                                    Em Aberto <span class="badge" style="background-color:white";>
                                        <asp:Label ID="lblQtdeRequisicoesEmAberto" runat="server" ForeColor="Black"></asp:Label></span>
                                </button>
                                <button class="btn btn-danger btn-sm" type="button">
                                    Pendente <span class="badge"   style="background-color:white";>
                                        <asp:Label ID="lblQtdeRequisicoesPendentes" runat="server" ForeColor="Black"></asp:Label></span>
                                </button>
                                <button class="btn btn-primary btn-sm" type="button">
                                    Finalizado <span class="badge"   style="background-color:white";>
                                        <asp:Label ID="lblQtdeRequisicoesFinalizadas" runat="server" ForeColor="Black"></asp:Label></span>
                                </button>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:LinkButton ID="lkbNovo" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbNovo_Click"><i class="fa fa-plus-circle"> Nova Requisição</i></asp:LinkButton>
                        <asp:LinkButton ID="lkbConsultar" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarRequisicaoModal"><i class="fa fa-search"> Buscar Requisição</i></asp:LinkButton>
                    </div>
                </div>
            </div>

            <!--Painel com as requisições na tela inicial-->
            <div class="panel panel-success">
                <div class="panel-body">
                    <asp:Panel ID="pnlScroll" runat="server" Height="300px" ScrollBars="Vertical">
                        <div class="table-responsive">
                            <asp:UpdatePanel ID="UpdatePaneTelaPrincipal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <asp:Timer ID="timerAtualizacaoTelaPrincipal" Interval="1000" runat="server" OnTick="timerAtualizacaoTelaPrincipal_Tick"></asp:Timer>
                                    <asp:GridView ID="gvRequisicaoTelaPrincipal" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_RequisicaoID" OnSelectedIndexChanged="gvRequisicaoTelaPrincipal_SelectedIndexChanged" OnDataBound="gvRequisicaoTelaPrincipal_DataBound">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbSelecionarTelaPrincipal" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="_DataCadastro" HeaderText="Data da Requisição" />
                                            <asp:BoundField DataField="_Codigo" HeaderText="Requisição N°" />
                                            <asp:BoundField DataField="_Requisitante._RequisitanteNome" HeaderText="Requisitante" />
                                            <asp:BoundField DataField="_Usuario._UsuarioNome" HeaderText="Cadastrado por" />
                                            <asp:BoundField DataField="_Usuario._Area._AreaNome" HeaderText="do Setor" />
                                            <asp:TemplateField HeaderText="Situação" ControlStyle-Width="75px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSituacao" runat="server" Text='<%# Eval("_Situacao._SituacaoNome") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         </Columns>
                                        <EmptyDataTemplate>
                                            <h4><strong>Nenhuma Requisição Aberta ou Pendente.</strong></h4>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="timerAtualizacaoTelaPrincipal" />
                                    <asp:PostBackTrigger ControlID="gvRequisicaoTelaPrincipal" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </asp:Panel>

    <!--Script para reabrir modal Nova/atualizar Requisição-->
    <script type="text/javascript">
        function openNovaRequisicaoModal() {
            $('#NovaRequisicaoModal').modal('show');
        }
    </script>

    <!-- Modal Nova/atualizar Requisição-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovaRequisicaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblRequisicaoNovoTitulo" runat="server" Text="Nova Requisição" CssClass="fa fa-plus-circle"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdRequisicaoID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="*Data da Requisição:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroRequisicao" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="*Requisição N°:"></asp:Label>
                                        <asp:TextBox ID="txtRequisicaoCodigo" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtRequisitanteCodigo" runat="server" CssClass="form-control input-sm" placeholder="Código." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:HiddenField ID="hdRequisitanteID" runat="server" Value="0" />
                                            <asp:TextBox ID="txtRequisitanteNome" runat="server" CssClass="form-control input-sm" placeholder="Requisitante." ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarRequisitanteModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarRequisitanteModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovoRequisitanteModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoRequisitanteModal"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtEnderecoCodigo" runat="server" CssClass="form-control input-sm" placeholder="Código." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:HiddenField ID="hdEnderecoID" runat="server" Value="0" />
                                            <asp:TextBox ID="txtEnderecoDescricao" runat="server" CssClass="form-control input-sm" placeholder="Endereço." ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarEnderecoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarEnderecoModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovoEnderecoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoEnderecoModal"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:HiddenField ID="hdSituacaoID" runat="server" Value="0" />
                                            <asp:TextBox ID="txtSituacaoNome" runat="server" CssClass="form-control input-sm" placeholder="Situação." ReadOnly="true" Width="940"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarSituacaoModal" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarSituacao_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovaSituacaoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovaSituacaoModal"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label13" runat="server" Text="*Observação:"></asp:Label>
                                        <asp:TextBox ID="txtRequisicaoObservacao" runat="server" CssClass="form-control input-sm " TextMode="MultiLine" Rows="5" placeholder="Digite uma Observação."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:HiddenField ID="hdUsuarioID" runat="server" Value="0" />
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

    <!--Script para reabrir modal Detalhes da Requisição-->
    <script type="text/javascript">
        function openRequisicaoDetalhesModal() {
            $('#RequisicaoDetalhesModal').modal('show');
        }
    </script>

    <!-- Modal Detalhes Requisição-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="RequisicaoDetalhesModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Detalhes da Requisição</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdDetalhesRequisicaoID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-6 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Text="Data da Requisição:"></asp:Label></strong>
                                        <asp:Label ID="lblDataCadastroRequisicao" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label7" runat="server" Text="Requisição N°:"></asp:Label></strong>
                                        <asp:Label ID="lblRequisicaoCodigo" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label10" runat="server" Text="Código:"></asp:Label></strong>
                                        <asp:Label ID="lblRequisitanteCodigo" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label20" runat="server" Text="Requisitante:"></asp:Label></strong>
                                        <asp:Label ID="lblRequisitanteNome" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label22" runat="server" Text="Código:"></asp:Label></strong>
                                        <asp:Label ID="lblEnderecoCodigo" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label24" runat="server" Text="Endereço:"></asp:Label></strong>
                                        <asp:Label ID="lblEnderecoDescricao" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label23" runat="server" Text="Situação:"></asp:Label></strong>
                                        <asp:Label ID="lblSituacaoNome" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label8" runat="server" Text="Observação:"></asp:Label></strong>
                                        <br />
                                        <asp:TextBox ID="txtRequisicaoObservacaoDetalhes" runat="server" Width="800px" TextMode="MultiLine" Rows="5" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label9" runat="server" Text="Cadastrado por:"></asp:Label></strong>
                                        <asp:Label ID="lblUsuarioNome" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label31" runat="server" Text="do Setor:"></asp:Label></strong>
                                        <asp:Label ID="lblUsuarioArea" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbAtualizarDetalhes" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbAtualizarDetalhes_Click"><i class="fa fa-pencil"> Atualizar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbVisualizarGridViewItemRequisicaoDetalhesModal" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbVisualizarGridViewItemRequisicaoDetalhesModal_Click"><i class="fa fa-check"> Visualizar Produtos</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarDetalhes" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarDetalhes_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Script para reabrir modal grid view Requisição-->
    <script type="text/javascript">
        function openGridViewRequisicaoModal() {
            $('#GridViewRequisicaoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Requisição -->
    <div class="modal fade" id="GridViewRequisicaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione uma Requisição</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvRequisicao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_RequisicaoID" OnSelectedIndexChanged="gvRequisicao_SelectedIndexChanged" OnDataBound="gvRequisicao_DataBound">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data da requisição" />
                                                <asp:BoundField DataField="_Codigo" HeaderText="Requisição N°" />
                                                <asp:BoundField DataField="_Requisitante._RequisitanteNome" HeaderText="Requisitante" />
                                                <asp:BoundField DataField="_Usuario._UsuarioNome" HeaderText="Cadastrado por" />
                                                <asp:BoundField DataField="_Usuario._Area._AreaNome" HeaderText="do Setor" />
                                                <asp:TemplateField HeaderText="Situação" ControlStyle-Width="75px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSituacao" runat="server" Text='<%# Eval("_Situacao._SituacaoNome") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhuma Requisição Encontrada.</EmptyDataTemplate>
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

    <!-- Modal Opções de Buscar uma Requisição -->
    <div class="modal fade" id="BuscarRequisicaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
                                    <asp:TextBox ID="txtBuscarPorData" runat="server" CssClass="form-control input-sm datepicker" data-mask="99/99/9999" Width="378px" placeholder="Selecione a data da requisição."></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="lkbBuscar1" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 col-md-offset-1">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtBuscarPorDataInicial" runat="server" CssClass="form-control input-sm datepicker" data-mask="99/99/9999" Width="180px" placeholder="Selecione a data inicial."></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtBuscarPorDataFinal" runat="server" CssClass="form-control input-sm datepicker" data-mask="99/99/9999" Width="189px" placeholder="Selecione a data final."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="lkbBuscar2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o n° da requisição."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscar3" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorRequisitante" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome do requisitante."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarRequisicaoPorRequisitante" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarRequisicaoPorRequisitante_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorSituacao" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome da situação."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarRequisicaoPorSituacao" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarRequisicaoPorSituacao_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorUsuario" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome do funcionário."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarRequisicaoPorUsuario" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarRequisicaoPorUsuario_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Gridview para selecionar uma situação para buscar as requisições------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal Buscar as requisições por Situação-->
    <script type="text/javascript">
        function openGridViewBuscarRequisicaoPorSituacaoModal() {
            $('#GridViewBuscarRequisicaoPorSituacaoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Situação ------------------------------------------------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="GridViewBuscarRequisicaoPorSituacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione uma Situação</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvBuscarRequisicaoPorSituacao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_SituacaoID" OnSelectedIndexChanged="gvBuscarRequisicaoPorSituacao_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_SituacaoNome" HeaderText="Situação" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhuma Situação Encontrada.</EmptyDataTemplate>
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

    <!--Gridview para selecionar um usuário para buscar as requisições------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal Buscar as requisições por usuário-->
    <script type="text/javascript">
        function openGridViewBuscarRequisicaoPorUsuarioModal() {
            $('#GridViewBuscarRequisicaoPorUsuarioModal').modal('show');
        }
    </script>

    <!-- Modal GridView usuário ------------------------------------------------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="GridViewBuscarRequisicaoPorUsuarioModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 950px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Funcionário</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvBuscarRequisicaoPorUsuario" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_UsuarioID" OnSelectedIndexChanged="gvBuscarRequisicaoPorUsuario_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_UsuarioNome" HeaderText="Nome" />
                                                <asp:BoundField DataField="_Area._AreaNome" HeaderText="Área" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum Usuário Encontrado.</EmptyDataTemplate>
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

    <!--Gridview para selecionar um requisitante para buscar as requisições------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal Buscar as requisições por requisitante-->
    <script type="text/javascript">
        function openGridViewBuscarRequisicaoPorRequisitanteModal() {
            $('#GridViewBuscarRequisicaoPorRequisitanteModal').modal('show');
        }
    </script>

    <!-- Modal GridView Requisitante ------------------------------------------------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="GridViewBuscarRequisicaoPorRequisitanteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Requisitante</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvBuscarRequisicaoPorRequisitante" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_RequisitanteID" OnSelectedIndexChanged="gvBuscarRequisicaoPorRequisitante_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_RequisitanteNome" HeaderText="Requisitante" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum requisitante encontrado.</EmptyDataTemplate>
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

    <!-- Modal excluir Requisicao ------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="ExcluirModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 450px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Excluir?</h3>
                        </div>
                        <div class="panel-body">
                            <h5><strong>Tem Certeza que Deseja Excluir esta Requisição ?</strong></h5>

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

    <!--Área Item da Requisição----------------------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal para Adicionar Item da Requisição-->
    <script type="text/javascript">
        function openAdicionarItemRequisicaoModal() {
            $('#AdicionarItemRequisicaoModal').modal('show');
        }
    </script>

    <!-- Modal Adicionar item da requisição -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="AdicionarItemRequisicaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 450px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Adicionar?</h3>
                        </div>
                        <div class="panel-body">
                            <h5><strong>Você Deseja Adicionar os Produtos ?</strong></h5>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:LinkButton ID="lkbAdicionarItemRequisicaoModal" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbAdicionarItemRequisicaoModal_Click"><i class="fa fa-check"> Adicionar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarAdicionarItemRequisicaoModal" runat="server" CssClass="btn btn-default btn-sm" OnClick="lkbCancelarAdicionarItemRequisicaoModal_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!--Script para reabrir modal adicionar item da requisição-->
    <script type="text/javascript">
        function openGridViewItemRequisicaoModal() {
            $('#GridViewItemRequisicaoModal').modal('show');
        }
    </script>

    <!-- Modal GridView item da  Requisição -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewItemRequisicaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Adicionar Produtos da Requisição</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <!--hidden field com o id da requisição retornada-->
                                        <asp:HiddenField ID="hdRequisicaoIDRetornado" runat="server" Value="0" />

                                        <asp:LinkButton ID="lkbNovoProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoProdutoModal"><i class="fa fa-plus-circle">Adicionar Produto</i></asp:LinkButton>
                                        <asp:LinkButton ID="lkbBuscarProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarProdutoModal" Visible="false"><i class="fa fa-search">Buscar</i></asp:LinkButton>

                                        <asp:GridView ID="gvItemRequisicao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemRequisicaoID"  OnRowUpdating="gvItemRequisicao_RowUpdating" OnRowDeleting="gvItemRequisicao_RowDeleting" >
                                            <Columns>
                                                <asp:BoundField DataField="_Produto._Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" />
                                                <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." />
                                                <asp:BoundField DataField="_Produto._QuantidadeSolicitada" HeaderText="Qtde Solicitada" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Produto._QuantidadeAtendida" HeaderText="Qtde Atendida" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Produto._Conta._ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_Produto._ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                                <asp:BoundField DataField="_Produto._ProdutoValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbEditarItemRequisicao" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Update"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbExcluirItemRequisicao" runat="server" CausesValidation="False" CssClass="btn btn-danger btn-xs" CommandName="Delete" OnClientClick="return confirm('Excluir Este Produto da Requisição?');"><i class="fa fa-times"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum Produto Adicionado.</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="lkbFinalizarAdicionarItemModal" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbFinalizarAdicionarItemModal_Click"><i class="fa fa-check"> Finalizar</i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Script para reabrir modal adicionar item da requisição Detalhes-->
    <script type="text/javascript">
        function openGridViewItemRequisicaoDetalhesModal() {
            $('#GridViewItemRequisicaoDetalhesModal').modal('show');
        }
    </script>

    <!-- Modal GridView item da  Requisição detalhes -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewItemRequisicaoDetalhesModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">Lista de Produtos da Requisição</h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvItemRequisicaoDetalhes" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemRequisicaoID">
                                            <Columns>
                                                <asp:BoundField DataField="_Produto._Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" />
                                                <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." />
                                                <asp:BoundField DataField="_Produto._QuantidadeSolicitada" HeaderText="Qtde Solicitada" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Produto._QuantidadeAtendida" HeaderText="Qtde Atendida" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Produto._Conta._ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_Produto._ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                                <asp:BoundField DataField="_Produto._ProdutoValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" />
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum Produto Adicionado.</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="lkbVisualizarRequisicaoDetalhesModal" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVisualizarRequisicaoDetalhesModal_Click"><i class="fa fa-reply"> Voltar</i></asp:LinkButton>
                        </div>
                        <div class="row">
                            <div class="col-md-2 col-md-offset-7">
                                <strong>
                                    <asp:Label ID="lblRotuloValorTotalGeralDetalhes" runat="server" Text="Total Geral: "></asp:Label>
                                </strong>
                                <asp:Label ID="lblValorTotalGeralDetalhes" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Área do Requisitante---------------------------------------------------------------------------------------------------------------------->
    <!-- Modal Novo Requisitante-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoRequisitanteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1000px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Novo Requisitante</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdRequisitanteModalID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label25" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroRequisitante" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label26" runat="server" Text="*Código:"></asp:Label>
                                        <asp:TextBox ID="txtRequisitanteCodigoModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="Label27" runat="server" Text="*Requisitante:"></asp:Label>
                                        <asp:TextBox ID="txtRequisitanteNomeModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do Requisitante"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvarRequisitante" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvarRequisitante_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarRequisitante" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarRequisitante_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Opções de Buscar um Requisitante -->
    <div class="modal fade" id="BuscarRequisitanteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
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
                                        <asp:TextBox ID="txtBuscarRequisitantePorCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o código do requisitante."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarRequisitante" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarRequisitante_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarRequisitantePorNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome do requisitante."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarRequisitante2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarRequisitante_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Script para reabrir modal Novo Requisitante-->
    <script type="text/javascript">
        function openGridViewRequisitanteModal() {
            $('#GridViewRequisitanteModal').modal('show');
        }
    </script>

    <!-- Modal GridView Requisitante -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewRequisitanteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:LinkButton ID="lkbVoltarRequisitante" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVoltarRequisitante_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Requisitante</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvRequisitante" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_RequisitanteID" OnSelectedIndexChanged="gvRequisitante_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_RequisitanteNome" HeaderText="Requisitante" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum requisitante encontrado.</EmptyDataTemplate>
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

    <!--Área do Endereço-------------------------------------------------------------------------------------------------------------------------->
    <!-- Modal Novo Endereço-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoEnderecoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 900px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Novo Endereço</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdEnderecoModalID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroEndereco" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label6" runat="server" Text="*Código:"></asp:Label>
                                        <asp:TextBox ID="txtEnderecoCodigoModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="Label28" runat="server" Text="*Endereço:"></asp:Label>
                                        <asp:TextBox ID="txtEnderecoDescricaoModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Endereço" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvarEndereco" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvarEndereco_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarEndereco" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarEndereco_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Opções de Buscar um Endereço -->
    <div class="modal fade" id="BuscarEnderecoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 900px;" role="document">
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
                                        <asp:TextBox ID="txtBuscarEnderecoPorCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o código do endereço."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarEndereco" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarEndereco_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarEnderecoPorDescricao" runat="server" CssClass="form-control input-sm" placeholder="Digite o endereço." TextMode="MultiLine"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarEndereco2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarEndereco_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Script para reabrir modal GridView Endereço-->
    <script type="text/javascript">
        function openGridViewEnderecoModal() {
            $('#GridViewEnderecoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Endereço -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewEnderecoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1000px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:LinkButton ID="lkbVoltarEndereco" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVoltarEndereco_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Endereço</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvEndereco" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_EnderecoID" OnSelectedIndexChanged="gvEndereco_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_EnderecoDescricao" HeaderText="Endereço" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum endereço encontrado.</EmptyDataTemplate>
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

    <!--Área da Situação-------------------------------------------------------------------------------------------------------------------------------->
    <!-- Modal Nova Situação-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovaSituacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 400px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Nova Situação</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdSituacaoModalID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label29" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroSituacao" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label30" runat="server" Text="*Situação:"></asp:Label>
                                        <asp:TextBox ID="txtSituacaoNomeModal" runat="server" CssClass="form-control input-sm " placeholder="Digite o Nome da Situação."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvarSituacao" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvarSituacao_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarSituacao" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarSituacao_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Opções de Buscar uma Situação -->
    <div class="modal fade" id="BuscarSituacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 600px;" role="document">
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
                                        <asp:TextBox ID="txtBuscarSituacaoPorNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome da situação."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarSituacao" runat="server" CssClass="btn btn-success btn-sm"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Script para reabrir modal Nova Situação-->
    <script type="text/javascript">
        function openGridViewSituacaoModal() {
            $('#GridViewSituacaoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Situação -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewSituacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:LinkButton ID="lkbVoltarSituacao" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVoltarSituacao_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione uma Situação</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvSituacao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_SituacaoID" OnSelectedIndexChanged="gvSituacao_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_SituacaoNome" HeaderText="Situação" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhuma Situação Encontrada.</EmptyDataTemplate>
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

    <!--Área do Produto----------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal Novo Produto-->
    <script type="text/javascript">
        function openNovoProdutoModal() {
            $('#NovoProdutoModal').modal('show');
        }
    </script>

    <!-- Modal Novo Produto -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog " style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Novo Produto</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdProdutoID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroProduto" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control input-sm" placeholder="Código." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtProdutoNome" runat="server" CssClass="form-control input-sm" placeholder="Nome do Produto." ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarNomeProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarNomeProdutoModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovoMomeProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoNomeProdutoModalModal" Visible="false"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:HiddenField ID="hdUnidadeID" runat="server" Value="0" />
                                        <asp:TextBox ID="txtUnidadeDescricao" runat="server" CssClass="form-control input-sm" placeHolder="Selecione a Unidade." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label12" runat="server" Text="*Quantidade Solicitada:"></asp:Label>
                                        <asp:TextBox ID="txtQuantidadeSolicitada" runat="server" CssClass="form-control input-sm" placeholder="Digite a Quantidade Solicitada." Text="0"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="lblQuantidadeAtendidaRotulo" runat="server" Text="*Quantidade Atendida:"></asp:Label>
                                        <asp:TextBox ID="txtQuantidadeAtendida" runat="server" CssClass="form-control input-sm" placeholder="Digite a Quantidade Atendida." Text="0"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label15" runat="server" Text="Preço Unitário:"></asp:Label>
                                        <asp:TextBox ID="txtProdutoPrecoUnitario" runat="server" CssClass="form-control input-sm mascaraMonetaria" placeholder="Preço Unitário." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtContaNumero" runat="server" CssClass="form-control input-sm" placeHolder="Código da Conta." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:HiddenField ID="hdContaID" runat="server" Value="0" />
                                        <asp:TextBox ID="txtConta" runat="server" CssClass="form-control input-sm" placeHolder="Conta." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvarProduto" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvarProduto_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarProduto" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarProduto_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Buscar Produto -->
    <div class="modal fade" id="BuscarProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 600px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Opções de Pesquisa</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarProdutoPorCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código do Produto."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarProduto" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarProduto_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarProdutoPorNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do Produto."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarProduto2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarProduto_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Script para abrir GridView Produto Modal-->
    <script type="text/javascript">
        function openGridViewProdutoModal() {
            $('#GridViewProdutoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Produto -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Produto</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvProduto" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ProdutoID" OnSelectedIndexChanged="gvProduto_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_ProdutoNome" HeaderText="Produto" />
                                                <asp:BoundField DataField="_Unidade._UnidadeDescricao" HeaderText="Unid." />
                                                <asp:BoundField DataField="_QuantidadeSolicitada" HeaderText="Qtde Solicitada" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_QuantidadeAtendida" HeaderText="Qtde Atendida" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Conta._ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                                <asp:BoundField DataField="_ProdutoValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum Produto Encontrado.</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="lkbVisualizarGridViewItemRequisicaoModal" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVisualizarGridViewItemRequisicaoModal_Click"><i class="fa fa-reply"> Voltar</i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Área da Conta-------------------------------------------------------------------------------------------------------------------------------------------->
    <!-- Modal Nova Conta -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovaContaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog " style="width: 1000px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Nova Conta</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdContaModalID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="lblDataCadastroConta" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroConta" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label16" runat="server" Text="*Código:"></asp:Label>
                                        <asp:TextBox ID="txtContaNumeroModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código."></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="Label17" runat="server" Text="*Conta:"></asp:Label>
                                        <asp:TextBox ID="txtContaDescricao" runat="server" CssClass="form-control input-sm " placeholder="Digite a Conta."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvarConta" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvarConta_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarConta" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarConta_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Buscar Conta -->
    <div class="modal fade" id="BuscarContaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Opções de Pesquisa</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarContaPorNumero" runat="server" CssClass="form-control input-sm" placeholder="Digite o código da conta."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarConta" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarConta_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarContaPorDescricao" runat="server" CssClass="form-control input-sm" placeholder="Digite a descrição da Conta."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarConta2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarConta_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Script para abrir GridView Conta Modal-->
    <script type="text/javascript">
        function openGridViewContaModal() {
            $('#GridViewContaModal').modal('show');
        }
    </script>

    <!-- Modal GridView Conta -->
    <div class="modal fade" id="GridViewContaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione uma Conta</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvConta" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ContaID" OnSelectedIndexChanged="gvConta_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_ContaNumero" HeaderText="Código" />
                                                <asp:BoundField DataField="_ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_TipoConta" HeaderText="Tipo da Conta" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhuma Conta Encontrada.</EmptyDataTemplate>
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

    <!--Área da Unidade----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!-- Modal Nova Unidade -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovaUnidadeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 400px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Nova Unidade</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdUnidadeModalID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label18" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroUnidade" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label19" runat="server" Text="*Descrição da Unidade:"></asp:Label>
                                        <asp:TextBox ID="txtUnidadeDescricaoModal" runat="server" CssClass="form-control input-sm " placeholder="Digite a Descrição da Unidade."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvarUnidade" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvarUnidade_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarUnidade" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarUnidade_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Buscar Unidade -->
    <div class="modal fade" id="BuscarUnidadeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 600px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Opções de Pesquisa</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarUnidadePorDescricao" runat="server" CssClass="form-control input-sm" placeholder="Digite a descrição da unidade."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarUnidade" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarUnidade_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Script para abrir GridView Fornecedor Modal-->
    <script type="text/javascript">
        function openGridViewUnidadeModal() {
            $('#GridViewUnidadeModal').modal('show');
        }
    </script>

    <!-- Modal GridView Unidade -->
    <div class="modal fade" id="GridViewUnidadeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione uma Unidade</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvUnidade" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_UnidadeID" OnSelectedIndexChanged="gvUnidade_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_UnidadeDescricao" HeaderText="Unidade" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhuma Unidade Encontrada.</EmptyDataTemplate>
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

    <!--Área do Nome do Produto----------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!-- Modal Novo Nome do Produto -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoNomeProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog " style="width: 1050px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Novo Nome do Produto</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdNomeProdutoID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label11" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroNomeProduto" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label21" runat="server" Text="*Código:"></asp:Label>
                                        <asp:TextBox ID="txtCodigoModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código."></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="Label32" runat="server" Text="*Produto:"></asp:Label>
                                        <asp:TextBox ID="txtProdutoNomeModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do Produto."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:HiddenField ID="hdUnidadeIDProdutoNome" runat="server" Value="0" />
                                            <asp:TextBox ID="txtUnidadeDescricaoProdutoNome" runat="server" CssClass="form-control input-sm" placeHolder="Selecione a Unidade." ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarUnidadeModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarUnidadeModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovaUnidadeModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovaUnidadeModal" Visible="false"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label33" runat="server" Text="*Preço Unitário:"></asp:Label>
                                        <asp:TextBox ID="txtProdutoPrecoUnitarioProdutoNome" runat="server" CssClass="form-control input-sm mascaraMonetaria" placeholder="Digite o Preço Unitário."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtContaNumeroProdutoNome" runat="server" CssClass="form-control input-sm" placeHolder="Código da Conta." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:HiddenField ID="hdContaIDProdutoNome" runat="server" Value="0" />
                                            <asp:TextBox ID="txtContaProdutoNome" runat="server" CssClass="form-control input-sm" placeHolder="Conta." ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarContaModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarContaModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovaContaMocial" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovaContaModal" Visible="false"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvarNomeProduto" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvarNomeProduto_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarNomeProduto" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarNomeProduto_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Buscar nome do Produto -->
    <div class="modal fade" id="BuscarNomeProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 600px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Opções de Pesquisa</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarNomeProdutoPorCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código do Produto."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarNomeProduto" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarNomeProduto_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarNomeProdutoPorNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do Produto."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarNomeProduto2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarNomeProduto_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Script para abrir GridView nome do Produto Modal-->
    <script type="text/javascript">
        function openGridViewNomeProdutoModal() {
            $('#GridViewNomeProdutoModal').modal('show');
        }
    </script>

    <!-- Modal GridView nome do Produto -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewNomeProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:LinkButton ID="lkbVoltarNomeProduto" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVoltarNomeProduto_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Nome do Produto</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvNomeProduto" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_NomeProdutoID" OnSelectedIndexChanged="gvNomeProduto_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_ProdutoNome" HeaderText="Produto" />
                                                <asp:BoundField DataField="_Unidade._UnidadeDescricao" HeaderText="Unid." />
                                                <asp:BoundField DataField="_Conta._ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum Nome do Produto Encontrado.</EmptyDataTemplate>
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
</asp:Content>
