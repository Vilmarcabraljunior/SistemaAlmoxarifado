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
    public partial class pgProdutoNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroNomeProduto.Text = DateTime.Now.ToLongDateString();
        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvProduto.DataSource = null;
            gvProduto.DataBind();
        }

        public void LimparFormulario()
        {
            lblProdutoNovoTitulo.Text = "Novo Produto";
            lblProdutoNovoTitulo.CssClass = "fa fa-plus-circle";

            hdProdutoID.Value = "0";
            txtCodigo.Text = string.Empty;
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtProdutoNome.Text = string.Empty;
            txtProdutoPrecoUnitario.Text = string.Empty;
            txtQuantidadeAtendida.Text = string.Empty;
            txtQuantidadeSolicitada.Text = string.Empty;

            hdContaID.Value = "0";
            txtConta.Text = string.Empty;
            txtContaNumero.Text = string.Empty;

            hdUnidadeID.Value = "0";
            txtUnidadeDescricao.Text = string.Empty;
        }

        public void LimparFormularioConta()
        {
            hdContaModalID.Value = "0";
            txtContaDescricao.Text = string.Empty;
            txtContaNumeroModal.Text = string.Empty;
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
        }

        public void LimparFormularioUnidade()
        {
            hdUnidadeModalID.Value = "0";
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtUnidadeDescricaoModal.Text = string.Empty;
        }

        public void LimparFormularioNomeProduto()
        {
            hdNomeProdutoID.Value = "0";
            txtCodigoModal.Text = string.Empty;
            txtDataCadastroNomeProduto.Text = DateTime.Now.ToLongDateString();
            txtProdutoNomeModal.Text = string.Empty;
            txtProdutoPrecoUnitarioProdutoNome.Text = string.Empty;

            hdContaIDProdutoNome.Value = "0";
            txtContaProdutoNome.Text = string.Empty;
            txtContaNumeroProdutoNome.Text = string.Empty;

            hdUnidadeIDProdutoNome.Value = "0";
            txtUnidadeDescricaoProdutoNome.Text = string.Empty;
        }
               
        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do Produto

        Produto produto;
        ProdutoBO produtoBO;
        IList<Produto> listaProduto;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                produto = new Produto();

                produto._ProdutoID = Convert.ToInt32(hdProdutoID.Value);
                produto._Codigo = txtCodigo.Text;
                produto._DataCadastro = txtDataCadastro.Text;
                produto._ProdutoNome = txtProdutoNome.Text;
                produto._ProdutoPrecoUnitario = Convert.ToDecimal(txtProdutoPrecoUnitario.Text);
                produto._QuantidadeAtendida = Convert.ToInt32(txtQuantidadeAtendida.Text);
                produto._QuantidadeSolicitada = Convert.ToInt32(txtQuantidadeSolicitada.Text);
                produto._ProdutoValorTotal = Convert.ToDecimal(produto._ProdutoPrecoUnitario * produto._QuantidadeAtendida);

                produto._Conta._ContaID = Convert.ToInt32(hdContaID.Value);
                produto._Unidade._UnidadeID = Convert.ToInt32(hdUnidadeID.Value);

                produtoBO = new ProdutoBO();
                produtoBO.Salvar(produto);

                if (produto._ProdutoID != 0)
                {
                    if (gvProduto.Rows.Count == 1)
                    {
                        int id = produto._ProdutoID;
                        produto = produtoBO.BuscarPorID(id);

                        listaProduto = new List<Produto>();
                        listaProduto.Add(produto);

                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();
                    }
                    else if (gvProduto.Rows.Count > 1)
                    {
                        listaProduto = new List<Produto>();
                        listaProduto = produtoBO.BuscarTodosProdutos();
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);

                    Mensagem("Produto Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Produto Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                }

                LimparFormulario();
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                produto = new Produto();
                produtoBO = new ProdutoBO();

                produto._ProdutoID = Convert.ToInt32(hdProdutoID.Value);
                produtoBO.Excluir(produto);

                Mensagem("Produto Excluído com Sucesso.", this);

                if (gvProduto.Rows.Count == 1)
                {
                    int id = produto._ProdutoID;
                    produto = produtoBO.BuscarPorID(id);
                    gvProduto.DataSource = produto;
                    gvProduto.DataBind();
                }
                else if (gvProduto.Rows.Count > 1)
                {
                    listaProduto = new List<Produto>();
                    listaProduto = produtoBO.BuscarTodosProdutos();
                    gvProduto.DataSource = listaProduto;
                    gvProduto.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);

                LimparFormulario();
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }


        protected void lkbBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                produtoBO = new ProdutoBO();
                listaProduto = new List<Produto>();

                if (!string.IsNullOrEmpty(txtBuscarPorCodigo.Text))
                {
                    listaProduto = produtoBO.BuscarPorCodigo(txtBuscarPorCodigo.Text);
                    gvProduto.DataSource = listaProduto;
                    gvProduto.DataBind();

                    txtBuscarPorCodigo.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorNome.Text))
                {
                    listaProduto = produtoBO.BuscarPorNome(txtBuscarPorNome.Text);
                    gvProduto.DataSource = listaProduto;
                    gvProduto.DataBind();

                    txtBuscarPorNome.Text = string.Empty;
                }
                else
                {
                    listaProduto = produtoBO.BuscarTodosProdutos();
                    gvProduto.DataSource = listaProduto;
                    gvProduto.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                produto = new Produto();
                produtoBO = new ProdutoBO();

                int id = Convert.ToInt32(gvProduto.SelectedDataKey.Value);
                produto = produtoBO.BuscarPorID(id);

                hdProdutoID.Value = produto._ProdutoID.ToString();
                txtCodigo.Text = produto._Codigo;
                txtDataCadastro.Text = produto._DataCadastro;
                txtProdutoNome.Text = produto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = produto._ProdutoPrecoUnitario.ToString();
                txtQuantidadeAtendida.Text = produto._QuantidadeAtendida.ToString();
                txtQuantidadeSolicitada.Text = produto._QuantidadeSolicitada.ToString();

                hdContaID.Value = produto._Conta._ContaID.ToString();
                txtConta.Text = produto._Conta._ContaDescricao;
                txtContaNumero.Text = produto._Conta._ContaNumero;

                hdUnidadeID.Value = produto._Unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = produto._Unidade._UnidadeDescricao;

                lblProdutoNovoTitulo.Text = "Atualizar Produto";
                lblProdutoNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region Eventos da Conta

        protected void lkbSalvarConta_Click(object sender, EventArgs e)
        {
            try
            {
                Conta conta = new Conta();
                ContaBO contaBO = new ContaBO();

                conta._ContaID = Convert.ToInt32(hdContaModalID.Value);
                conta._ContaDescricao = txtContaDescricao.Text;
                conta._ContaNumero = txtContaNumeroModal.Text;
                conta._DataCadastro = txtDataCadastroConta.Text;

                contaBO.Salvar(conta);

                Mensagem("Conta Salva com Sucesso.", this);

                LimparFormularioConta();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarConta_Click(object sender, EventArgs e)
        {
            LimparFormularioConta();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
        }

        protected void lkbBuscarConta_Click(object sender, EventArgs e)
        {
            try
            {
                ContaBO contaBO = new ContaBO();
                IList<Conta> listaConta = new List<Conta>();

                if (!string.IsNullOrEmpty(txtBuscarContaPorNumero.Text))
                {
                    listaConta = contaBO.BuscarPorNumero(txtBuscarContaPorNumero.Text);
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        txtBuscarContaPorNumero.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        txtBuscarContaPorNumero.Text = string.Empty;

                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }

                }
                else if (!string.IsNullOrEmpty(txtBuscarContaPorDescricao.Text))
                {
                    listaConta = contaBO.BuscarPorDescricao(txtBuscarContaPorDescricao.Text);
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        txtBuscarContaPorDescricao.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        txtBuscarContaPorDescricao.Text = string.Empty;

                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
                else
                {
                    listaConta = contaBO.BuscarTodasContas();
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
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
                Conta conta = new Conta();
                ContaBO contaBO = new ContaBO();

                int id = Convert.ToInt32(gvConta.SelectedDataKey.Value);
                conta = contaBO.BuscarPorID(id);

                hdContaIDProdutoNome.Value = conta._ContaID.ToString();
                txtContaProdutoNome.Text = conta._ContaDescricao;
                txtContaNumeroProdutoNome.Text = conta._ContaNumero;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region Eventos da Unidade

        protected void lkbSalvarUnidade_Click(object sender, EventArgs e)
        {
            try
            {
                Unidade unidade = new Unidade();
                UnidadeBO unidadeBO = new UnidadeBO();

                unidade._UnidadeID = Convert.ToInt32(hdUnidadeModalID.Value);
                unidade._DataCadastro = txtDataCadastroUnidade.Text;
                unidade._UnidadeDescricao = txtUnidadeDescricaoModal.Text;

                unidadeBO.Salvar(unidade);

                Mensagem("Unidade Salva com Sucesso.", this);

                LimparFormularioUnidade();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarUnidade_Click(object sender, EventArgs e)
        {
            LimparFormularioUnidade();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
        }

        protected void lkbBuscarUnidade_Click(object sender, EventArgs e)
        {
            try
            {
                UnidadeBO unidadeBO = new UnidadeBO();
                IList<Unidade> listaUnidade = new List<Unidade>();

                if (!string.IsNullOrEmpty(txtBuscarUnidadePorDescricao.Text))
                {
                    listaUnidade = unidadeBO.BuscarPorDescricao(txtBuscarUnidadePorDescricao.Text);
                    if (listaUnidade != null)
                    {
                        gvUnidade.DataSource = listaUnidade;
                        gvUnidade.DataBind();

                        txtBuscarUnidadePorDescricao.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);
                    }
                    else
                    {
                        txtBuscarUnidadePorDescricao.Text = string.Empty;

                        Mensagem("Nenhuma Unidade Encontrada", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }

                }
                else
                {
                    listaUnidade = unidadeBO.BuscarTodasUnidades();
                    if (listaUnidade != null)
                    {
                        gvUnidade.DataSource = listaUnidade;
                        gvUnidade.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhuma Unidade Encontrada", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Unidade unidade = new Unidade();
                UnidadeBO unidadeBO = new UnidadeBO();

                int id = Convert.ToInt32(gvUnidade.SelectedDataKey.Value);
                unidade = unidadeBO.BuscarPorID(id);

                hdUnidadeIDProdutoNome.Value = unidade._UnidadeID.ToString();
                txtUnidadeDescricaoProdutoNome.Text = unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region (Eventos do nome do Produto)

        protected void lkbSalvarNomeProduto_Click(object sender, EventArgs e)
        {
            try
            {
                NomeProduto nomeProduto = new NomeProduto();
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();

                nomeProduto._NomeProdutoID = Convert.ToInt32(hdNomeProdutoID.Value);
                nomeProduto._Codigo = txtCodigoModal.Text;
                nomeProduto._DataCadastro = txtDataCadastroNomeProduto.Text;
                nomeProduto._ProdutoNome = txtProdutoNomeModal.Text;
                nomeProduto._ProdutoPrecoUnitario = Convert.ToDecimal(txtProdutoPrecoUnitarioProdutoNome.Text);

                nomeProduto._Conta._ContaID = Convert.ToInt32(hdContaIDProdutoNome.Value);
                nomeProduto._Unidade._UnidadeID = Convert.ToInt32(hdUnidadeIDProdutoNome.Value);
                
                nomeProdutoBO.Salvar(nomeProduto);

                Mensagem("Nome do Produto Salvo com Sucesso.", this);

                LimparFormularioNomeProduto();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarNomeProduto_Click(object sender, EventArgs e)
        {
            LimparFormularioNomeProduto();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
        }

        protected void lkbBuscarNomeProduto_Click(object sender, EventArgs e)
        {
            try
            {
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();
                IList<NomeProduto> listaNomeProduto = new List<NomeProduto>();

                if (!string.IsNullOrEmpty(txtBuscarNomeProdutoPorCodigo.Text))
                {
                    listaNomeProduto = nomeProdutoBO.BuscarPorCodigo(txtBuscarNomeProdutoPorCodigo.Text);
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        txtBuscarNomeProdutoPorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarNomeProdutoPorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarNomeProdutoPorNome.Text))
                {
                    listaNomeProduto = nomeProdutoBO.BuscarPorNome(txtBuscarNomeProdutoPorNome.Text);
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        txtBuscarNomeProdutoPorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarNomeProdutoPorNome.Text = string.Empty;

                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
                else
                {
                    listaNomeProduto = nomeProdutoBO.BuscarTodosNomesProdutos();
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvNomeProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NomeProduto nomeProduto = new NomeProduto();
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();

                int id = Convert.ToInt32(gvNomeProduto.SelectedDataKey.Value);
                nomeProduto = nomeProdutoBO.BuscarPorID(id);

                txtCodigo.Text = nomeProduto._Codigo;
                txtProdutoNome.Text = nomeProduto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = nomeProduto._ProdutoPrecoUnitario.ToString();

                hdContaID.Value = nomeProduto._Conta._ContaID.ToString();
                txtConta.Text = nomeProduto._Conta._ContaDescricao;
                txtContaNumero.Text = nomeProduto._Conta._ContaNumero;

                hdUnidadeID.Value = nomeProduto._Unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = nomeProduto._Unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
               
        #endregion
         
    }
}