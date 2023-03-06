<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRelatorioInventarioEstoque.aspx.cs" Inherits="CamadaApresentacao.pgRelatorioInventarioProduto" %>

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
        <!--Botões cancelar, imprimir e buscar conta-->
        <div class="row">
            <div class="col-md-2">
                <asp:LinkButton ID="lkbCancelar" runat="server" CssClass="btn btn-default btn-sm hidden-print" OnClick="lkbCancelar_Click"><i class="fa fa-reply"></i></asp:LinkButton>
                <asp:LinkButton ID="lkImprimir" runat="server" CssClass="btn btn-success btn-sm hidden-print" OnClientClick="javascript:window.print();"><i class="fa fa-print"></i></asp:LinkButton>
                <asp:LinkButton ID="lkbBuscarContaModal" runat="server" CssClass="btn btn-success btn-sm hidden-print" data-toggle="modal" data-target="#BuscarContaModal"><i class="fa fa-search"></i></asp:LinkButton>
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
        <div class="row well well-sm">
            <table style="width: 1200px;">
                <tr>
                    <td style="width: 300px";>
                        <div class="col-md-10" style="left: 390px";>
                            <h2><strong>Inventário de Estoque - IEM</strong></h2>
                            <strong></strong>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        
        <br />
        
        <!--Área do cabeçalho-->
        <div class="row">
            <table style="width: 500px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-10">
                            <strong>UG: 373082</strong>
                        </div>
                    </td>
                    <td style="width: 300px;">
                         <div class="col-md-10">
                            <strong>PERÍODO: 1° a 31/12/<asp:Label ID="lblAno" runat="server"></asp:Label></strong>
                        </div>
                    </td>
                </tr>
            </table>
        </div>     

        <br />

        <!--Área do cabeçalho-->
        <div class="row">
            <table style="width: 1282px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-10">
                            <strong>DATA: <asp:Label ID="lblData" runat="server" Text="Label"></asp:Label></strong>
                        </div>
                    </td>
                    <td style="width: 300px;">
                         <div class="col-md-10">
                            <strong>ÓRGÃO: SR-17</strong>
                        </div>
                    </td>
                    <td style="width: 520px;">
                         <div class="col-md-10">
                            <strong>CÓDIGO DO ÓRGÃO: 37201</strong>
                        </div>
                    </td>
                    <td style="width: 520px;">
                         <div class="col-md-10">
                            <strong>MATERIAL INVENTARIADO <br />
                                <asp:Label ID="lblContaDescricao" runat="server"></asp:Label>
                                (<asp:Label ID="lblContaCodigo" runat="server"></asp:Label>)</strong>
                        </div>
                    </td>
                </tr>
            </table>
        </div>   
              
        <br />  
        
        <!--Script para reabrir modal buscar as contas atuais do estoque-->
        <script type="text/javascript">
            function openMostrarContasAtuaisEstoqueModal() {
                $('#MostrarContasAtuaisEstoqueModal').modal('show');
            }
        </script> 
                
        <!-- Modal Opções de Buscar contas atuais do estoque -->
        <div class="modal fade" id="MostrarContasAtuaisEstoqueModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" style="width: 900px;" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-search">Lista de Contas do Estoque</i></h3>
                            </div>
                            <div class="panel-body">
                                 <div class="table-responsive">
                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                                 <asp:GridView ID="gvContaEmEstoque" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                               
                                     <Columns>
                                         <asp:BoundField DataField="Código" HeaderText="Código" SortExpression="Código" />
                                         <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" />
                                         <asp:BoundField DataField="Tipo da Conta" HeaderText="Tipo da Conta" SortExpression="Tipo da Conta" />
                                         <asp:BoundField DataField="Qtde em Estoque" HeaderText="Qtde de Produtos"  SortExpression="Qtde de Produtos" />
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
                
        <br />
        <br />

        <div class="row">
            <div class="col-md-3 col-md-offset-10">
                 <asp:LinkButton ID="lkbMostrarContasAtuaisEstoque" runat="server" CssClass="btn btn-danger btn-sm hidden-print" OnClick="lkbMostrarContasAtuaisEstoque_Click"><i class="fa fa-search"> Contas Atuais do Estoque</i></asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:GridView ID="gvItemLicitacao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnDataBound="gvItemLicitacao_DataBound">
                                                      
                        <Columns>
                            <asp:BoundField DataField="N° de Ordem" HeaderText="N° de Ordem" SortExpression="N° de Ordem" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Código" HeaderText="Código" SortExpression="Código" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Produto" HeaderText="Especificação" SortExpression="Produto" ItemStyle-Width="500px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Unid." HeaderText="Unidade" SortExpression="Unid." ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Qtde em Estoque" HeaderText="Quantidade" SortExpression="Qtde em Estoque" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Preço Unitário" HeaderText="Preço Unitário" SortExpression="Preço Unitário" DataFormatString="{0:n2}" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Preço Total" HeaderText="Preço Total" SortExpression="Preço Total" DataFormatString="{0:n2}" ItemStyle-Font-Size="Large"/>
                        </Columns>
                                                      
                        <EmptyDataTemplate>Nenhum Produto Encontrado</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3" style="left: 1240px";>
                <strong>
                    <asp:Label ID="Label1" runat="server" BackColor="LightGray" Text="Total da Conta:" style="font-size: 14px"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeral" runat="server" style="font-size: 18px"></asp:Label>
            </div>
        </div>        

        <!--Área das assinaturas-->
        <div class="row">
            <table style="width: 1500px;">
                <tr>
                    <td style="width: 350px;">
                         <div class="col-md-8">
                            <strong>Observações:</strong>   <br />
                            <asp:TextBox ID="txtObservações" runat="server" Width="1300px" TextMode="MultiLine" Rows="3"></asp:TextBox>
                         </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />


        <!--Área das assinaturas-->
        <div class="row">
            <table style="width: 1500px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-3">
                            <strong>Coordenadora</strong>
                        </div>
                    </td>
                    <td style="width: 300px;">
                         <div class="col-md-3">
                            <strong>Membro</strong>
                        </div>
                    </td>
                    <td style="width: 300px;">
                         <div class="col-md-3">
                            <strong>Membro</strong>
                        </div>
                    </td>
                    <td style="width: 350px;">
                         <div class="col-md-8">
                            <strong>Chefe de Almoxarifado</strong>                               
                        </div>
                    </td>
                </tr>
            </table>
        </div>


        <!--Script para reabrir modal buscar uma conta-->
        <script type="text/javascript">
            function openBuscarContaModal() {
                $('#BuscarContaModal').modal('show');
            }
        </script>

        <!-- Modal Opções de Buscar uma conta -->
        <div class="modal fade" id="BuscarContaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" style="width: 600px;" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-search">Buscar uma conta</i></h3>
                            </div>
                            <div class="panel-body">
                                  <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorNumero" runat="server" CssClass="form-control input-sm" placeholder="Digite o código da conta."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarPorNumero" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorDescricao" runat="server" CssClass="form-control input-sm" placeholder="Digite a conta."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarPorDescricao" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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

        <!--Script para reabrir modal Nova Conta-->
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

    </form>
</body>
</html>
