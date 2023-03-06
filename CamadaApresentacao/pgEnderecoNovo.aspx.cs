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
    public partial class pgEnderecoNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvEndereco.DataSource = null;
            gvEndereco.DataBind();
        }

        public void LimparFormulario()
        {
            lblEnderecoNovoTitulo.Text = "Novo Endereço";
            lblEnderecoNovoTitulo.CssClass = "fa fa-plus-circle";

            hdEnderecoID.Value = "0";
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtCodigo.Text = string.Empty;
            txtEnderecoDescricao.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do Endereço

        Endereco endereco;
        EnderecoBO enderecoBO;
        IList<Endereco> listaEndereco;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoEnderecoModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                endereco = new Endereco();

                endereco._EnderecoID = Convert.ToInt32(hdEnderecoID.Value);
                endereco._DataCadastro = txtDataCadastro.Text;
                endereco._Codigo = txtCodigo.Text;
                endereco._EnderecoDescricao = txtEnderecoDescricao.Text;

                enderecoBO = new EnderecoBO();
                enderecoBO.Salvar(endereco);

                if (endereco._EnderecoID != 0)
                {
                    if (gvEndereco.Rows.Count == 1)
                    {
                        int id = endereco._EnderecoID;
                        endereco = enderecoBO.BuscarPorID(id);

                        listaEndereco = new List<Endereco>();
                        listaEndereco.Add(endereco);

                        gvEndereco.DataSource = listaEndereco;
                        gvEndereco.DataBind();
                    }
                    else if (gvEndereco.Rows.Count > 1)
                    {
                        listaEndereco = new List<Endereco>();
                        listaEndereco = enderecoBO.BuscarTodosEnderecos();
                        gvEndereco.DataSource = listaEndereco;
                        gvEndereco.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEnderecoModal();", true);

                    Mensagem("Endereço Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Endereço Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoEnderecoModal();", true);
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
                endereco = new Endereco();
                enderecoBO = new EnderecoBO();

                endereco._EnderecoID = Convert.ToInt32(hdEnderecoID.Value);
                enderecoBO.Excluir(endereco);

                Mensagem("Endereço Excluído com Sucesso.", this);

                if (gvEndereco.Rows.Count == 1)
                {
                    int id = endereco._EnderecoID;
                    endereco = enderecoBO.BuscarPorID(id);
                    gvEndereco.DataSource = endereco;
                    gvEndereco.DataBind();
                }
                else if (gvEndereco.Rows.Count > 1)
                {
                    listaEndereco = new List<Endereco>();
                    listaEndereco = enderecoBO.BuscarTodosEnderecos();
                    gvEndereco.DataSource = listaEndereco;
                    gvEndereco.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEnderecoModal();", true);

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
                enderecoBO = new EnderecoBO();
                listaEndereco = new List<Endereco>();

                if (!string.IsNullOrEmpty(txtBuscarPorCodigo.Text))
                {
                    listaEndereco = enderecoBO.BuscarPorCodigo(txtBuscarPorCodigo.Text);
                    gvEndereco.DataSource = listaEndereco;
                    gvEndereco.DataBind();

                    txtBuscarPorCodigo.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorDescricao.Text))
                {
                    listaEndereco = enderecoBO.BuscarPorDescricao(txtBuscarPorDescricao.Text);
                    gvEndereco.DataSource = listaEndereco;
                    gvEndereco.DataBind();

                    txtBuscarPorDescricao.Text = string.Empty;
                }
                else
                {
                    listaEndereco = enderecoBO.BuscarTodosEnderecos();
                    gvEndereco.DataSource = listaEndereco;
                    gvEndereco.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEnderecoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                endereco = new Endereco();
                enderecoBO = new EnderecoBO();

                int id = Convert.ToInt32(gvEndereco.SelectedDataKey.Value);
                endereco = enderecoBO.BuscarPorID(id);

                hdEnderecoID.Value = endereco._EnderecoID.ToString();
                txtDataCadastro.Text = endereco._DataCadastro;
                txtCodigo.Text = endereco._Codigo;
                txtEnderecoDescricao.Text = endereco._EnderecoDescricao;

                lblEnderecoNovoTitulo.Text = "Atualizar Endereço";
                lblEnderecoNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoEnderecoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }

        }

        #endregion

     
    }
}