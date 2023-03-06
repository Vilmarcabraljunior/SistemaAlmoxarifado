<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRelatorioMovimentacaoDetalhadaEntradaMaterial.aspx.cs" Inherits="CamadaApresentacao.pgRelatorioMovimentacaoDetalhadaEntradaMaterial" %>

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
        <!--Botões cancelar, imprimir e buscar entrada de material-->
        <div class="row">
            <div class="col-md-2">
                <asp:LinkButton ID="lkbCancelar" runat="server" CssClass="btn btn-default btn-sm hidden-print" OnClick="lkbCancelar_Click"><i class="fa fa-reply"></i></asp:LinkButton>
                <asp:LinkButton ID="lkImprimir" runat="server" CssClass="btn btn-success btn-sm hidden-print" OnClientClick="javascript:window.print();"><i class="fa fa-print"></i></asp:LinkButton>
                <asp:LinkButton ID="lkbBuscarEntradaMaterialModal" runat="server" CssClass="btn btn-success btn-sm hidden-print" data-toggle="modal" data-target="#BuscarEntradaMaterialModal"><i class="fa fa-search"></i></asp:LinkButton>
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
                            <h2><strong>Movimentação Detalhada -- Entrada</strong></h2>
                            <strong style="font-size: 18px">Agrupado por: CONTA -- Ordenado por: FORNECEDOR</strong>
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
         
        <!--Gridview com as entradas de material tipo orçamentário-->
        <strong style="font-size: 18px">Entrada de Material(Orçamentário)</strong>          
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:GridView ID="gvEntradaMaterial" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"  OnDataBound="gvEntradaMaterial_DataBound">
                        
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Cod.Conta" SortExpression="Codigo" ItemStyle-Width="300px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" ItemStyle-Width="500px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Fornecedor" HeaderText="Fornecedor" SortExpression="Fornecedor" ItemStyle-Width="650px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" DataFormatString="{0:n2}" ItemStyle-Width="300px" ItemStyle-Font-Size="Large"/>
                        </Columns>                
                               
                        <EmptyDataTemplate>Nenhum Produto Adicionado.</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3" style="left: 730px";>
                <strong>
                    <asp:Label ID="lblValorTotalGeralRotulo" runat="server" BackColor="LightGray" Text="TOTAL ORÇAMENTÁRIO:"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeral" runat="server"></asp:Label>
                <asp:Label ID="lblValorTotalGeralInvisivel" runat="server" Visible="false"></asp:Label>
            </div>
        </div>

        <br />
        <br />
                  

        <!--Gridview com as entradas de material tipo Extra - Orçamentário-->
        <strong style="font-size: 18px">Entrada de Material(Extra - Orçamentário)</strong>          
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StringConexao %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:GridView ID="gvEntradaMaterialExtra" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnDataBound="gvEntradaMaterialExtra_DataBound">
                        
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Cod.Conta" SortExpression="Codigo" ItemStyle-Width="300px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Conta" HeaderText="Conta" SortExpression="Conta" ItemStyle-Width="500px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Fornecedor" HeaderText="Fornecedor" SortExpression="Fornecedor" ItemStyle-Width="650px" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" DataFormatString="{0:n2}" ItemStyle-Width="300px" ItemStyle-Font-Size="Large"/>
                        </Columns>                
                               
                        <EmptyDataTemplate>Nenhum Produto Extra - Orçamentário.</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3" style="left: 705px";>
                <strong>
                    <asp:Label ID="Label1" runat="server" BackColor="LightGray" Text="TOTAL EXTRA - ORÇAMENTÁRIO:"></asp:Label>
                </strong>
                <asp:Label ID="lblValorTotalGeralExtra" runat="server"></asp:Label>
                <asp:Label ID="lblValorTotalGeralExtraInvisivel" runat="server" Visible="false"></asp:Label>
            </div>
        </div>        

        <br />
        <br />

        <div class="row">
            <div class="col-md-3" style="left: 800px";>
                <strong>
                    <asp:Label ID="Label2" runat="server" BackColor="LightGray" Text="TOTAL GERAL:"></asp:Label>
                </strong>
                <asp:Label ID="lblSomaOrçamentariaExtra" runat="server"></asp:Label>
            </div>
        </div>

        <!--Script para reabrir modal buscar uma entrada de material modal-->
        <script type="text/javascript">
            function openBuscarEntradaMaterialModal() {
                $('#BuscarEntradaMaterialModal').modal('show');
            }
        </script>

        <!-- Modal Opções de Buscar uma entrada de Material -->
        <div class="modal fade" id="BuscarEntradaMaterialModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
                                        <asp:LinkButton ID="lkbBuscar2" runat="server" CssClass="btn btn-success btn-sm" OnClick="lkbBuscarEntradaMaterial_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
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
