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
    public partial class pgNomeProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDDLTipoConta();
            }

            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvNomeProduto.DataSource = null;
            gvNomeProduto.DataBind();
        }

        public void CarregarDDLTipoConta()
        {
            ddlTipoConta.DataSource = Enum.GetNames(typeof(TipoConta));
            ddlTipoConta.DataBind();
        }

        public void LimparFormulario()
        {
            lblNomeProdutoNovoTitulo.Text = "Novo Nome do Produto";
            lblNomeProdutoNovoTitulo.CssClass = "fa fa-plus-circle";

            hdNomeProdutoID.Value = "0";
            txtCodigo.Text = string.Empty;
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtProdutoNome.Text = string.Empty;
            txtProdutoPrecoUnitario.Text = string.Empty;

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
            txtContaFuncao.Text = string.Empty;
            ddlTipoConta.SelectedValue = null;
        }

        public void LimparFormularioUnidade()
        {
            hdUnidadeModalID.Value = "0";
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtUnidadeDescricaoModal.Text = string.Empty;
        }

        public void ValidarSalvar()
        {
            if (string.IsNullOrEmpty(txtProdutoPrecoUnitario.Text))
            {
                Mensagem("Campo PREÇO UNITÁRIO é Obrigatório.", this);
            }
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do nome do Produto

        NomeProduto nomeProduto;
        NomeProdutoBO nomeProdutoBO;
        IList<NomeProduto> listaNomeProduto;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarSalvar();

                nomeProduto = new NomeProduto();

                nomeProduto._NomeProdutoID = Convert.ToInt32(hdNomeProdutoID.Value);
                nomeProduto._Codigo = txtCodigo.Text;
                nomeProduto._DataCadastro = txtDataCadastro.Text;
                nomeProduto._ProdutoNome = txtProdutoNome.Text;
                nomeProduto._ProdutoPrecoUnitario = Convert.ToDecimal(txtProdutoPrecoUnitario.Text);

                nomeProduto._Unidade._UnidadeID = Convert.ToInt32(hdUnidadeID.Value);
                nomeProduto._Conta._ContaID = Convert.ToInt32(hdContaID.Value);

                nomeProdutoBO = new NomeProdutoBO();
                nomeProdutoBO.Salvar(nomeProduto);

                if (nomeProduto._NomeProdutoID != 0)
                {
                    if (gvNomeProduto.Rows.Count == 1)
                    {
                        int id = nomeProduto._NomeProdutoID;
                        nomeProduto = nomeProdutoBO.BuscarPorID(id);

                        listaNomeProduto = new List<NomeProduto>();
                        listaNomeProduto.Add(nomeProduto);

                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();
                    }
                    else if (gvNomeProduto.Rows.Count > 1)
                    {
                        listaNomeProduto = new List<NomeProduto>();
                        listaNomeProduto = nomeProdutoBO.BuscarTodosNomesProdutos();
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);

                    Mensagem("Nome do Produto Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Nome do Produto Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
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
                nomeProduto = new NomeProduto();
                nomeProdutoBO = new NomeProdutoBO();

                nomeProduto._NomeProdutoID = Convert.ToInt32(hdNomeProdutoID.Value);
                nomeProdutoBO.Excluir(nomeProduto);

                Mensagem("Nome do Produto Excluído com Sucesso.", this);

                if (gvNomeProduto.Rows.Count == 1)
                {
                    int id = nomeProduto._NomeProdutoID;
                    nomeProduto = nomeProdutoBO.BuscarPorID(id);
                    gvNomeProduto.DataSource = nomeProduto;
                    gvNomeProduto.DataBind();
                }
                else if (gvNomeProduto.Rows.Count > 1)
                {
                    listaNomeProduto = new List<NomeProduto>();
                    listaNomeProduto = nomeProdutoBO.BuscarTodosNomesProdutos();
                    gvNomeProduto.DataSource = listaNomeProduto;
                    gvNomeProduto.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);

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
                nomeProdutoBO = new NomeProdutoBO();
                listaNomeProduto = new List<NomeProduto>();

                if (!string.IsNullOrEmpty(txtBuscarPorCodigo.Text))
                {
                    listaNomeProduto = nomeProdutoBO.BuscarPorCodigo(txtBuscarPorCodigo.Text);
                    gvNomeProduto.DataSource = listaNomeProduto;
                    gvNomeProduto.DataBind();

                    txtBuscarPorCodigo.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorNome.Text))
                {
                    listaNomeProduto = nomeProdutoBO.BuscarPorNome(txtBuscarPorNome.Text);
                    gvNomeProduto.DataSource = listaNomeProduto;
                    gvNomeProduto.DataBind();

                    txtBuscarPorNome.Text = string.Empty;
                }
                else
                {
                    listaNomeProduto = nomeProdutoBO.BuscarTodosNomesProdutos();
                    gvNomeProduto.DataSource = listaNomeProduto;
                    gvNomeProduto.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
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
                nomeProduto = new NomeProduto();
                nomeProdutoBO = new NomeProdutoBO();

                int id = Convert.ToInt32(gvNomeProduto.SelectedDataKey.Value);
                nomeProduto = nomeProdutoBO.BuscarPorID(id);

                hdNomeProdutoID.Value = nomeProduto._NomeProdutoID.ToString();
                txtCodigo.Text = nomeProduto._Codigo;
                txtDataCadastro.Text = nomeProduto._DataCadastro;
                txtProdutoNome.Text = nomeProduto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = nomeProduto._ProdutoPrecoUnitario.ToString();

                hdContaID.Value = nomeProduto._Conta._ContaID.ToString();
                txtConta.Text = nomeProduto._Conta._ContaDescricao;
                txtContaNumero.Text = nomeProduto._Conta._ContaNumero;

                hdUnidadeID.Value = nomeProduto._Unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = nomeProduto._Unidade._UnidadeDescricao;

                lblNomeProdutoNovoTitulo.Text = "Atualizar Nome do Produto";
                lblNomeProdutoNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
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
                conta._ContaFuncao = txtContaFuncao.Text;
                conta._TipoConta = (TipoConta)Enum.Parse(typeof(TipoConta), ddlTipoConta.SelectedValue);

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

                hdContaID.Value = conta._ContaID.ToString();
                txtConta.Text = conta._ContaDescricao;
                txtContaNumero.Text = conta._ContaNumero;
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
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

                hdUnidadeID.Value = unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion
         
    }
}