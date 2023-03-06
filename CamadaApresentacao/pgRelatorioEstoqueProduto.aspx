<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRelatorioEstoqueProduto.aspx.cs" Inherits="CamadaApresentacao.pgRelatorioEstoqueProduto" %>

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
        <!--Botões Cancelar e imprimir-->
        <div class="row">
            <div class="col-md-2">
                <asp:LinkButton ID="lkbCancelar" runat="server" CssClass="btn btn-default btn-sm hidden-print" OnClick="lkbCancelar_Click"><i class="fa fa-reply"></i></asp:LinkButton>
                <asp:LinkButton ID="lkImprimir" runat="server" CssClass="btn btn-success btn-sm hidden-print" OnClientClick="javascript:window.print();"><i class="fa fa-print"></i></asp:LinkButton>
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
            <table style="width: 1300px;">
                <tr>
                    <td style="width: 300px;">
                        <div class="col-md-11">
                            <h2>Estoque Atual de Produtos</h2>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />

        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvItemLicitacao" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_ItemLicitacaoID">
                        <Columns>
                            <asp:BoundField DataField="_Produto._Codigo" HeaderText="Código" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._ProdutoNome" HeaderText="Produto" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._Unidade._UnidadeDescricao" HeaderText="Unid." ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._QuantidadeEstoque" HeaderText="Qtde em Estoque" DataFormatString="{0:n0}" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._Conta._ContaDescricao" HeaderText="Conta" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._ProdutoPrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:n2}" ItemStyle-Font-Size="Large"/>
                            <asp:BoundField DataField="_Produto._EstoqueValorTotal" HeaderText="Preço Total" DataFormatString="{0:n2}" ItemStyle-Font-Size="Large"/>
                        </Columns>
                        <EmptyDataTemplate>
                            <h4><strong>Estoque Vázio.</strong></h4>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <div class="row" >
            <table style="width: 600px;">
                <tr>
                    <td style="width: 300px";>
                        <div class="col-md-10" style="left: 750px";>
                            <strong>
                                <asp:Label ID="lblQuantidadeTotalRotulo" runat="server" BackColor="LightGray" Text="QUANTIDADE GERAL:"></asp:Label></strong>
                                <asp:Label ID="lblQuantidadeTotalGeral" runat="server"></asp:Label>
                        </div>
                    </td>
                    <td style="width: 300px;">
                        <div class="col-md-10" style="left: 700px";>
                           <strong>
                                <asp:Label ID="lblValorTotalGeralRotulo" runat="server" BackColor="LightGray" Text=" VALOR GERAL:"></asp:Label></strong>
                                <asp:Label ID="lblValorTotalGeral" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        
    </form>
</body>
</html>
