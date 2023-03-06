<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRelatorioNotificacaoBaixaDeMaterial.aspx.cs" Inherits="CamadaApresentacao.pgRelatorioNotificacaoBaixaDeMaterial" %>

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
        <!--Botões cancelar, imprimir e buscar requisição-->
        <div class="row">
            <div class="col-md-2">
                <asp:LinkButton ID="lkbCancelar" runat="server" CssClass="btn btn-default btn-sm hidden-print" OnClick="lkbCancelar_Click"><i class="fa fa-reply"></i></asp:LinkButton>
                <asp:LinkButton ID="lkImprimir" runat="server" CssClass="btn btn-success btn-sm hidden-print" OnClientClick="javascript:window.print();"><i class="fa fa-print"></i></asp:LinkButton>
                <asp:LinkButton ID="lkbBuscarRequisicaoModal" runat="server" CssClass="btn btn-success btn-sm hidden-print" data-toggle="modal" data-target="#BuscarRequisicaoModal"><i class="fa fa-search"></i></asp:LinkButton>
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
                                <asp:Label ID="lblRequisicaoID" runat="server" Visible="false"></asp:Label>

                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <div class="row well well-sm">
            <table style="width: 1200px;">
                <tr>
                    <td style="width: 300px";>
                        <div class="col-md-10" style="left: 350px";>
                            <h2><strong>Notificação Baixa de Material</strong></h2>
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
                            <strong style="font-size: 18px">Requisição :</strong>
                            <asp:Label ID="lblCodigo" runat="server" style="font-size: 18px"></asp:Label>
                            <strong style="font-size: 18px">de </strong>
                            <asp:Label ID="lblDataCadastro" runat="server" style="font-size: 18px"></asp:Label>.
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
                            <asp:Label ID="lblRequisitanteCodigo" runat="server" style="font-size: 18px"></asp:Label> -
                            <asp:Label ID="lblRequisitante" runat="server" style="font-size: 18px"></asp:Label>.
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
                            <strong style="font-size: 18px">Endereço :</strong>
                            <asp:Label ID="lblEnderecoCodigo" runat="server" style="font-size: 18px"></asp:Label> -
                            <asp:Label ID="lblEndereco" runat="server" style="font-size: 18px"></asp:Label>.
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
                            <asp:TextBox ID="txtRequisicaoObservacao" runat="server" Width="1100px" TextMode="MultiLine" Rows="4" ReadOnly="true" style="font-size: 18px"></asp:TextBox>
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
                    <asp:GridView ID="gvItemRequisicao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemRequisicaoID">
                        <Columns>
                            <asp:BoundField DataField="_Produto._Codigo" HeaderText="Cod.Prod" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._QuantidadeSolicitada" HeaderText="Qtde Solicitada" DataFormatString="{0:n0}" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._QuantidadeAtendida" HeaderText="Qtde Atendida" DataFormatString="{0:n0}" ItemStyle-Font-Size="Large"/>
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
            <div class="col-md-2" style="left: 1050px";>
                <strong>
                    <asp:Label ID="lblValorTotalGeralRotulo" runat="server" BackColor="LightGray" Text="TOTAL GERAL:" style="font-size: 18px"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeral" runat="server" style="font-size: 18px"></asp:Label>
            </div>
        </div>

        <br />
        <br />
       
        <div class="row">
            <table style="width: 1200px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-10">
                            <strong>Certifico a baixa dos materiais acima especificados em,__________ de_________________ de __________</strong>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />
        <br />
        <br />
        <br />

        <!--Área para assinatura-->
        <div class="row">
            <table style="width: 600px;">
                <tr>
                    <td style="width: 250px;">
                        <div class="col-md-10 col-md-offset-1" style="left: 100px";>
                            <strong>_____________________________________________________________</strong>
                            
                        </div>
                       
                    </td>
                    <td style="width: 300px;">
                         <div class="col-md-10 col-md-offset-1" style="left: 220px";>
                            <strong>_____________________________________________________________</strong>
                        </div>
                    </td>
                </tr>
            </table>
        </div>     

        <div class="row" >
            <table style="width: 600px;">
                <tr>
                    <td style="width: 300px";>
                        <div class="col-md-10 col-md-offset-1" style="left: 220px";>
                            <strong>Responsável pelo Atendimento</strong>
                        </div>
                    </td>
                    <td style="width: 300px;">
                        <div class="col-md-10 col-md-offset-1" style="left: 570px";>
                            <strong>Responsável pelo Almoxarifado</strong>
                        </div>
                    </td>
                </tr>
            </table>
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
                                        <asp:LinkButton ID="lkbBuscarRequisicao2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarRequisicao_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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
                                        <asp:LinkButton ID="lkbBuscar2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarRequisicao_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtBuscarPorCodigo" runat="server" CssClass="form-control input-sm" placeholder="Digite o n° da requisição."></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbBuscarRequisicao1" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarRequisicao_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

        <!--Gridview para selecionar uma situação------------------------------------------------------------------------------------------------------->
        <!--Script para reabrir modal Buscar requisição por Situação-->
        <script type="text/javascript">
            function openGridViewBuscarRequisicaoPorSituacaoModal() {
                $('#GridViewBuscarRequisicaoPorSituacaoModal').modal('show');
            }
        </script>

        <!-- Modal GridView Situação -->
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
            <div class="modal-dialog" style="width: 800px;" role="document">
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
                                                    <asp:BoundField DataField="_Codigo" HeaderText="Requisição N°" />
                                                    <asp:BoundField DataField="_DataCadastro" HeaderText="Atendida Em" />
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
    </form>
</body>
</html>

