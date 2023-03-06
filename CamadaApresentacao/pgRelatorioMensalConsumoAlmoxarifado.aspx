<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRelatorioMensalConsumoAlmoxarifado.aspx.cs" Inherits="CamadaApresentacao.pgRelatorioMensalAlmoxarifado" %>

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

        <!--Brasão do relatório-->
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
                        <div class="col-md-10" style="left: 200px";>
                            <h2><strong>Relatório Mensal do Almoxarifado - RMA</strong></h2>
                        </div>
                        <div class="col-md-10" style="left: 380px";>
                            <h3><strong>Material de Consumo</strong></h3>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
                        
        <br />

        <div class="row" >
            <table style="width: 800px;">
                <tr>
                    <td style="width: 400px";>
                        <div class="col-md-10">
                            <strong style="font-size: 18px">Unidade Gestora: 373082</strong>
                        </div>
                    </td>
                    <td style="width: 450px;">
                        <div class="col-md-10" style="left: 300px";>
                            <strong style="font-size: 18px">Período :</strong>
                            <asp:Label ID="lblDataInicial" runat="server" style="font-size: 18px"></asp:Label>
                            <strong style="font-size: 18px">à </strong>
                            <asp:Label ID="lblDataFinal" runat="server" style="font-size: 18px"></asp:Label>.
                        </div>
                    </td>
                </tr>
            </table>
        </div>
                
        <br />  

        <!--Gridview com as entradas de material tipo orçamentário-->
        <strong style="font-size: 18px">Entrada de Material(Orçamentário)</strong>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:GridView ID="gvEntradaMaterial" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="gvEntradaMaterial_RowDataBound">
                        
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Cod.Conta" SortExpression="Codigo" ItemStyle-Width="300px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Entrada" HeaderText="Entrada" SortExpression="Entrada" DataFormatString="{0:n2}" ItemStyle-Width="400px" ItemStyle-Font-Size="Large"/>
                        </Columns>
                        
                        <EmptyDataTemplate>----</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="left: 800px";>
                <strong>
                    <asp:Label ID="Label1" runat="server" BackColor="LightGray" Text="TOTAL GERAL:"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeralEntrada" runat="server"></asp:Label>
            </div>
        </div>
        <br />
        <br />
        
        <!--Gridview com as entradas de material tipo Extra -orçamentário-->
        <strong style="font-size: 18px">Entrada de Material(Extra - Orçamentário)</strong>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:GridView ID="gvEntradaMaterialExtra" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnRowDataBound="gvEntradaMaterialExtra_RowDataBound">
                        
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Cod.Conta" SortExpression="Codigo" ItemStyle-Width="300px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Entrada" HeaderText="Entrada" SortExpression="Entrada" DataFormatString="{0:n2}" ItemStyle-Width="400px" ItemStyle-Font-Size="Large"/>
                        </Columns>
                        
                        <EmptyDataTemplate>----</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="left: 800px";>
                <strong>
                    <asp:Label ID="Label2" runat="server" BackColor="LightGray" Text="TOTAL GERAL:"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeralEntradaExtra" runat="server"></asp:Label>
            </div>
        </div>
        
        <br />
        <br />        
            
        <!--Gridview com as saídas de material-->
        <strong style="font-size: 18px">Saída de Material</strong>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:GridView ID="gvSaidaMaterial" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnRowDataBound="gvSaidaMaterial_RowDataBound">
                        
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Cod.Conta" SortExpression="Codigo" ItemStyle-Width="300px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Saída" HeaderText="Saída" SortExpression="Saída" DataFormatString="{0:n2}" ItemStyle-Width="400px" ItemStyle-Font-Size="Large"/>
                        </Columns>
                        
                        <EmptyDataTemplate>----</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="left: 800px";>
                <strong>
                    <asp:Label ID="lblValorTotalGeralRotulo" runat="server" BackColor="LightGray" Text="TOTAL GERAL:"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeralSaida" runat="server"></asp:Label>
            </div>
        </div>

        <br />
        <br />
        
        <!--Gridview com saldo atual-->
        <strong style="font-size: 18px">Saldo Atual</strong>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:GridView ID="gvLicitacao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" OnRowDataBound="gvLicitacao_RowDataBound">
                        
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Cod.Conta" SortExpression="Codigo" ItemStyle-Width="300px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="EstoqueAtual" HeaderText="Saldo Atual" SortExpression="EstoqueAtual" DataFormatString="{0:n2}" ItemStyle-Width="400px" ItemStyle-Font-Size="Large"/>
                        </Columns>
                        
                        <EmptyDataTemplate>----</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="left: 800px";>
                <strong>
                    <asp:Label ID="Label3" runat="server" BackColor="LightGray" Text="TOTAL GERAL:"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeralLicitacao" runat="server"></asp:Label>
            </div>
        </div>

        <br />
        <br /> 
        <br />
        <br />
        <br />

        <!--Área para assinatura-->
        <div class="row">
            <table style="width: 1200px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-12" style="left: 150px";>
                            <strong>Local e Data _____________________________, ____/_____/_____</strong>
                        </div>
                    </td>
                    <td style="width: 300px;">
                         <div class="col-md-12" style="left: 180px";>
                            <strong>___________________________________________________</strong>
                        </div>
                    </td>
                </tr>
            </table>
        </div>     

        <div class="row" >
            <table style="width: 600px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-10 col-md-offset-1" style="left: 750px";>
                            <strong>Responsável pelo Almoxarifado</strong>
                        </div>
                    </td>
                </tr>
            </table>
        </div>                 


        <!--Script para reabrir modal buscar saída de material modal-->
        <script type="text/javascript">
            function openBuscarSaidaMaterialModal() {
                $('#BuscarSaidaMaterialModal').modal('show');
            }
        </script>

        <!-- Modal Opções de Buscar uma Saida de Material -->
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
                                        <asp:LinkButton ID="lkbBuscar2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarSaidaMaterial_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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
