<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInterna.master" AutoEventWireup="true" CodeBehind="pgLicitacaoNovo.aspx.cs" Inherits="CamadaApresentacao.pgLicitacaoNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConteudoInterno" runat="server">

    <!--Área da Licitação-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Panel com as opções de gravar ou buscar uma Licitação-->
    <asp:TextBox ID="txtLicitacaoID" runat="server" Visible="false"></asp:TextBox>

    <asp:Panel ID="pnlPesquisar" runat="server">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title"><strong>Estoque Atual</strong></h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-2">
                        <asp:LinkButton ID="lkbNovo" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbAdicionarItemLicitacaoModal_Click"><i class="fa fa-plus-circle"> Adicionar Produto</i></asp:LinkButton>
                        <asp:LinkButton ID="lkbConsultar" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarLicitacaoModal" Visible="false"><i class="fa fa-search"> Buscar Estoque</i></asp:LinkButton>
                    </div>
                    <div class="col-md-3 col-md-offset-7">
                        <asp:LinkButton ID="lkbMostrarItensComEstoqueBaixo" runat="server" CssClass="btn btn-danger btn-sm" OnClick="lkbMostrarItensComEstoqueBaixo_Click"><i class="fa fa-search"> Produtos com estoque baixo</i></asp:LinkButton>
                    </div>
                </div>
            </div>
            <!--Painel com todos os itens do estoque na tela inicial-->
            <div class="panel panel-success">
                <div class="panel-body">
                    <asp:Panel ID="pnlScroll" runat="server" Height="300px" ScrollBars="Vertical">
                        <div class="table-responsive">
                            <asp:ScriptManager ID="ScriptManagerTelaPrincipal" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanelTelaPrincipal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <asp:Timer ID="timerAtualizacaoTelaPrincipal" Interval="1000" runat="server" OnTick="timerAtualizacaoTelaPrincipal_Tick"></asp:Timer>

                                    <asp:GridView ID="gvItemLicitacaoTelaPrincipal" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemLicitacaoID" OnRowUpdating="gvItemLicitacaoTelaPrincipal_RowUpdating" OnRowDeleting="gvItemLicitacaoTelaPrincipal_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbEditarItemLicitacao" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Update"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbExcluirItemLicitacao" runat="server" CausesValidation="False" CssClass="btn btn-danger btn-xs" CommandName="Delete" OnClientClick="return confirm('Excluir Este Produto do Estoque?');"><i class="fa fa-times"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="_Produto._Codigo" HeaderText="Código" />
                                            <asp:TemplateField HeaderText="Produto" ControlStyle-Width="300px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProdutoNome" runat="server" Text='<%# Eval("_Produto._ProdutoNome") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." />
                                            <asp:TemplateField HeaderText="Qtde em Estoque" ControlStyle-Width="75px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuantidadeEstoque" runat="server" Text='<%# Eval("_Produto._QuantidadeEstoque") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="_Produto._QuantidadeEstoque" HeaderText="Qtde em Estoque" DataFormatString="{0:n0}" />
                                            <asp:BoundField DataField="_Produto._Conta._ContaDescricao" HeaderText="Conta" />
                                            <asp:BoundField DataField="_Produto._ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                            <asp:BoundField DataField="_Produto._EstoqueValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <h4><strong>Estoque Vázio.</strong></h4>
                                        </EmptyDataTemplate>
                                    </asp:GridView>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="timerAtualizacaoTelaPrincipal" />
                                    <asp:PostBackTrigger ControlID="gvItemLicitacaoTelaPrincipal" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </asp:Panel>
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanelContadoresTelaPrincipal" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="timerContadoresTelaPrincipal" Interval="1000" runat="server" OnTick="timerContadoresTelaPrincipal_Tick"></asp:Timer>
                                <div class="col-md-3 col-md-offset-5">
                                    <strong>
                                        <asp:Label ID="Label6" runat="server" BackColor="LightGray" Text="Quantidade Geral: "></asp:Label>
                                        <asp:Label ID="lblQuantidadeTotalGeralTelaPrincipal" runat="server"></asp:Label>
                                    </strong>
                                </div>
                                <div class="col-md-3 col-md-offset-1">
                                    <strong>
                                        <asp:Label ID="Label4" runat="server" BackColor="LightGray" Text="Total Geral: "></asp:Label>
                                        <asp:Label ID="lblValorTotalGeralTelaPrincipal" runat="server"></asp:Label>
                                    </strong>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <!--Script para reabrir modal de produtos com o estoque baixo--------------------------------------------------------------------------->
    <script type="text/javascript">
        function opengvLicitacaoProdutoEstoqueBaixoModal() {
            $('#gvLicitacaoProdutoEstoqueBaixoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Lista de produtos com estoque baixo --------------------------------------------------------------------------------------------------->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="gvLicitacaoProdutoEstoqueBaixoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Produtos com o estoque baixo</strong></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                                        <asp:GridView ID="gvLicitacaoProdutoEstoqueBaixo" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:BoundField DataField="Código" HeaderText="Código" SortExpression="Código" />
                                                <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
                                                <asp:BoundField DataField="Qtde em Estoque" HeaderText="Qtde em Estoque" SortExpression="Qtde em Estoque" />
                                            </Columns>
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

    <!--Script para reabrir modal Nova/atualizar Licitação--------------------------------------------------------------------------->
    <script type="text/javascript">
        function openNovaLicitacaoModal() {
            $('#NovaLicitacaoModal').modal('show');
        }
    </script>

    <!-- Modal Nova/atualizar Licitação-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovaLicitacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblLicitacaoNovoTitulo" runat="server" Text="Novo Estoque" CssClass="fa fa-plus-circle"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdLicitacaoID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-5 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="*Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroLicitacao" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label13" runat="server" Text="*Observação:"></asp:Label>
                                        <asp:TextBox ID="txtObservacao" runat="server" CssClass="form-control input-sm " TextMode="MultiLine" Rows="5" placeholder="Digite uma Observação."></asp:TextBox>
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

    <!--Script para reabrir modal Detalhes da Licitação-->
    <script type="text/javascript">
        function openLicitacaoDetalhesModal() {
            $('#LicitacaoDetalhesModal').modal('show');
        }
    </script>

    <!-- Modal Detalhes Licitação-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="LicitacaoDetalhesModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Detalhes do Estoque</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdDetalhesLicitacaoID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-6 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Text="Data do Cadastro:"></asp:Label></strong>
                                        <asp:Label ID="lblDataCadastroLicitacao" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label8" runat="server" Text="Observação:"></asp:Label></strong>
                                        <br />
                                        <asp:TextBox ID="txtObservacaoDetalhes" runat="server" Width="550px" TextMode="MultiLine" Rows="5" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbAtualizarDetalhes" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbAtualizarDetalhes_Click"><i class="fa fa-pencil"> Atualizar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbVisualizarGridViewItemLicitacaoDetalhesModal" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbVisualizarGridViewItemLicitacaoDetalhesModal_Click"><i class="fa fa-check"> Visualizar Produtos</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarDetalhes" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarDetalhes_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Script para reabrir modal grid view Licitação-->
    <script type="text/javascript">
        function openGridViewLicitacaoModal() {
            $('#GridViewLicitacaoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Licitação -->
    <div class="modal fade" id="GridViewLicitacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1000px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um estoque</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvLicitacao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_LicitacaoID" OnSelectedIndexChanged="gvLicitacao_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum Estoque Encontrado.</EmptyDataTemplate>
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

    <!-- Modal Opções de Buscar uma Licitação -->
    <div class="modal fade" id="BuscarLicitacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
                                    <asp:TextBox ID="txtBuscarPorData" runat="server" CssClass="form-control input-sm datepicker" placeholder="Selecione a data do estoque." Width="378px" data-mask="99/99/9999"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="lkbBuscar" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>

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
                                        <asp:TextBox ID="txtBuscarPorUsuario" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome do usuário."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarLicitacaoPorUsuario" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarLicitacaoPorUsuario_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Gridview para selecionar um usuário para buscar as licitações------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal Buscar as licitações por usuário-->
    <script type="text/javascript">
        function openGridViewBuscarLicitacaoPorUsuarioModal() {
            $('#GridViewBuscarLicitacaoPorUsuarioModal').modal('show');
        }
    </script>

    <!-- Modal GridView usuário ------------------------------------------------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="GridViewBuscarLicitacaoPorUsuarioModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 800px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Usuário</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvBuscarLicitacaoPorUsuario" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_UsuarioID" OnSelectedIndexChanged="gvBuscarLicitacaoPorUsuario_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_UsuarioNome" HeaderText="Nome" />
                                                <asp:BoundField DataField="_UsuarioCpf" HeaderText="Cpf" />
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

    <!-- Modal excluir Licitação -->
    <div class="modal fade" id="ExcluirModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 450px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Excluir?</h3>
                        </div>
                        <div class="panel-body">
                            <h5><strong>Tem Certeza que Deseja Excluir este estoque ?</strong></h5>

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

    <!--Área Item da Licitação----------------------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal para Adicionar Item da Licitação-->
    <script type="text/javascript">
        function openAdicionarItemLicitacaoModal() {
            $('#AdicionarItemLicitacaoModal').modal('show');
        }
    </script>

    <!-- Modal Adicionar item da Licitação -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="AdicionarItemLicitacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                                    <asp:LinkButton ID="lkbAdicionarItemLicitacaoModal" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbAdicionarItemLicitacaoModal_Click"><i class="fa fa-check"> Adicionar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarAdicionarItemLicitacaoModal" runat="server" CssClass="btn btn-default btn-sm" OnClick="lkbCancelarAdicionarItemLicitacaoModal_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!--Script para reabrir modal adicionar item da Licitação-->
    <script type="text/javascript">
        function openGridViewItemLicitacaoModal() {
            $('#GridViewItemLicitacaoModal').modal('show');
        }
    </script>

    <!-- Modal GridView item da Licitação -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewItemLicitacaoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Adicionar Produtos no Estoque</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <!--hidden field com o id da Licitação retornada-->
                                        <asp:HiddenField ID="hdLicitacaoIDRetornado" runat="server" Value="0" />

                                        <asp:LinkButton ID="lkbNovoProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoProdutoModal"><i class="fa fa-plus-circle">Adicionar Produto</i></asp:LinkButton>
                                        <asp:LinkButton ID="lkbBuscarProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarProdutoModal" Visible="false"><i class="fa fa-search">Buscar</i></asp:LinkButton>

                                        <asp:GridView ID="gvItemLicitacao" runat="server" class="table busca table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemLicitacaoID" OnRowUpdating="gvItemLicitacao_RowUpdating" OnRowDeleting="gvItemLicitacao_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="_Produto._Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" />
                                                <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." />
                                                <asp:BoundField DataField="_Produto._QuantidadeEstoque" HeaderText="Qtde em Estoque" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Produto._Conta._ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_Produto._ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                                <asp:BoundField DataField="_Produto._EstoqueValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbEditarItemLicitacao" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Update"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbExcluirItemLicitacao" runat="server" CausesValidation="False" CssClass="btn btn-danger btn-xs" CommandName="Delete" OnClientClick="return confirm('Excluir Este Produto do Estoque?');"><i class="fa fa-times"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <h4><strong>Estoque Vázio.</strong></h4>
                                            </EmptyDataTemplate>
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

    <!--Script para reabrir modal adicionar item da Licitação Detalhes-->
    <script type="text/javascript">
        function openGridViewItemLicitacaoDetalhesModal() {
            $('#GridViewItemLicitacaoDetalhesModal').modal('show');
        }
    </script>

    <!-- Modal GridView item da Licitação detalhes -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewItemLicitacaoDetalhesModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">Lista de Produtos do Estoque</h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvItemLicitacaoDetalhes" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemLicitacaoID">
                                            <Columns>
                                                <asp:BoundField DataField="_Produto._Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" />
                                                <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." />
                                                <asp:BoundField DataField="_Produto._QuantidadeEstoque" HeaderText="Qtde em Estoque" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Produto._Conta._ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_Produto._ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                                <asp:BoundField DataField="_Produto._EstoqueValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" />
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
                            <asp:LinkButton ID="lkbVisualizarLicitacaoDetalhesModal" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVisualizarLicitacaoDetalhesModal_Click"><i class="fa fa-reply"> Voltar</i></asp:LinkButton>
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
                                                <asp:LinkButton ID="lkBuscarNomeProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarNomeProdutoModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovoNomeProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoNomeProdutoModal" Visible="false"><i class="fa fa-plus-circle"></i></asp:LinkButton>
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
                                        <asp:Label ID="Label12" runat="server" Text="*Quantidade em Estoque:"></asp:Label>
                                        <asp:TextBox ID="txtQuantidadeEstoque" runat="server" CssClass="form-control input-sm" placeholder="Digite a Quantidade do Estoque." Text="0"></asp:TextBox>
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
                                                <asp:BoundField DataField="_QuantidadeEstoque" HeaderText="Qtde do Estoque" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Conta._ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                                <asp:BoundField DataField="_EstoqueValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" />
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
                            <asp:LinkButton ID="lkbVisualizarGridViewItemLicitacaoModal" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVisualizarGridViewItemLicitacaoModal_Click"><i class="fa fa-reply"> Voltar</i></asp:LinkButton>
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
                                        <asp:TextBox ID="txtBuscarContaPorNumero" runat="server" CssClass="form-control input-sm" placeholder="Digite o N° da conta."></asp:TextBox>
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
                                        <asp:Label ID="Label20" runat="server" Text="*Produto:"></asp:Label>
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
                                        <asp:Label ID="Label2" runat="server" Text="*Preço Unitário:"></asp:Label>
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
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
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
