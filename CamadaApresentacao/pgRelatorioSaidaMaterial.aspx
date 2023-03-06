<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRelatorioSaidaMaterial.aspx.cs" Inherits="CamadaApresentacao.pgRelatorioSaidaMaterial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="font-awesome-4.5.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="jquery-ui-1.11.4.custom/jquery-ui.min.css" rel="stylesheet" />
    <link href="jquery-ui-1.11.4.custom/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="jquery-ui-1.11.4.custom/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="Estilo/Estilo.css" rel="stylesheet" />

    <!--Java Script do Bootstrap-->
    <script src="jquery-2.2.0/jquery-2.2.0.min.js"></script>
    <script src="bootstrap-3.3.6-dist/js/bootstrap.min.js"></script>
    <script src="jquery-ui-1.11.4.custom/jquery-ui.min.js"></script>
    <script src="jasny-bootstrap/js/jasny-bootstrap.min.js"></script>

    <!--Bootstrap DateTimePicker Java Script em português-->
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker({
                template: 'modal',
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                nextText: 'Próximo',
                prevText: 'Anterior'
            });
            $(".datepicker").datepicker("option", "showAnim", "show");
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <!--Botões cancelar, imprimir e buscar saída de material-->
        <div class="row">
            <div class="col-md-2">
                <asp:LinkButton ID="lkbCancelar" runat="server" CssClass="btn btn-default btn-sm hidden-print" OnClick="lkbCancelar_Click"><i class="fa fa-reply"></i></asp:LinkButton>
                <asp:LinkButton ID="lkImprimir" runat="server" CssClass="btn btn-success btn-sm hidden-print" OnClientClick="javascript:window.print();"><i class="fa fa-print"></i></asp:LinkButton>
                <asp:LinkButton ID="lkbBuscarSaidaMaterialModal" runat="server" CssClass="btn btn-success btn-sm hidden-print" data-toggle="modal" data-target="#BuscarSaidaMaterialModal"><i class="fa fa-search"></i></asp:LinkButton>
            </div>
        </div>

        <!--Panel com o cabeçalho-->
        <div class="row">
            <div class="col-md-12">
                <img src="Imagem/brasaoRelatorios.jpg" width="620px" height="160px" />
            </div>
        </div>

        <br />
        <br />


        <!--Corpo do relatório-->
        <div class="row">
            <table style="width: 1300px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-9 col-md-offset-3">
                            <div class="form-group">
                                <asp:Label ID="lblSaidaMaterialID" runat="server" Visible="false"></asp:Label>

                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <div class="row well well-sm">
            <table style="width: 1300px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-11">
                            <h2>Saída de Material</h2>
                        </div>
                    </td>
                    <td style="width: 300px;">
                        <div class="col-md-10 col-md-offset-1">
                            <div class="form-group">
                                <strong>
                                    <label for="lblDataCadastroRotulo" style="font-size: 18px">Período:</label></strong>
                                <p>
                                    <asp:Label ID="lblDataCadastro" runat="server" style="font-size: 18px"></asp:Label>.
                                </p>
                            </div>
                        </div>
                    </td>
                    <td style="width: 300px;">
                        <div class="col-md-10 col-md-offset-1">
                            <div class="form-group">
                                <label for="lblMaterialEstocável" style="font-size: 15px">Seleção de Material: <strong>Estocável/ Não Estocável</strong></label>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <div class="row">
            <table style="width: 1200px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-10">
                            <strong style="font-size: 18px">Centro de Custo :</strong>
                            <asp:Label ID="lblCentroCusto" runat="server" style="font-size: 18px"></asp:Label>.
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />

        <div class="row">
            <table style="width: 1200px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-10">
                            <strong style="font-size: 18px">Requisitante :</strong>
                            <asp:Label ID="lblRequisitante" runat="server" style="font-size: 18px"></asp:Label>.
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />

        <div class="row">
            <table style="width: 330px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-10">
                            <strong style="font-size: 18px">Observação :</strong>
                            <asp:TextBox ID="txtSaidaMaterialObservacao" runat="server" Width="1100px" TextMode="MultiLine" Rows="4" ReadOnly="true" style="font-size: 18px"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />
        <br />

        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvItemSaidaMaterial" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemSaidaMaterialID">
                        <Columns>
                            <asp:BoundField DataField="_Produto._Codigo" HeaderText="Cod.Prod" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._QuantidadeSaida" HeaderText="Qtde da Saída" DataFormatString="{0:n0}" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._Conta._ContaDescricao" HeaderText="Conta" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._ProdutoValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" ItemStyle-Font-Size="Large"/>
                        </Columns>
                        <EmptyDataTemplate>Nenhum Produto Adicionado.</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="left: 1010px";>
                <strong>
                    <asp:Label ID="lblValorTotalGeralRotulo" runat="server" BackColor="LightGray" Text="TOTAL GERAL:"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeral" runat="server"></asp:Label>
            </div>
        </div>

        <!-- Modal Opções de Buscar uma saída de material -->
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
                                        <asp:TextBox ID="txtBuscarPorData" runat="server" CssClass="form-control input-sm datepicker" Width="378px" placeholder="Selecione a data da saída do material." data-mask="99/99/9999"></asp:TextBox>
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
            <div class="modal-dialog" style="width: 800px;" role="document">
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
                                                    <asp:BoundField DataField="_Area._AreaNome" HeaderText="Área/Setor" />
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-success btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>Nenhum Funcionário Encontrado.</EmptyDataTemplate>
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

        <!--Script para reabrir modal grid view saída de Material-->
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
                                <h3 class="panel-title"><i class="fa fa-search">Selecione uma saída de material</i></h3>
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

    </form>
</body>
</html>
