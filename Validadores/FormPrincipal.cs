using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Validadores {

  public partial class FormPrincipal : Form {

    private const String CPF = "CPF";

    private const String CNPJ = "CNPJ";

    private const String IE = "IE";

    private Validadores validadores { get; }

    public FormPrincipal() {
      InitializeComponent();
      validadores = new Validadores();
      lblResultado.Text = "";

      for (int i = 0; i < validadores.Estados.Length; i++) {
        cbUf.Items.Insert(i, validadores.Estados[i]);
      }
    }

    private void ExibeValidacao(TextBox control, ResultadoValidacao validacao, String documento) {
      lblResultado.BackColor = validacao.EhDocumentoValido ? Color.LightGreen : Color.Red;
      lblResultado.Text = documento;
      lblResultado.Text += validacao.EhDocumentoValido ? @" Válido(a)" : @" Inválido(a)";
      control.Text = validacao.Documento; 
    }

    private void btnValidaCpf_Click(object sender, EventArgs e) {
      if (String.IsNullOrEmpty(tbCpf.Text)) {
        MessageBox.Show(@"Informe um valor no campo 'CPF' para validar.");
        return;
      }
      ExibeValidacao(tbCpf, validadores.ValidaCpf(tbCpf.Text), CPF);
    }

    private void btnValidarCnpj_Click(object sender, EventArgs e) {
      if (String.IsNullOrEmpty(tbCnpj.Text)) {
        MessageBox.Show(@"Informe um valor no campo 'CNPJ' para validar.");
        return;
      }
      ExibeValidacao(tbCnpj, validadores.ValidaCnpj(tbCnpj.Text), CNPJ);
    }

    private void btnValidarIe_Click(object sender, EventArgs e) {
      if (String.IsNullOrEmpty(tbIe.Text)) {
        MessageBox.Show(@"Informe um valor no campo 'IE' para validar.");
        return;
      }
      switch (cbUf.SelectedIndex) {
        case 0:
          ExibeValidacao(tbIe, validadores.ValidaIeParana(tbIe.Text), IE);
          break;
        case 1:
          ExibeValidacao(tbIe, validadores.ValidaIeAcre(tbIe.Text), IE);
          break;
        case 2:
          ExibeValidacao(tbIe, validadores.ValidaIeTocantins(tbIe.Text), IE);
          break;
        case 3:
          ExibeValidacao(tbIe, validadores.ValidaIePernambuco(tbIe.Text), IE);
          break;
        default:
          MessageBox.Show(@"Selecione a UF da IE!");
          return;
      }
    }
  }

}