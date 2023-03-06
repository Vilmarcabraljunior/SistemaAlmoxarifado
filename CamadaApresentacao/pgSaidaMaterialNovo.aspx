<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInterna.master" AutoEventWireup="true" CodeBehind="pgSaidaMaterialNovo.aspx.cs" Inherits="CamadaApresentacao.pgSaidaMaterialNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConteudoInterno" runat="server">

    <!--Área da Saída de Material-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Panel com as opções de gravar ou buscar uma Saída de Material-->
    <asp:TextBox ID="txtSaidaMaterialID" runat="server" Visible="false"></asp:TextBox>

    <asp:Panel ID="pnlPesquisar" runat="server">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title"><strong>Saída de Material</strong></h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:LinkButton ID="lkbNovo" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbNovo_Click"><i class="fa fa-plus-circle"> Nova Saída de Material</i></asp:LinkButton>
                        <asp:LinkButton ID="lkbConsultar" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarSaidaMaterialModal"><i class="fa fa-search"> Buscar Saída de Material</i></asp:LinkButton>
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
        </div>
    </asp:Panel>

    <!--Script para reabrir modal Nova/atualizar Saída de Material-->
    <script type="text/javascript">
        function openNovaSaidaMaterialModal() {
            $('#NovaSaidaMaterialModal').modal('show');
        }
    </script>

    <!-- Modal Nova/atualizar Saída de Material-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovaSaidaMaterialModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblSaidaMaterialNovoTitulo" runat="server" Text="Nova Saída de Material" CssClass="fa fa-plus-circle"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdSaidaMaterialID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="*Data da Saída:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroSaidaMaterial" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCentroDeCustoCodigo" runat="server" CssClass="form-control input-sm" placeholder="Código." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:HiddenField ID="hdCentroDeCustoID" runat="server" Value="0" />
                                            <asp:TextBox ID="txtCentroDeCustoDescricao" runat="server" CssClass="form-control input-sm" placeholder="Centro de Custo." ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarCentroDeCustoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarCentroDeCustoModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovoCentroDeCustoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoCentroDeCustoModal"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
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
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label13" runat="server" Text="*Observação:"></asp:Label>
                                        <asp:TextBox ID="txtSaidaMaterialObservacao" runat="server" CssClass="form-control input-sm " TextMode="MultiLine" Rows="5" placeholder="Digite uma Observação."></asp:TextBox>
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

    <!--Script para reabrir modal Detalhes da Saída de Material-->
    <script type="text/javascript">
        function openSaidaMaterialDetalhesModal() {
            $('#SaidaMaterialDetalhesModal').modal('show');
        }
    </script>

    <!-- Modal Detalhes Saída de Material-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="SaidaMaterialDetalhesModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Detalhes da Saída de Material</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdDetalhesSaidaMaterialID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-6 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Text="Data da Saída:"></asp:Label></strong>
                                        <asp:Label ID="lblDataCadastroSaidaMaterial" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label22" runat="server" Text="Código:"></asp:Label></strong>
                                        <asp:Label ID="lblCentroDeCustoCodigo" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label24" runat="server" Text="Centro de Custo:"></asp:Label></strong>
                                        <asp:Label ID="lblCentroDeCustoDescricao" runat="server"></asp:Label>
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
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <strong>
                                            <asp:Label ID="Label8" runat="server" Text="Observação:"></asp:Label></strong>
                                        <br />
                                        <asp:TextBox ID="txtSaidaMaterialObservacaoDetalhes" runat="server" Width="800px" TextMode="MultiLine" Rows="5" ReadOnly="true"></asp:TextBox>
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
                                    <asp:LinkButton ID="lkbVisualizarGridViewItemSaidaMaterialDetalhesModal" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbVisualizarGridViewItemSaidaMaterialDetalhesModal_Click"><i class="fa fa-check"> Visualizar Produtos</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarDetalhes" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarDetalhes_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Script para reabrir modal grid view Saída de Material-->
    <script type="text/javascript">
        function openGridViewSaidaMaterialModal() {
            $('#GridViewSaidaMaterialModal').modal('show');
        }
    </script>

    <!-- Modal GridView Saída de Material -->
    <div class="modal fade" id="GridViewSaidaMaterialModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1000px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione uma Saída de Material</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvSaidaMaterial" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_SaidaMaterialID" OnSelectedIndexChanged="gvSaidaMaterial_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data da Saída" />
                                                <asp:BoundField DataField="_CentroDeCusto._Descricao" HeaderText="Centro de Custo" />
                                                <asp:BoundField DataField="_Requisitante._RequisitanteNome" HeaderText="Requisitante" />
                                                <asp:BoundField DataField="_Usuario._UsuarioNome" HeaderText="Cadastrado por" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhuma Saída de Material Encontrada.</EmptyDataTemplate>
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

    <!-- Modal Opções de Buscar uma Saída de Material -->
    <div class="modal fade" id="BuscarSaidaMaterialModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
                                    <asp:TextBox ID="txtBuscarPorData" runat="server" CssClass="form-control input-sm datepicker" placeholder="Selecione a data da saída do material." Width="378px" data-mask="99/99/9999"></asp:TextBox>
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
                                        <asp:TextBox ID="txtBuscarPorRequisitante" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome do requisitante."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarSaidaMaterialPorRequisitante" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarSaidaMaterialPorRequisitante_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorUsuario" runat="server" CssClass="form-control input-sm" placeholder="Digite o nome do funcionário."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarSaidaMaterialPorUsuario" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarSaidaMaterialPorUsuario_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Gridview para selecionar um usuário para buscar as saídas de material------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal Buscar as saídas de material por usuário-->
    <script type="text/javascript">
        function openGridViewBuscarSaidaMaterialPorUsuarioModal() {
            $('#GridViewBuscarSaidaMaterialPorUsuarioModal').modal('show');
        }
    </script>

    <!-- Modal GridView usuário ------------------------------------------------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="GridViewBuscarSaidaMaterialPorUsuarioModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 950px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um funcionário</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvBuscarSaidaMaterialPorUsuario" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_UsuarioID" OnSelectedIndexChanged="gvBuscarSaidaMaterialPorUsuario_SelectedIndexChanged">
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

    <!--Gridview para selecionar um requisitante para buscar as saidas de material------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal Buscar as saidas de material por requisitante-->
    <script type="text/javascript">
        function openGridViewBuscarSaidaMaterialPorRequisitanteModal() {
            $('#GridViewBuscarSaidaMaterialPorRequisitanteModal').modal('show');
        }
    </script>

    <!-- Modal GridView Requisitante ------------------------------------------------------------------------------------------------------------------------------------------------------>
    <div class="modal fade" id="GridViewBuscarSaidaMaterialPorRequisitanteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
                                        <asp:GridView ID="gvBuscarSaidaMaterialPorRequisitante" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_RequisitanteID" OnSelectedIndexChanged="gvBuscarSaidaMaterialPorRequisitante_SelectedIndexChanged">
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

    <!-- Modal excluir Saída de Material -->
    <div class="modal fade" id="ExcluirModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 450px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Excluir?</h3>
                        </div>
                        <div class="panel-body">
                            <h5><strong>Tem Certeza que Deseja Excluir esta Saída de Material ?</strong></h5>

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

    <!--Área Item da Saída de Material----------------------------------------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Script para reabrir modal para Adicionar Item da Saída de Material-->
    <script type="text/javascript">
        function openAdicionarItemSaidaMaterialModal() {
            $('#AdicionarItemSaidaMaterialModal').modal('show');
        }
    </script>

    <!-- Modal Adicionar item da Saída de Material -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="AdicionarItemSaidaMaterialModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                                    <asp:LinkButton ID="lkbAdicionarItemSaidaMaterialModal" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbAdicionarItemSaidaMaterialModal_Click"><i class="fa fa-check"> Adicionar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarAdicionarItemSaidaMaterialModal" runat="server" CssClass="btn btn-default btn-sm" OnClick="lkbCancelarAdicionarItemSaidaMaterialModal_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!--Script para reabrir modal adicionar item da Saída de Material-->
    <script type="text/javascript">
        function openGridViewItemSaidaMaterialModal() {
            $('#GridViewItemSaidaMaterialModal').modal('show');
        }
    </script>

    <!-- Modal GridView item da  Saída de Material -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewItemSaidaMaterialModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Adicionar Produtos da Saída de Material</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <!--hidden field com o id da saída de material retornada-->
                                        <asp:HiddenField ID="hdSaidaMaterialIDRetornado" runat="server" Value="0" />

                                        <asp:LinkButton ID="lkbNovoProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovoProdutoModal"><i class="fa fa-plus-circle">Adicionar Produto</i></asp:LinkButton>
                                        <asp:LinkButton ID="lkbBuscarProdutoModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarProdutoModal" Visible="false"><i class="fa fa-search">Buscar</i></asp:LinkButton>

                                        <asp:GridView ID="gvItemSaidaMaterial" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemSaidaMaterialID" OnRowUpdating="gvItemSaidaMaterial_RowUpdating" OnRowDeleting="gvItemSaidaMaterial_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="_Produto._Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" />
                                                <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." />
                                                <asp:BoundField DataField="_Produto._QuantidadeSaida" HeaderText="Qtde da Saída" DataFormatString="{0:n0}" />
                                                <asp:BoundField DataField="_Produto._Conta._ContaDescricao" HeaderText="Conta" />
                                                <asp:BoundField DataField="_Produto._ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" />
                                                <asp:BoundField DataField="_Produto._ProdutoValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbEditarItemSaidaMaterial" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Update"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbExcluirItemSaidaMaterial" runat="server" CausesValidation="False" CssClass="btn btn-danger btn-xs" CommandName="Delete" OnClientClick="return confirm('Excluir Este Produto da Saída de Material?');"><i class="fa fa-times"></i></asp:LinkButton>
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

    <!--Script para reabrir modal adicionar item da saída de material Detalhes-->
    <script type="text/javascript">
        function openGridViewItemSaidaMaterialDetalhesModal() {
            $('#GridViewItemSaidaMaterialDetalhesModal').modal('show');
        }
    </script>

    <!-- Modal GridView item da Saída de Material detalhes -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewItemSaidaMaterialDetalhesModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">Lista de Produtos da Saída de Material</h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvItemSaidaMaterialDetalhes" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemSaidaMaterialID">
                                            <Columns>
                                                <asp:BoundField DataField="_Produto._Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" />
                                                <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." />
                                                <asp:BoundField DataField="_Produto._QuantidadeSaida" HeaderText="Qtde da Saída" DataFormatString="{0:n0}" />
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
                            <asp:LinkButton ID="lkbVisualizarSaidaMaterialDetalhesModal" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVisualizarSaidaMaterialDetalhesModal_Click"><i class="fa fa-reply"> Voltar</i></asp:LinkButton>
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

    <!--Área do Centro de Custo---------------------------------------------------------------------------------------------------------------------->
    <!-- Modal Novo Centro de Custo-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoCentroDeCustoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 750px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Novo Centro de Custo</i></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdCentroDeCustoModalID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroCentroDeCusto" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="*Código:"></asp:Label>
                                        <asp:TextBox ID="txtCentroDeCustoCodigoModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="Label6" runat="server" Text="*Centro de Custo:"></asp:Label>
                                        <asp:TextBox ID="txtCentroDeCustoDescricaoModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do Centro de Custo"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvarCentroDeCusto" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbSalvarCentroDeCusto_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarCentroDeCusto" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarCentroDeCusto_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Opções de Buscar um Centro de Custo -->
    <div class="modal fade" id="BuscarCentroDeCustoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
                                        <asp:TextBox ID="txtBuscarCentroDeCustoPorCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o código do centro de custo."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarCentroDeCusto" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarCentroDeCusto_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarCentroDeCustoPorDescricao" runat="server" CssClass="form-control input-sm" placeholder="Digite o centro de custo."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarCentroDeCusto2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarCentroDeCusto_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!--Script para reabrir modal Novo Centro de Custo-->
    <script type="text/javascript">
        function openGridViewCentroDeCustoModal() {
            $('#GridViewCentroDeCustoModal').modal('show');
        }
    </script>

    <!-- Modal GridView Centro de Custo -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="GridViewCentroDeCustoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1000px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:LinkButton ID="lkbVoltarCentroDeCusto" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVoltarCentroDeCusto_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um Centro de Custo</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvCentroDeCusto" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_CentroDeCustoID" OnSelectedIndexChanged="gvCentroDeCusto_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_DataCadastro" HeaderText="Data do Cadastro" />
                                                <asp:BoundField DataField="_Codigo" HeaderText="Código" />
                                                <asp:BoundField DataField="_Descricao" HeaderText="Centro de Custo" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum centro de custo encontrado.</EmptyDataTemplate>
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
                                <div class="col-md-offset-1">
                                    <asp:Label ID="Label14" runat="server" Text="*Quantidade da Saída:"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtQuantidadeSaida" runat="server" CssClass="form-control input-sm" placeholder="Digite a Quantidade da saída." Text="0"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbCalcularQuantidadeFornecidaModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#CalcularQuantidadeFornecidaModal"><i class="fa fa-minus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
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
                                                <asp:BoundField DataField="_QuantidadeSaida" HeaderText="Qtde da Saída" DataFormatString="{0:n0}" />
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
                            <asp:LinkButton ID="lkbVisualizarGridViewItemSaidaMaterialModal" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbVisualizarGridViewItemSaidaMaterialModal_Click"><i class="fa fa-reply"> Voltar</i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Área Calcular adicionar nova quantidade de produtos------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Script para abrir modal para mudar quantidade de prostos da entrada de material------------------------------------------------------------------------------------------->
    <script type="text/javascript">
        function openCalcularQuantidadeFornecidaModal() {
            $('#CalcularQuantidadeFornecidaModal').modal('show');
        }
    </script>

    <!--modal Calcular adicionar nova quantidade de produtos------------------------------------------------------------------------------------------------------------------------------------------->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="CalcularQuantidadeFornecidaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog " style="width: 300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-plus-circle">Atualizar Quantidade</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label23" runat="server" Text="Digite a quantidade da saída:"></asp:Label>
                                        <asp:TextBox ID="txtQuantidadeFornecidaDecrescimo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbCalcularQuantidadeFornecida" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbCalcularQuantidadeFornecida_Click"><i class="fa fa-check"> Atualizar</i></asp:LinkButton>
                                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                                </div>
                            </div>
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
                                        <asp:Label ID="Label7" runat="server" Text="Data do Cadastro:"></asp:Label>
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
                                        <asp:Label ID="Label11" runat="server" Text="*Produto:"></asp:Label>
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
                                        <asp:Label ID="Label28" runat="server" Text="*Preço Unitário:"></asp:Label>
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
