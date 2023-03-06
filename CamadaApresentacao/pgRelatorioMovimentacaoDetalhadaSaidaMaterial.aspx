<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRelatorioMovimentacaoDetalhadaSaidaMaterial.aspx.cs" Inherits="CamadaApresentacao.pgRelatorioMovimentacaoDetalhadaSaidaMaterial" %>

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
        <div class="row well well-sm">
            <table style="width: 1200px;">
                <tr>
                    <td style="width: 300px";>
                        <div class="col-md-10" style="left: 350px";>
                            <h2><strong>Movimentação Detalhada -- Saída</strong></h2>
                            <strong style="font-size: 18px">Agrupado por: CONTA -- Ordenado por: CONTA</strong>
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
                    
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:GridView ID="gvSaidaMaterial" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="gvSaidaMaterial_RowDataBound">
                        
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Cod.Conta" SortExpression="Codigo" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" ItemStyle-Width="800px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" DataFormatString="{0:n2}" ItemStyle-Font-Size="Large"/>
                        </Columns>
                        
                        <EmptyDataTemplate>Nenhum Produto Adicionado.</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="left: 810px";>
                <strong>
                    <asp:Label ID="lblValorTotalGeralRotulo" runat="server" BackColor="LightGray" Text="TOTAL GERAL:" style="font-size: 14px"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeral" runat="server" style="font-size: 14px"></asp:Label>
            </div>
        </div>

        <br />
        <br />
                          

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
