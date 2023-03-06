<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInterna.master" AutoEventWireup="true" CodeBehind="pgNomeProdutoNovo.aspx.cs" Inherits="CamadaApresentacao.pgNomeProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConteudoInterno" runat="server">

    <!--Panel para gravar ou buscar um Nome do Produto-->
    <asp:Panel ID="pnlPesquisar" runat="server">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title">Nome do Produto</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:LinkButton ID="lkbNovo" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbNovo_Click"><i class="fa fa-plus-circle"> Novo Nome do Produto</i></asp:LinkButton>
                        <asp:LinkButton ID="lkbConsultar" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarNomeProdutoModal"><i class="fa fa-search">Buscar Nome do Produto</i></asp:LinkButton>
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

    <!--Script para reabrir modal Novo Produto-->
    <script type="text/javascript">
        function openNovoNomeProdutoModal() {
            $('#NovoNomeProdutoModal').modal('show');
        }
    </script>

    <!-- Modal Novo Produto -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoNomeProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1000px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblNomeProdutoNovoTitulo" runat="server" Text="Novo Nome do Produto" CssClass="fa fa-plus-circle"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdNomeProdutoID" runat="server" Value="0" />
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastro" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label21" runat="server" Text="*Código:"></asp:Label>
                                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código."></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="*Produto:"></asp:Label>
                                        <asp:TextBox ID="txtProdutoNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do Produto."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:HiddenField ID="hdUnidadeID" runat="server" Value="0" />
                                            <asp:TextBox ID="txtUnidadeDescricao" runat="server" CssClass="form-control input-sm" placeHolder="Selecione a Unidade." ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarUnidadeModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarUnidadeModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovaUnidadeModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovaUnidadeModal"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label9" runat="server" Text="*Preço Unitário:"></asp:Label>
                                        <asp:TextBox ID="txtProdutoPrecoUnitario" runat="server" CssClass="form-control input-sm mascaraMonetaria" placeholder="Digite o Preço Unitário."></asp:TextBox>
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
                                        <div class="input-group">
                                            <asp:HiddenField ID="hdContaID" runat="server" Value="0" />
                                            <asp:TextBox ID="txtConta" runat="server" CssClass="form-control input-sm" placeHolder="Conta." ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarContaModal" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#BuscarContaModal"><i class="fa fa-search"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lkbNovaContaMocial" runat="server" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#NovaContaModal"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-5 col-md-offset-1">
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

    <!--Script para reabrir modal Novo Produto-->
    <script type="text/javascript">
        function openGridViewNomeProdutoModal() {
            $('#GridViewNomeProdutoModal').modal('show');
        }
    </script>

    <!-- Modal GridView com os dados do nome do Produto -->
    <div class="modal fade" id="GridViewNomeProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1300px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
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

    <!-- Modal Opções de Buscar nome do Produto -->
    <div class="modal fade" id="BuscarNomeProdutoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
                                        <asp:TextBox ID="txtBuscarPorCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código do Produto."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarPorCodigo" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do Produto."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarNome" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

    <!-- Modal para excluir um nome do Produto-->
    <div class="modal fade" id="ExcluirModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 480px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Excluir ?</h3>
                        </div>
                        <div class="panel-body">
                            <h5><strong>Tem Certeza que Deseja Excluir este nome do  Produto ?</strong></h5>

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

    <!--Área da Conta------------------------------------------------------------------------------------------------------------------------------------------->
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
                                        <asp:Label ID="Label7" runat="server" Text="*Código:"></asp:Label>
                                        <asp:TextBox ID="txtContaNumeroModal" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código."></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="Label13" runat="server" Text="*Conta:"></asp:Label>
                                        <asp:TextBox ID="txtContaDescricao" runat="server" CssClass="form-control input-sm " placeholder="Digite a Conta."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="Tipo da Conta:"></asp:Label>
                                        <asp:DropDownList ID="ddlTipoConta" runat="server" class="form-control input-sm" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">>>>Selecione<<<</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="*Função:"></asp:Label>
                                        <asp:TextBox ID="txtContaFuncao" runat="server" CssClass="form-control input-sm " TextMode="MultiLine" Rows="5" placeholder="Digite a Função da Conta."></asp:TextBox>
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
                                        <asp:TextBox ID="txtBuscarContaPorNumero" runat="server" CssClass="form-control input-sm" placeholder="Digite o Código da Conta."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarConta" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarConta_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarContaPorDescricao" runat="server" CssClass="form-control input-sm" placeholder="Digite a Conta."></asp:TextBox>
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

    <!--Área da Unidade------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------>
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
                                        <asp:Label ID="Label15" runat="server" Text="Data do Cadastro:"></asp:Label>
                                        <asp:TextBox ID="txtDataCadastroUnidade" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label16" runat="server" Text="*Descrição da Unidade:"></asp:Label>
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
</asp:Content>
