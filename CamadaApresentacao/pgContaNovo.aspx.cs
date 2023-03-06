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
    public partial class pgContaNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDDLTipoConta();
            }
        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvConta.DataSource = null;
            gvConta.DataBind();
        }

        public void CarregarDDLTipoConta()
        {
            ddlTipoConta.DataSource = Enum.GetNames(typeof(TipoConta));
            ddlTipoConta.DataBind();
        }

        public void LimparFormulario()
        {
            lblContaNovoTitulo.Text = "Nova Conta";
            lblContaNovoTitulo.CssClass = "fa fa-plus-circle";

            hdContaID.Value = "0";
            txtContaDescricao.Text = string.Empty;
            txtContaNumero.Text = string.Empty;
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtContaFuncao.Text = string.Empty;
            ddlTipoConta.SelectedValue = null;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos da Conta

        Conta conta;
        ContaBO contaBO;
        IList<Conta> listaConta;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaContaModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                conta = new Conta();

                conta._ContaID = Convert.ToInt32(hdContaID.Value);
                conta._ContaDescricao = txtContaDescricao.Text;
                conta._ContaNumero = txtContaNumero.Text;
                conta._DataCadastro = txtDataCadastro.Text;
                conta._ContaFuncao = txtContaFuncao.Text;
                conta._TipoConta = (TipoConta)Enum.Parse(typeof(TipoConta), ddlTipoConta.SelectedValue);

                contaBO = new ContaBO();
                contaBO.Salvar(conta);

                if (conta._ContaID != 0)
                {
                    if (gvConta.Rows.Count == 1)
                    {
                        int id = conta._ContaID;
                        conta = contaBO.BuscarPorID(id);

                        listaConta = new List<Conta>();
                        listaConta.Add(conta);

                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();
                    }
                    else if (gvConta.Rows.Count > 1)
                    {
                        listaConta = new List<Conta>();
                        listaConta = contaBO.BuscarTodasContas();
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);

                    Mensagem("Conta Atualizada com Sucesso.", this);
                }
                else
                {
                    Mensagem("Conta Salva com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaContaModal();", true);
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
                conta = new Conta();
                contaBO = new ContaBO();

                conta._ContaID = Convert.ToInt32(hdContaID.Value);
                contaBO.Excluir(conta);

                Mensagem("Conta Excluída com Sucesso.", this);

                if (gvConta.Rows.Count == 1)
                {
                    int id = conta._ContaID;
                    conta = contaBO.BuscarPorID(id);
                    gvConta.DataSource = conta;
                    gvConta.DataBind();
                }
                else if (gvConta.Rows.Count > 1)
                {
                    listaConta = new List<Conta>();
                    listaConta = contaBO.BuscarTodasContas();
                    gvConta.DataSource = listaConta;
                    gvConta.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);

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
                contaBO = new ContaBO();
                listaConta = new List<Conta>();

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
                conta = new Conta();
                contaBO = new ContaBO();

                int id = Convert.ToInt32(gvConta.SelectedDataKey.Value);
                conta = contaBO.BuscarPorID(id);

                hdContaID.Value = conta._ContaID.ToString();
                txtContaDescricao.Text = conta._ContaDescricao;
                txtContaNumero.Text = conta._ContaNumero;
                txtDataCadastro.Text = conta._DataCadastro;
                txtContaFuncao.Text = conta._ContaFuncao;
                ddlTipoConta.SelectedValue = conta._TipoConta.ToString();

                lblContaNovoTitulo.Text = "Atualizar Conta";
                lblContaNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaContaModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

       
    }
}