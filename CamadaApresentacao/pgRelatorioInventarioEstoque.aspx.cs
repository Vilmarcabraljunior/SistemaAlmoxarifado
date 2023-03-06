using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocio.MODEL;
using CamadaNegocio.BO;

namespace CamadaApresentacao
{
    public partial class pgRelatorioInventarioProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToShortDateString();
            lblAno.Text = DateTime.Now.Year.ToString();
        }

        #region (Métodos Auxiliáres)

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        public void CalcularValorTotalGeral()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemLicitacao.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[7].Text != null && row.Cells[7].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[7].Text);
                    }

                }
            }
            lblValorTotalGeral.Text = ValorTotal.ToString("C2");
        }
                      

        public void LimparFormularioRelatorio()
        {
            gvConta.DataSource = null;
            gvConta.DataBind();

            gvItemLicitacao.DataSource = null;
            gvItemLicitacao.DataBind();

            lblContaDescricao.Text = string.Empty;
            lblContaCodigo.Text = string.Empty;

            lblValorTotalGeral.Text = string.Empty;
                        
        }
        #endregion

        #region (Métodos Principais)

        //Buscar uma conta
        protected void lkbBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaBO contaBO = new ContaBO();
                IList<Conta> listaConta = new List<Conta>();

                if (!string.IsNullOrEmpty(txtBuscarPorNumero.Text))
                {
                    listaConta = contaBO.BuscarPorNumero(txtBuscarPorNumero.Text);
                    gvConta.DataSource = listaConta;
                    gvConta.DataBind();

                    txtBuscarPorNumero.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorDescricao.Text))
                {
                    listaConta = contaBO.BuscarPorDescricao(txtBuscarPorDescricao.Text);
                    gvConta.DataSource = listaConta;
                    gvConta.DataBind();

                    txtBuscarPorDescricao.Text = string.Empty;
                }
                else
                {
                    listaConta = contaBO.BuscarTodasContas();
                    gvConta.DataSource = listaConta;
                    gvConta.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int contaID = Convert.ToInt32(gvConta.SelectedDataKey.Value);

                SqlDataSource1.SelectCommand = "select Conta.contaNumero as Código, conta.contaDescricao as Conta, conta.tipoConta as [Tipo da Conta], COUNT(Produto.produtoID) as [Qtde em Estoque] from ItemLicitacao, Produto, Conta" +
                    " where ItemLicitacao.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID"+
                    " group by Conta.contaNumero, Conta.contaDescricao, conta.tipoConta order by Conta.contaNumero";

                SqlDataSource2.SelectCommand = "select ROW_NUMBER() over(order by Produto.produtoNome) as [N° de Ordem], Produto.codigo as [Código], Produto.produtoNome as [Produto], Unidade.unidadeDescricao as [Unid.], " +
                    " Produto.quantidadeEstoque as [Qtde em Estoque], Conta.contaDescricao as [Conta], Produto.produtoPrecoUnitario as [Preço Unitário]," +
                    " Produto.estoqueValorTotal as [Preço Total]" +
                    " from ItemLicitacao, Produto, Conta, Unidade" +
                    " where ItemLicitacao.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID and Produto.unidadeID = Unidade.unidadeID and Produto.quantidadeEstoque > 0 and " +
                    " Conta.contaID = " + contaID + ""+
                    " order by produto.produtoNome ASC";


                Conta conta = new Conta();
                ContaBO contaBO = new ContaBO();

                conta = contaBO.BuscarPorID(contaID);
                
                lblContaDescricao.Text = conta._ContaDescricao;
                lblContaCodigo.Text = conta._ContaNumero;
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }


        protected void lkbMostrarContasAtuaisEstoque_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "select Conta.contaNumero as Código, conta.contaDescricao as Conta, conta.tipoConta as [Tipo da Conta], COUNT(Produto.produtoID) as [Qtde em Estoque] from ItemLicitacao, Produto, Conta" +
                    " where ItemLicitacao.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID" +
                    " group by Conta.contaNumero, Conta.contaDescricao, conta.tipoConta order by Conta.contaNumero";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openMostrarContasAtuaisEstoqueModal();", true);
        }

        //Método para calcular o valor total geral atarvés do método databound
        protected void gvItemLicitacao_DataBound(object sender, EventArgs e)
        {
            CalcularValorTotalGeral();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }

        #endregion
                
    }
}