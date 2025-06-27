using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Validadores {

  public partial class FormPrincipal : Form {

    private const String CPF = "cpf";

    private const String CNPJ = "cnpj";

    private const String IE = "ie";

    private readonly String[] estados = new[] { "PR", "AC", "TO", "PE" };

    private ValidadoresCpfCnpj validadoresCpfCnpj { get; }

    private ValidadoresIe validadoresIe { get; }

    public FormPrincipal() {
      InitializeComponent();
      validadoresCpfCnpj = new ValidadoresCpfCnpj();
      validadoresIe = new ValidadoresIe();
      lblResultado.Text = "";

      for (int i = 0; i < estados.Length; i++) {
        cbUf.Items.Insert(i, estados[i]);
      }
    }

    private void ExibeValidacao(TextBox control, RetornoValidacoes validacao, String documento) {
      lblResultado.BackColor = validacao.EhValido ? Color.LightGreen : Color.Red;
      lblResultado.Text = documento;
      lblResultado.Text += validacao.EhValido ? @" Válido(a)" : @" Inválido(a)";
      control.Text = validacao.DocumentoFormatado; 
    }

    private void btnValidaCpf_Click(object sender, EventArgs e) {
      if (String.IsNullOrEmpty(tbCpf.Text)) {
        MessageBox.Show(@"Informe um valor no campo 'CPF' para validar.");
        return;
      }
      ExibeValidacao(tbCpf, validadoresCpfCnpj.ValidaCpf(tbCpf.Text), CPF);
    }

    private void btnValidarCnpj_Click(object sender, EventArgs e) {
      if (String.IsNullOrEmpty(tbCnpj.Text)) {
        MessageBox.Show(@"Informe um valor no campo 'CNPJ' para validar.");
        return;
      }
      ExibeValidacao(tbCnpj, validadoresCpfCnpj.ValidaCnpj(tbCnpj.Text), CNPJ);
    }

    private void btnValidarIe_Click(object sender, EventArgs e) {
      if (String.IsNullOrEmpty(tbIe.Text)) {
        MessageBox.Show(@"Informe um valor no campo 'IE' para validar.");
        return;
      }
      switch (cbUf.SelectedIndex) {
        case 0:
          ExibeValidacao(tbIe, validadoresIe.IeParana(tbIe.Text), IE);
          break;
        case 1:
          ExibeValidacao(tbIe, validadoresIe.IeAcre(tbIe.Text), IE);
          break;
        case 2:
          ExibeValidacao(tbIe, validadoresIe.IeTocantins(tbIe.Text), IE);
          break;
        case 3:
          ExibeValidacao(tbIe, validadoresIe.ValidacaoPE(tbIe.Text), IE);
          break;
        default:
          MessageBox.Show(@"Selecione a UF da IE!");
          return;
      }
    }
  }

}