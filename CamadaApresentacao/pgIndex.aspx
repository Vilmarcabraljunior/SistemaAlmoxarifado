<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInterna.master" AutoEventWireup="true" CodeBehind="pgIndex.aspx.cs" Inherits="CamadaApresentacao.pgIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConteudoInterno" runat="server">

    <!-- panel Menu principal do sistema---------------------------------------------------------------------------------------------------------------------------------->

    <div class="row">
        <div class="col-md-4 col-md-offset-8">
             <asp:Label ID="lblUltimoAcessoData" runat="server"></asp:Label>  
        </div>
    </div>

    <!--Menu Nivel0 Administrador-------------------------------------------------------------------------------------------------------->
    <asp:Panel ID="pnlMenuNivel0Admin" runat="server" Visible="false">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title"><strong><i class="fa fa-home" style="font-size: 18px">Menu</i></strong></h3>
            </div>
            <div class="panel-body">

                <br />
                <br />

                <div class="row">
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="imbMenuMaterial" runat="server" ImageUrl="~/Imagem/logoMaterial.jpg" Height="120px" OnClick="imbMenuMaterial_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-desktop" style="font-size: 18px">
                            <asp:LinkButton ID="lkbLinkMaterial" runat="server" data-toggle="modal" data-target="#ModalSubmenuMaterial">E/S de Material</asp:LinkButton></i></strong>
                    </div>
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="imbMenuRequisicao" runat="server" ImageUrl="~/Imagem/logoLicitacao.png" Height="120px" OnClick="imbMenuRequisicao_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                            <asp:LinkButton ID="lkbLinkRequisicao" runat="server" data-toggle="modal" data-target="#ModalSubmenuRequisicao">Requisição</asp:LinkButton></i></strong>
                    </div>
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="imbMenuLicitacao" runat="server" ImageUrl="~/Imagem/logoEstoque.png" Height="120px" OnClick="imbMenuLicitacao_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-th" style="font-size: 18px">
                            <asp:LinkButton ID="lkbLinkLicitacao" runat="server" data-toggle="modal" data-target="#ModalSubmenuLicitacao">Estoque</asp:LinkButton></i></strong>
                    </div>
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="lmbMenuRelatorio" runat="server" ImageUrl="~/Imagem/logoRelatorio2.jpg" Height="120px" Width="120px" OnClick="lmbMenuRelatorio_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                            <asp:LinkButton ID="lkbLinkRelatorio" runat="server" data-toggle="modal" data-target="#ModalSubmenuRelatorio">Relatórios</asp:LinkButton></i></strong>
                    </div>

                </div>

                <br />
                <br />
                <br />

                <div class="row">
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="imbMenuUsuario" runat="server" ImageUrl="~/Imagem/LogoUsuario.png" Height="110px" OnClick="imbMenuUsuario_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-user-plus" style="font-size: 15px">
                            <asp:LinkButton ID="lkbLinkUsuario" runat="server" OnClick="lkbLinkUsuario_Click">Novo Usuário</asp:LinkButton></i></strong>
                    </div>
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="imbMenuManual" runat="server" ImageUrl="~/Imagem/logoManual.jpg" Height="110px" OnClick="imbMenuManualNivel0Admin_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-question-circle" style="font-size: 18px">
                            <asp:LinkButton ID="lkbLinkManual" runat="server" data-toggle="modal" data-target="#ModalSubmenuManuais">Ajuda</asp:LinkButton></i></strong>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <br />
        </div>
    </asp:Panel>

    <!--Menu Nivel1 Almoxarifado--------------------------------------------------------------------------------------------------------->
    <asp:Panel ID="pnlMenuNivel1Almoxarifado" runat="server" Visible="false">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title"><strong><i class="fa fa-home" style="font-size: 18px">Menu</i></strong></h3>
            </div>
            <div class="panel-body">

                <br />
                <br />

                <div class="row">
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagem/logoMaterial.jpg" Height="120px" OnClick="imbMenuMaterial_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-desktop" style="font-size: 18px">
                            <asp:LinkButton ID="LinkButton1" runat="server" data-toggle="modal" data-target="#ModalSubmenuMaterial">E/S de Material</asp:LinkButton></i></strong>
                    </div>
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagem/logoLicitacao.png" Height="120px" OnClick="imbMenuRequisicao_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                            <asp:LinkButton ID="LinkButton2" runat="server" data-toggle="modal" data-target="#ModalSubmenuRequisicao">Requisição</asp:LinkButton></i></strong>
                    </div>
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagem/logoEstoque.png" Height="120px" OnClick="imbMenuLicitacao_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-th" style="font-size: 18px">
                            <asp:LinkButton ID="LinkButton3" runat="server" data-toggle="modal" data-target="#ModalSubmenuLicitacao">Estoque</asp:LinkButton></i></strong>
                    </div>
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Imagem/logoRelatorio2.jpg" Height="120px" Width="120px" OnClick="lmbMenuRelatorio_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                            <asp:LinkButton ID="LinkButton4" runat="server" data-toggle="modal" data-target="#ModalSubmenuRelatorio">Relatórios</asp:LinkButton></i></strong>
                    </div>

                </div>

                <br />
                <br />
                <br />

                <div class="row">
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Imagem/logoManual.jpg" Height="110px" OnClick="imbMenuManualNivel1Almoxarifado_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-question-circle" style="font-size: 18px">
                            <asp:LinkButton ID="LinkButton6" runat="server" data-toggle="modal" data-target="#ModalSubmenuManualSemDev">Ajuda</asp:LinkButton></i></strong>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <br />
        </div>
    </asp:Panel>

    <!--Menu Nivel2 outros------------------------------------------------------------------------------------------------>
    <asp:Panel ID="pnlMenuNivel2Outros" runat="server" Visible="false">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title"><strong><i class="fa fa-home" style="font-size: 18px">Menu</i></strong></h3>
            </div>
            <div class="panel-body">

                <br />
                <br />

                <div class="row">

                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Imagem/logoLicitacao.png" Height="120px" OnClick="imbMenuRequisicao_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                            <asp:LinkButton ID="LinkButton8" runat="server" data-toggle="modal" data-target="#ModalSubmenuRequisicao">Requisição</asp:LinkButton></i></strong>
                    </div>
                    <div class="col-md-3">
                        <!--image button-->
                        <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/Imagem/logoManual.jpg" Height="110px" OnClick="imbMenuManualNivel2Outros_Click" />
                        <!--link button-->
                        <strong class="CorMenu"><i class="fa fa-question-circle" style="font-size: 18px">
                            <asp:LinkButton ID="LinkButton12" runat="server" data-toggle="modal" data-target="#ModalSubmenuManualSemDev">Ajuda</asp:LinkButton></i></strong>
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
        </div>
    </asp:Panel>

    <!-- Fim do panel Menu principal do sistema---------------------------------------------------------------------------------------------------------------------------->

    <!--Submenus Modal do sistema------------------------------------------------------------------------------------------------------------------------------------------->
    <!--Script para abrir Submenu Modal Material -->
    <script type="text/javascript">
        function abrirModalSubmenuMaterial() {
            $('#ModalSubmenuMaterial').modal('show');
        }
    </script>
    <!--Fim do Script para abrir Submenu Modal Material -->

    <!--Submenu Modal entrada e saída de Material-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="ModalSubmenuMaterial" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 700px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Selecione uma opção</strong></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-5">
                                    <strong class="CorMenu"><i class="fa fa-plus-circle" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbLinkEntradaMaterialSubmenu" runat="server" OnClick="lkbLinkEntradaMaterialSubmenu_Click">Nova Entrada de Material</asp:LinkButton></i></strong>
                                </div>
                                <div class="col-md-4">
                                    <strong class="CorMenu"><i class="fa fa-plus-circle" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbLinkSaidaMaterialSubmenu" runat="server" OnClick="lkbLinkSaidaMaterialSubmenu_Click">Nova Saída de Material</asp:LinkButton></i></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do Submenu Modal entrada e saída de Material-->

    <!--Script para abrir Submenu Modal Requisição -->
    <script type="text/javascript">
        function abrirModalSubmenuRequisicao() {
            $('#ModalSubmenuRequisicao').modal('show');
        }
    </script>
    <!--Fim do Script para abrir Submenu Modal requisição -->

    <!--Submenu Modal requisição-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="ModalSubmenuRequisicao" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 600px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Selecione uma opção</strong></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-5">
                                    <strong class="CorMenu"><i class="fa fa-plus-circle" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbLinkRequisicaoSubmenu" runat="server" OnClick="lkbLinkRequisicaoSubmenu_Click">Nova Requisição</asp:LinkButton></i></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do Submenu Modal requisição-->

    <!--Script para abrir Submenu Modal Licitação -->
    <script type="text/javascript">
        function abrirModalSubmenuLicitacao() {
            $('#ModalSubmenuLicitacao').modal('show');
        }
    </script>
    <!--Fim do Script para abrir Submenu Modal Licitação -->

    <!--Submenu Modal Licitacao-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="ModalSubmenuLicitacao" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 600px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Selecione uma opção</strong></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-5">
                                    <strong class="CorMenu"><i class="fa fa-plus-circle" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbLinkLicitacaoSubmenu" runat="server" OnClick="lkbLinkLicitacaoSubmenu_Click">Estoque Atual</asp:LinkButton></i></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do Submenu Modal Licitação-->


    <!--Script para abrir Submenu Modal Relatório -->
    <script type="text/javascript">
        function abrirModalSubmenuRelatorio() {
            $('#ModalSubmenuRelatorio').modal('show');
        }
    </script>
    <!--Fim do Script para abrir Submenu Modal Relatório -->

    <!--Submenu Modal Relatório-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="ModalSubmenuRelatorio" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Selecione uma opção</strong></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioSaidaMaterial" runat="server" OnClick="lkbRelatorioSaidaMaterial_Click">Relatório de Saída de Material</asp:LinkButton></i></strong>
                                </div>

                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioEntradaMaterial" runat="server" OnClick="lkbRelatorioEntradaMaterial_Click">Relatório de Entrada de Material</asp:LinkButton></i></strong>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioRequisicaoEspecifico" runat="server" OnClick="lkbRelatorioRequisicaoEspecifico_Click">Relatório Guia de Remessa de Material</asp:LinkButton></i></strong>
                                </div>
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioNotificacaoBaixaDeMaterial" runat="server" OnClick="lkbRelatorioNotificacaoBaixaDeMaterial_Click">Relatório Notificação de Baixa de Material </asp:LinkButton></i></strong>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbMovimentacaoDetalhadaEntradaMaterial" runat="server" OnClick="lkbMovimentacaoDetalhadaEntradaMaterial_Click">Relatório Movimentação Detalhada Entrada de Material</asp:LinkButton></i></strong>
                                </div>
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbMovimentacaoDetalhadaSaidaMaterial" runat="server" OnClick="lkbMovimentacaoDetalhadaSaidaMaterial_Click">Relatório Movimentação Detalhada Saída de Material </asp:LinkButton></i></strong>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioEntradaMaterialGeral" runat="server" OnClick="lkbRelatorioEntradaMaterialGeral_Click">Relatório Entrada Material Geral</asp:LinkButton></i></strong>
                                </div>
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioSaidaMaterialGeral" runat="server" OnClick="lkbRelatorioSaidaMaterialGeral_Click">Relatório Saída Material Geral </asp:LinkButton></i></strong>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioMensalConsumoAlmoxarifado" runat="server" OnClick="lkbRelatorioMensalConsumoAlmoxarifado_Click">Relatório Mensal do Almoxarifado(Material de Consumo)</asp:LinkButton></i></strong>
                                </div>
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioMensalPermanenteAlmoxarifado" runat="server" OnClick="lkbRelatorioMensalPermanenteAlmoxarifado_Click">Relatório Mensal do Almoxarifado(Material Permanente) </asp:LinkButton></i></strong>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioInventarioEstoque" runat="server" OnClick="lkbRelatorioInventarioEstoque_Click">Relatório Inventário de Estoque</asp:LinkButton></i></strong>
                                </div>
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-file-text-o" style="font-size: 18px">
                                        <asp:LinkButton ID="lkbRelatorioEstoqueAtual" runat="server" OnClick="lkbRelatorioEstoqueAtual_Click">Relatório Estoque Atual</asp:LinkButton></i></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do Submenu Relatório-->

    <!--Script para abrir Submenu Modal Manuais -->
    <script type="text/javascript">
        function abrirModalSubmenuManuais() {
            $('#ModalSubmenuManuais').modal('show');
        }
    </script>
    <!--Fim do Script para abrir Submenu Modal Manuais -->

    <!--Submenu Modal ajuda/manuais-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="ModalSubmenuManuais" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 650px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Selecione uma opção</strong></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <strong class="CorMenu"><i class="fa fa-question-circle" style="font-size: 18px">
                                        <a href="ManualDoUsuario/ManualUsuario1.pdf" target="_blank">Manual do Usuário</a></i></strong>
                                </div>
                                <div class="col-md-5">
                                    <strong class="CorMenu"><i class="fa fa-question-circle" style="font-size: 18px">
                                        <a href="ManualDoDesenvolvedor/index.html" target="_blank">Manual do Desenvolvedor</a></i></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do Submenu Modal ajuda/manuais-->

    <!--Script para abrir Submenu Modal Manual sem Desenvolvedor -->
    <script type="text/javascript">
        function abrirModalSubmenuManualSemDev() {
            $('#ModalSubmenuManualSemDev').modal('show');
        }
    </script>
    <!--Fim do Script para abrir Submenu Modal Manual sem Desenvolvedor -->

    <!--Submenu Modal ajuda/manual sem Desenvolvedor-->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="ModalSubmenuManualSemDev" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 450px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Selecione uma opção</strong></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <strong class="CorMenu"><i class="fa fa-question-circle" style="font-size: 18px">
                                        <a href="ManualDoUsuario/ManualUsuario1.pdf" target="_blank">Manual do Usuário</a></i></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do Submenu Modal ajuda/manual sem desenvolvedor-->

</asp:Content>
