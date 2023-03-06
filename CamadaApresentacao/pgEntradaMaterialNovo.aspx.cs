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
    public partial class pgEntradaMaterialNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDataCadastroFornecedor.Text = DateTime.Now.ToLongDateString();

            txtDataCadastroProduto.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroNomeProduto.Text = DateTime.Now.ToLongDateString();

            if (!IsPostBack)
            {
                CarregarDDLProdutoTipo();
            }

            //Método para atulizar preço médio dos produtos que estão em todas as operações.
            ProdutoBO produtoBO = new ProdutoBO();
            produtoBO.AtualizarPrecoUnitarioMedioEstoque();
        }

        #region Métodos Auxiliares

        public void LimparFormulario()
        {
            lblEntradaMaterialNovoTitulo.Text = "Nova Entrada de Material";
            lblEntradaMaterialNovoTitulo.CssClass = "fa fa-plus-circle";

            hdEntradaMaterialID.Value = "0";
            txtDataCadastroEntradaMaterial.Text = DateTime.Now.ToShortDateString();
            txtEntradaMaterialObservacao.Text = string.Empty;

            hdFornecedorID.Value = "0";
            txtFornecedorNome.Text = string.Empty;

            hdProcessoID.Value = "0";
            txtProcessoNumero.Text = string.Empty;
            txtProcessoData.Text = string.Empty;

            hdUsuarioID.Value = "0";

            gvItemEntradaMaterial.DataSource = null;
            gvItemEntradaMaterial.DataBind();
        }

        public void LimparFormularioDetalhes()
        {
            hdDetalhesEntradaMaterialID.Value = "0";
            lblDataCadastroEntradaMaterial.Text = DateTime.Now.ToShortDateString();
            txtEntradaMaterialObservacaoDetalhes.Text = string.Empty;

            lblFornecedorNome.Text = string.Empty;

            lblProcessoNumero.Text = string.Empty;
            lblProcessoData.Text = string.Empty;

            lblUsuarioNome.Text = string.Empty;
            lblUsuarioArea.Text = string.Empty;

            gvItemEntradaMaterialDetalhes.DataSource = null;
            gvItemEntradaMaterialDetalhes.DataBind();

            lblValorTotalGeralDetalhes.Text = string.Empty;
        }

        public void LimparFormularioFornecedor()
        {
            hdFornecedorModalID.Value = "0";
            txtDataCadastroFornecedor.Text = DateTime.Now.ToLongDateString();
            txtFornecedorNomeModal.Text = string.Empty;
        }

        public void LimparFormularioProcesso()
        {
            hdProcessoModalID.Value = "0";
            txtProcessoDataModal.Text = string.Empty;
            txtProcessoNumeroModal.Text = string.Empty;
        }

        public void ValidacaoSalvarProduto()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                Mensagem("Campo CÓDIGO DO PRODUTO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (string.IsNullOrEmpty(txtDataCadastroProduto.Text))
            {
                Mensagem("Campo DATA DO CADASTRO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (string.IsNullOrEmpty(txtProdutoNome.Text))
            {
                Mensagem("Campo NOME DO PRODUTO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (ddlProdutoTipo.SelectedValue.ToString() == "0")
            {
                Mensagem("Campo TIPO DO PRODUTO é obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }

            else if (hdContaID.Value == "0")
            {
                Mensagem("Selecione uma CONTA.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (hdUnidadeID.Value == "0")
            {
                Mensagem("Selecione uma UNIDADE.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
        }

        public void LimparFormularioProduto()
        {
            hdProdutoID.Value = "0";
            txtCodigo.Text = string.Empty;
            txtDataCadastroProduto.Text = DateTime.Now.ToLongDateString();
            txtProdutoNome.Text = string.Empty;
            txtProdutoPrecoUnitario.Text = string.Empty;
            txtQuantidadeEntrada.Text = "0";
            ddlProdutoTipo.SelectedValue = null;

            hdContaID.Value = "0";
            txtConta.Text = string.Empty;
            txtContaNumero.Text = string.Empty;

            hdUnidadeID.Value = "0";
            txtUnidadeDescricao.Text = string.Empty;
        }

        public void CarregarDDLProdutoTipo()
        {
            ddlProdutoTipo.DataSource = Enum.GetNames(typeof(ProdutoTipo));
            ddlProdutoTipo.DataBind();
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

        public void CalcularValorTotalGeralItemEntradaMaterialDetalhes()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemEntradaMaterialDetalhes.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[7].Text != null && row.Cells[7].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[7].Text);
                    }

                }
            }
            lblValorTotalGeralDetalhes.Text = ValorTotal.ToString("C2");
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        #endregion

        #region Eventos da Entrada de Material

        #region (Eventos Principais)

        EntradaMaterial entradaMaterial;
        EntradaMaterialBO entradaMaterialBO;
        IList<EntradaMaterial> listaEntradaMaterial;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastroEntradaMaterial.Text = DateTime.Now.ToShortDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                entradaMaterial = new EntradaMaterial();

                entradaMaterial._EntradaMaterialID = Convert.ToInt32(hdEntradaMaterialID.Value);
                entradaMaterial._DataCadastro = txtDataCadastroEntradaMaterial.Text;
                entradaMaterial._HoraCadastro = DateTime.Now.ToShortTimeString();
                entradaMaterial._Observacao = txtEntradaMaterialObservacao.Text;

                entradaMaterial._Fornecedor._FornecedorID = Convert.ToInt32(hdFornecedorID.Value);
                entradaMaterial._Processo._ProcessoID = Convert.ToInt32(hdProcessoID.Value);

                if (hdEntradaMaterialID.Value != "0")
                {
                    entradaMaterial._Usuario._UsuarioID = Convert.ToInt32(hdUsuarioID.Value);
                }
                else
                {
                    var usuario = (Usuario)Session["UsuarioLogado"];
                    entradaMaterial._Usuario._UsuarioID = usuario._UsuarioID;
                }

                entradaMaterialBO = new EntradaMaterialBO();

                //salva e retorna o id para o hiddenfild para gravar os itens da entrada de material.
                int entradaMaterialIDRetornado = entradaMaterialBO.Salvar(entradaMaterial);
                txtEntradaMaterialID.Text = entradaMaterialIDRetornado.ToString();

                if (entradaMaterial._EntradaMaterialID != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAdicionarItemEntradaMaterialModal();", true);

                    Mensagem("Entrada de Material Atualizada com Sucesso.", this);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAdicionarItemEntradaMaterialModal();", true);

                    Mensagem("Entrada de Material Salva com Sucesso.", this);
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
                entradaMaterial = new EntradaMaterial();
                entradaMaterialBO = new EntradaMaterialBO();

                //Primeiro excluir os itens da Entrada de Material para não dar erro de integridade no banco

                //Excluir os itens da Entrada de Material
                ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();

                itemEntradaMaterialBO.ExcluirItensDaEntradaMaterial(Convert.ToInt32(hdEntradaMaterialID.Value));

                //excluir uma Entrada de Material
                entradaMaterial._EntradaMaterialID = Convert.ToInt32(hdEntradaMaterialID.Value);
                entradaMaterialBO.Excluir(entradaMaterial);

                Mensagem("Entrada de Material Excluída com Sucesso.", this);

                if (gvEntradaMaterial.Rows.Count == 1)
                {
                    int id = entradaMaterial._EntradaMaterialID;
                    entradaMaterial = entradaMaterialBO.BuscarPorID(id);
                    gvEntradaMaterial.DataSource = entradaMaterial;
                    gvEntradaMaterial.DataBind();
                }
                else if (gvEntradaMaterial.Rows.Count > 1)
                {
                    listaEntradaMaterial = new List<EntradaMaterial>();
                    listaEntradaMaterial = entradaMaterialBO.BuscarTodasEntradasMaterial();
                    gvEntradaMaterial.DataSource = listaEntradaMaterial;
                    gvEntradaMaterial.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEntradaMaterialModal();", true);

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
                entradaMaterialBO = new EntradaMaterialBO();
                listaEntradaMaterial = new List<EntradaMaterial>();

                if (!string.IsNullOrEmpty(txtBuscarPorData.Text))
                {
                    listaEntradaMaterial = entradaMaterialBO.BuscarPorEntradaData(txtBuscarPorData.Text);
                    gvEntradaMaterial.DataSource = listaEntradaMaterial;
                    gvEntradaMaterial.DataBind();

                    txtBuscarPorData.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {
                    listaEntradaMaterial = entradaMaterialBO.BuscarEntradaDataPorBetween(txtBuscarPorDataInicial.Text, txtBuscarPorDataFinal.Text);
                    gvEntradaMaterial.DataSource = listaEntradaMaterial;
                    gvEntradaMaterial.DataBind();

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;
                }
                else
                {
                    listaEntradaMaterial = entradaMaterialBO.BuscarTodasEntradasMaterial();
                    gvEntradaMaterial.DataSource = listaEntradaMaterial;
                    gvEntradaMaterial.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEntradaMaterialModal();", true);

            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarEntradaMaterialPorUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBO usuarioBO = new UsuarioBO();
                IList<Usuario> listaUsuario = new List<Usuario>();

                if (!string.IsNullOrEmpty(txtBuscarPorUsuario.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorUsuario.Text);
                    gvBuscarEntradaMaterialPorUsuario.DataSource = listaUsuario;
                    gvBuscarEntradaMaterialPorUsuario.DataBind();

                    txtBuscarPorUsuario.Text = string.Empty;
                }
                else
                {
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvBuscarEntradaMaterialPorUsuario.DataSource = listaUsuario;
                    gvBuscarEntradaMaterialPorUsuario.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarEntradaMaterialPorUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarEntradaMaterialPorUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                entradaMaterialBO = new EntradaMaterialBO();
                listaEntradaMaterial = new List<EntradaMaterial>();

                int usuarioID = Convert.ToInt32(gvBuscarEntradaMaterialPorUsuario.SelectedDataKey.Value);
                listaEntradaMaterial = entradaMaterialBO.BuscarPorUsuario(usuarioID);

                gvEntradaMaterial.DataSource = listaEntradaMaterial;
                gvEntradaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarEntradaMaterialPorFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                FornecedorBO fornecedorBO = new FornecedorBO();
                IList<Fornecedor> listaFornecedor = new List<Fornecedor>();

                if (!string.IsNullOrEmpty(txtBuscarPorFornecedor.Text))
                {
                    listaFornecedor = fornecedorBO.BuscarPorNome(txtBuscarPorFornecedor.Text);
                    gvBuscarEntradaMaterialPorFornecedor.DataSource = listaFornecedor;
                    gvBuscarEntradaMaterialPorFornecedor.DataBind();

                    txtBuscarPorFornecedor.Text = string.Empty;
                }
                else
                {
                    listaFornecedor = fornecedorBO.BuscarTodosFornecedores();
                    gvBuscarEntradaMaterialPorFornecedor.DataSource = listaFornecedor;
                    gvBuscarEntradaMaterialPorFornecedor.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarEntradaMaterialPorFornecedorModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarEntradaMaterialPorFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                entradaMaterialBO = new EntradaMaterialBO();
                listaEntradaMaterial = new List<EntradaMaterial>();

                int fornecedorID = Convert.ToInt32(gvBuscarEntradaMaterialPorFornecedor.SelectedDataKey.Value);
                listaEntradaMaterial = entradaMaterialBO.BuscarPorFornecedor(fornecedorID);

                gvEntradaMaterial.DataSource = listaEntradaMaterial;
                gvEntradaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvEntradaMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                entradaMaterial = new EntradaMaterial();
                entradaMaterialBO = new EntradaMaterialBO();

                int entradaMaterialID = Convert.ToInt32(gvEntradaMaterial.SelectedDataKey.Value);
                entradaMaterial = entradaMaterialBO.BuscarPorID(entradaMaterialID);

                hdDetalhesEntradaMaterialID.Value = entradaMaterial._EntradaMaterialID.ToString();
                lblDataCadastroEntradaMaterial.Text = entradaMaterial._DataCadastro;
                txtEntradaMaterialObservacaoDetalhes.Text = entradaMaterial._Observacao;

                lblFornecedorNome.Text = entradaMaterial._Fornecedor._FornecedorNome;

                lblProcessoNumero.Text = entradaMaterial._Processo._ProcessoNumero;
                lblProcessoData.Text = entradaMaterial._Processo._ProcessoData;

                lblUsuarioNome.Text = entradaMaterial._Usuario._UsuarioNome;
                lblUsuarioArea.Text = entradaMaterial._Usuario._Area._AreaNome;

                //mostar todos os itens da entrada de material.
                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();

                listaItemEntradaMaterial = itemEntradaMaterialBO.BuscarItensDaEntradaMaterial(entradaMaterialID);
                gvItemEntradaMaterialDetalhes.DataSource = listaItemEntradaMaterial;
                gvItemEntradaMaterialDetalhes.DataBind();

                //calcular valor total geral dos detalhes do item da entrada de material
                CalcularValorTotalGeralItemEntradaMaterialDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEntradaMaterialDetalhesModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region (Eventos do Detalhes)

        protected void lkbAtualizarDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                lblEntradaMaterialNovoTitulo.Text = "Atualizar Entrada de Material";
                lblEntradaMaterialNovoTitulo.CssClass = "fa fa-pencil";

                entradaMaterial = new EntradaMaterial();
                entradaMaterialBO = new EntradaMaterialBO();

                entradaMaterial = entradaMaterialBO.BuscarPorID(Convert.ToInt32(hdDetalhesEntradaMaterialID.Value));

                hdEntradaMaterialID.Value = entradaMaterial._EntradaMaterialID.ToString();
                txtDataCadastroEntradaMaterial.Text = entradaMaterial._DataCadastro;
                txtEntradaMaterialObservacao.Text = entradaMaterial._Observacao;

                hdFornecedorID.Value = entradaMaterial._Fornecedor._FornecedorID.ToString();
                txtFornecedorNome.Text = entradaMaterial._Fornecedor._FornecedorNome;

                hdProcessoID.Value = entradaMaterial._Processo._ProcessoID.ToString();
                txtProcessoNumero.Text = entradaMaterial._Processo._ProcessoNumero;
                txtProcessoData.Text = entradaMaterial._Processo._ProcessoData;

                hdUsuarioID.Value = entradaMaterial._Usuario._UsuarioID.ToString();

                //mostar todos os itens
                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();

                listaItemEntradaMaterial = itemEntradaMaterialBO.BuscarItensDaEntradaMaterial(Convert.ToInt32(hdEntradaMaterialID.Value));
                gvItemEntradaMaterial.DataSource = listaItemEntradaMaterial;
                gvItemEntradaMaterial.DataBind();

                LimparFormularioDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbVisualizarGridViewItemEntradaMaterialDetalhesModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialDetalhesModal();", true);
        }

        protected void lkbCancelarDetalhes_Click(object sender, EventArgs e)
        {
            LimparFormularioDetalhes();
        }

        protected void lkbVisualizarEntradaMaterialDetalhesModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEntradaMaterialDetalhesModal();", true);
        }


        #endregion


        #region (Eventos ItemEntradaMaterial)
        protected void lkbAdicionarItemEntradaMaterialModal_Click(object sender, EventArgs e)
        {
            try
            {
                //mostar todos os itens
                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();

                listaItemEntradaMaterial = itemEntradaMaterialBO.BuscarItensDaEntradaMaterial(Convert.ToInt32(txtEntradaMaterialID.Text));
                gvItemEntradaMaterial.DataSource = listaItemEntradaMaterial;
                gvItemEntradaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarAdicionarItemEntradaMaterialModal_Click(object sender, EventArgs e)
        {
            txtEntradaMaterialID.Text = string.Empty;
            hdEntradaMaterialIDRetornado.Value = "0";

            LimparFormulario();
        }

        //Método para atualizar um item da entrada de material
        protected void gvItemEntradaMaterial_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //Buscar um item da entrada de material pelo id
                entradaMaterial = new EntradaMaterial();
                ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();

                int itemEntradaMaterialID = Convert.ToInt32(gvItemEntradaMaterial.DataKeys[e.RowIndex].Value);
                itemEntradaMaterial = itemEntradaMaterialBO.BuscarPorID(itemEntradaMaterialID);


                //Buscar o produto pelo id do produto que veio do item da entrada de material
                Produto produto = new Produto();
                ProdutoBO produtoBO = new ProdutoBO();

                produto = produtoBO.BuscarPorID(itemEntradaMaterial._Produto._ProdutoID);

                hdProdutoID.Value = produto._ProdutoID.ToString();
                txtCodigo.Text = produto._Codigo;
                txtDataCadastroProduto.Text = produto._DataCadastro;
                txtProdutoNome.Text = produto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = produto._ProdutoPrecoUnitario.ToString();
                txtQuantidadeEntrada.Text = produto._QuantidadeEntrada.ToString();
                ddlProdutoTipo.SelectedValue = produto._ProdutoTipo.ToString();

                hdContaID.Value = produto._Conta._ContaID.ToString();
                txtConta.Text = produto._Conta._ContaDescricao;
                txtContaNumero.Text = produto._Conta._ContaNumero;

                hdUnidadeID.Value = produto._Unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = produto._Unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        //Método para excluir um item da entrada de material
        protected void gvItemEntradaMaterial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //exclui um item da entrada de material
                entradaMaterial = new EntradaMaterial();
                ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();

                int itemEntradaMaterialID = Convert.ToInt32(gvItemEntradaMaterial.DataKeys[e.RowIndex].Value);
                itemEntradaMaterial._ItemEntradaMaterialID = Convert.ToInt32(itemEntradaMaterialID);
                itemEntradaMaterialBO.Excluir(itemEntradaMaterial);


                //mostar todos os itens
                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                ItemEntradaMaterialBO itemEntradaMaterialBOBuscar = new ItemEntradaMaterialBO();

                listaItemEntradaMaterial = itemEntradaMaterialBOBuscar.BuscarItensDaEntradaMaterial(Convert.ToInt32(txtEntradaMaterialID.Text));
                gvItemEntradaMaterial.DataSource = listaItemEntradaMaterial;
                gvItemEntradaMaterial.DataBind();


                Mensagem("Produto foi Excluído da Entrada de Material com Sucesso.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbFinalizarAdicionarItemModal_Click(object sender, EventArgs e)
        {
            txtEntradaMaterialID.Text = string.Empty;
            hdEntradaMaterialIDRetornado.Value = "0";

            LimparFormulario();

            Mensagem("Finalizado com Sucesso.", this);
        }

        #endregion



        #region (Eventos do Fornecedor)

        protected void lkbSalvarFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                FornecedorBO fornecedorBO = new FornecedorBO();

                fornecedor._FornecedorID = Convert.ToInt32(hdFornecedorModalID.Value);
                fornecedor._DataCadastro = txtDataCadastroFornecedor.Text;
                fornecedor._FornecedorNome = txtFornecedorNomeModal.Text;

                fornecedorBO.Salvar(fornecedor);

                Mensagem("Fornecedor Salvo com Sucesso.", this);

                LimparFormularioFornecedor();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbcancelarFornecedor_Click(object sender, EventArgs e)
        {
            LimparFormularioFornecedor();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
        }

        protected void lkbVoltarFornecedor_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
        }

        protected void lkbBuscarFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                FornecedorBO fornecedorBO = new FornecedorBO();
                IList<Fornecedor> listaFornecedor = new List<Fornecedor>();

                if (!string.IsNullOrEmpty(txtBuscarFornecedorPorNome.Text))
                {
                    listaFornecedor = fornecedorBO.BuscarPorNome(txtBuscarFornecedorPorNome.Text);
                    if (listaFornecedor != null)
                    {
                        gvFornecedor.DataSource = listaFornecedor;
                        gvFornecedor.DataBind();

                        txtBuscarFornecedorPorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewFornecedorModal();", true);
                    }
                    else
                    {
                        txtBuscarFornecedorPorNome.Text = string.Empty;

                        Mensagem("Nenhum Fornecedor Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
                    }
                }
                else
                {
                    listaFornecedor = fornecedorBO.BuscarTodosFornecedores();
                    if (listaFornecedor != null)
                    {
                        gvFornecedor.DataSource = listaFornecedor;
                        gvFornecedor.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewFornecedorModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Fornecedor Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                FornecedorBO fornecedorBO = new FornecedorBO();

                int id = Convert.ToInt32(gvFornecedor.SelectedDataKey.Value);
                fornecedor = fornecedorBO.BuscarPorID(id);

                hdFornecedorID.Value = fornecedor._FornecedorID.ToString();
                txtFornecedorNome.Text = fornecedor._FornecedorNome;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region (Eventos do Processo)

        protected void lkbSalvarProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                Processo processo = new Processo();
                ProcessoBO processoBO = new ProcessoBO();

                processo._ProcessoID = Convert.ToInt32(hdProcessoModalID.Value);
                processo._DataCadastro = DateTime.Now.ToLongDateString();
                processo._ProcessoData = txtProcessoDataModal.Text;
                processo._ProcessoNumero = txtProcessoNumeroModal.Text;

                processoBO.Salvar(processo);

                Mensagem("Processo Salvo com Sucesso", this);

                LimparFormularioProcesso();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarProcesso_Click(object sender, EventArgs e)
        {
            LimparFormularioProcesso();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
        }

        protected void lkbVoltarProcesso_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
        }

        protected void lkbBuscarProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessoBO processoBO = new ProcessoBO();
                IList<Processo> listaProcesso = new List<Processo>();

                if (!string.IsNullOrEmpty(txtBuscarProcessoPorData.Text))
                {
                    listaProcesso = processoBO.BuscarPorData(txtBuscarProcessoPorData.Text);
                    if (listaProcesso != null)
                    {
                        gvProcesso.DataSource = listaProcesso;
                        gvProcesso.DataBind();

                        txtBuscarProcessoPorData.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProcessoModal();", true);
                    }
                    else
                    {
                        txtBuscarProcessoPorData.Text = string.Empty;

                        Mensagem("Nenhum Processo Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarProcessoPorNumero.Text))
                {
                    listaProcesso = processoBO.BuscarPorNumero(txtBuscarProcessoPorNumero.Text);
                    if (listaProcesso != null)
                    {
                        gvProcesso.DataSource = listaProcesso;
                        gvProcesso.DataBind();

                        txtBuscarProcessoPorNumero.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProcessoModal();", true);
                    }
                    else
                    {
                        txtBuscarProcessoPorNumero.Text = string.Empty;

                        Mensagem("Nenhum Processo Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
                    }
                }
                else
                {
                    listaProcesso = processoBO.BuscarTodosProcessos();
                    if (listaProcesso != null)
                    {
                        gvProcesso.DataSource = listaProcesso;
                        gvProcesso.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProcessoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Processo Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvProcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Processo processo = new Processo();
                ProcessoBO processoBO = new ProcessoBO();

                int id = Convert.ToInt32(gvProcesso.SelectedDataKey.Value);
                processo = processoBO.BuscarPorID(id);

                hdProcessoID.Value = processo._ProcessoID.ToString();
                txtProcessoData.Text = processo._ProcessoData;
                txtProcessoNumero.Text = processo._ProcessoNumero;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion



        #region (Eventos do Produto)

        protected void lkbSalvarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                ValidacaoSalvarProduto();

                Produto produto = new Produto();
                ProdutoBO produtoBO = new ProdutoBO();

                produto._ProdutoID = Convert.ToInt32(hdProdutoID.Value);
                produto._Codigo = txtCodigo.Text;
                produto._DataCadastro = txtDataCadastroProduto.Text;
                produto._ProdutoNome = txtProdutoNome.Text;
                produto._ProdutoPrecoUnitario = Convert.ToDecimal(txtProdutoPrecoUnitario.Text);
                produto._QuantidadeEntrada = Convert.ToInt32(txtQuantidadeEntrada.Text);
                produto._ProdutoValorTotal = Convert.ToDecimal(produto._ProdutoPrecoUnitario * produto._QuantidadeEntrada);
                produto._ProdutoTipo = (ProdutoTipo)Enum.Parse(typeof(ProdutoTipo), ddlProdutoTipo.SelectedValue);

                produto._Conta._ContaID = Convert.ToInt32(hdContaID.Value);
                produto._Unidade._UnidadeID = Convert.ToInt32(hdUnidadeID.Value);

                produtoBO.Salvar(produto);

                if (produto._ProdutoID == 0)
                {
                    Mensagem("Produto Salvo com Sucesso.", this);
                }
                else
                {
                    Mensagem("Produto Atualizado com Sucesso.", this);
                }

                if (produto._ProdutoID == 0) 
                {
                    //Buscar o último produto do registro para adicionar no item
                    Produto produto2 = new Produto();
                    ProdutoBO produtoBO2 = new ProdutoBO();
                    produto2 = produtoBO2.BuscarPorUltimoProdutoCadastrado();

                    //adicionar os produtos no item da entrada de material
                    entradaMaterial = new EntradaMaterial();
                    ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                    ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();

                    int produtoID = Convert.ToInt32(produto2._ProdutoID);
                    itemEntradaMaterial._Produto._ProdutoID = produtoID;
                    itemEntradaMaterial._EntradaMaterial._EntradaMaterialID = Convert.ToInt32(txtEntradaMaterialID.Text);

                    itemEntradaMaterialBO.Salvar(itemEntradaMaterial);

                }

                if (produto._ProdutoID == 0)
                {
                    //Método para atualizar a quantidade em estoque do produto, buscando pelo código
                    Produto produto3 = new Produto();
                    ProdutoBO produtoBO3 = new ProdutoBO();
                    produto3 = produtoBO3.BuscarPorUltimoProdutoCadastrado();

                    int quantidadeEntrada = produto3._QuantidadeEntrada;
                    string produtoNome = produto3._ProdutoNome;
                    decimal produtoValorTotal = produto3._ProdutoValorTotal;
                    
                    ProdutoBO produtoBO4 = new ProdutoBO();
                    produtoBO4.AtualizarQtdeEstoquePorCodigoProdutoEntrada(quantidadeEntrada, produtoNome, produtoValorTotal); 
                }
                                             

                //mostar todos os itens da entrada de material
                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                ItemEntradaMaterialBO itemEntradaMaterialBOBuscar = new ItemEntradaMaterialBO();

                listaItemEntradaMaterial = itemEntradaMaterialBOBuscar.BuscarItensDaEntradaMaterial(Convert.ToInt32(txtEntradaMaterialID.Text));
                gvItemEntradaMaterial.DataSource = listaItemEntradaMaterial;
                gvItemEntradaMaterial.DataBind();
                                             

                LimparFormularioProduto();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarProduto_Click(object sender, EventArgs e)
        {
            LimparFormularioProduto();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
        }

        protected void lkbBuscarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoBO produtoBO = new ProdutoBO();
                IList<Produto> listaProduto = new List<Produto>();

                if (!string.IsNullOrEmpty(txtBuscarProdutoPorCodigo.Text))
                {
                    listaProduto = produtoBO.BuscarPorCodigo(txtBuscarProdutoPorCodigo.Text);
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        txtBuscarProdutoPorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarProdutoPorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarProdutoPorNome.Text))
                {
                    listaProduto = produtoBO.BuscarPorNome(txtBuscarProdutoPorNome.Text);
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        txtBuscarProdutoPorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarProdutoPorNome.Text = string.Empty;

                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
                    }
                }
                else
                {
                    listaProduto = produtoBO.BuscarTodosProdutos();
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
                    }
                }
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
                //adicionar os produtos no item
                entradaMaterial = new EntradaMaterial();
                ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();

                int produtoID = Convert.ToInt32(gvProduto.SelectedDataKey.Value);

                itemEntradaMaterial._Produto._ProdutoID = produtoID;
                itemEntradaMaterial._EntradaMaterial._EntradaMaterialID = Convert.ToInt32(txtEntradaMaterialID.Text);

                itemEntradaMaterialBO.Salvar(itemEntradaMaterial);


                //mostar todos os itens
                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                ItemEntradaMaterialBO itemEntradaMaterialBOBuscar = new ItemEntradaMaterialBO();

                listaItemEntradaMaterial = itemEntradaMaterialBOBuscar.BuscarItensDaEntradaMaterial(Convert.ToInt32(txtEntradaMaterialID.Text));
                gvItemEntradaMaterial.DataSource = listaItemEntradaMaterial;
                gvItemEntradaMaterial.DataBind();

                Mensagem("Produto Adicionado com Sucesso.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCalcularQuantidadeFornecida_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantidadeFornecidaAcrescimo.Text != null)
                {
                    decimal quantidadeEntrada = Convert.ToDecimal(txtQuantidadeEntrada.Text);
                    decimal quantidadeEntradaAcrescimo = Convert.ToDecimal(txtQuantidadeFornecidaAcrescimo.Text);
                    decimal quantidadeEntradaTotal = quantidadeEntrada + quantidadeEntradaAcrescimo;

                    txtQuantidadeEntrada.Text = quantidadeEntradaTotal.ToString();

                    txtQuantidadeFornecidaAcrescimo.Text = string.Empty;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                }
                else
                {
                    Mensagem("Digite a quantidade de produtos da entrada", this);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }

        }

        protected void lkbVisualizarGridViewItemEntradaMaterialModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemEntradaMaterialModal();", true);
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

        protected void lkbVoltarNomeProduto_Click(object sender, EventArgs e)
        {
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

        #endregion

    }
}