<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageExterna.Master" AutoEventWireup="true" CodeBehind="pgLogin.aspx.cs" Inherits="CamadaApresentacao.pgLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoExterno" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />

    <!--Área de Logar no Sistema------------------------------------------------------------------------------------------------------------------------>

    <!--Panel com o login e a senha-->
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h2 class="panel-title text-center">Autenticação de Usuário</h2>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-9 col-md-offset-1">
                            <div class="input-group">
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lkbLoginImagem" runat="server" CssClass="btn btn-default btn-sm"><i class="fa fa-user"></i></asp:LinkButton>
                                </span>
                                <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control input-sm" data-mask="999.999.999-99" placeholder="Digite seu Cpf."></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-9 col-md-offset-1">
                            <div class="input-group">
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lkbSenhaImagem" runat="server" CssClass="btn btn-default btn-sm"><i class="fa fa-lock"></i></asp:LinkButton>
                                </span>
                                <asp:TextBox ID="txtSenha" runat="server" class="form-control input-sm" placeholder="Digite sua senha." AutoPostBack="true" OnTextChanged="txtSenha_TextChanged" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-9  col-md-offset-1">
                            <asp:LinkButton ID="lkbEntrar" runat="server" class="btn btn-success btn-sm" ToolTip="Clique para Entrar" OnClick="lkbEntrar_Click"><i class="fa fa-share"> Acesso</i></asp:LinkButton>
                            <asp:LinkButton ID="lkbCancelar" runat="server" class="btn btn-default btn-sm" ToolTip="Clique para Cancelar" OnClick="lkbCancelar_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!--Área para Alterar a senha do Usuário---------------------------------------------------------------------------------------------------------------------------------------------------------------->

    <!--Script para abrir o modal para Alterar a senha do Usuário-->
    <script type="text/javascript">
        function openAlterarSenhaModal() {
            $('#AlterarSenhaModal').modal('show');
        }
    </script>

    <!-- Modal para Alterar a senha do Usuário -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="AlterarSenhaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 400px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center"><i class="">Alteração de senha</i></h3>
                            <h3 class="panel-title text-center"><i class="">Primeiro Acesso</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-9 col-md-offset-1">
                                    <div class="input-group">
                                        <span class="input-group-btn">

                                            <!--campo que guarda no id do usuário para Alterar a senha-->
                                            <asp:HiddenField ID="hdUsuarioAlterarSenhaID" Value="0" runat="server" />

                                            <asp:LinkButton ID="lkbNovaSenhaImagem" runat="server" CssClass="btn btn-default btn-sm"><i class="fa fa-lock"></i></asp:LinkButton>
                                        </span>
                                        <asp:TextBox ID="txtNovaSenha" type="password" runat="server" class="form-control input-sm" placeholder="Digite a nova senha."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-9 col-md-offset-1">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbConfirmarSenhaImagem" runat="server" CssClass="btn btn-default btn-sm"><i class="fa fa-lock"></i></asp:LinkButton>
                                        </span>
                                        <asp:TextBox ID="txtConfirmarSenha" type="password" runat="server" class="form-control input-sm" placeholder="Repita a nova senha."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-9 col-md-offset-1">
                                    <asp:LinkButton ID="lkbAlterarSenha" runat="server" class="btn btn-success btn-sm" ToolTip="Clique para Alterar a senha" OnClick="lkbAlterarSenha_Click"><i class="fa fa-check"> Alterar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelarAlterarSenha" runat="server" class="btn btn-default btn-sm" ToolTip="clique para Cancelar" OnClick="lkbCancelarAlterarSenha_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>
