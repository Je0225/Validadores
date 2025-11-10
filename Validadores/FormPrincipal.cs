using System;
using System.Drawing;
using System.Windows.Forms;
using Validadores.Validadores.Contratos;

namespace Validadores {

  public partial class FormPrincipal : Form {

    public FormPrincipal() {
      InitializeComponent();
      lblResultado.Text = "";
      cbUf.Items.AddRange(ValidadorRegistry.estados);
    }

    private void ValidaEntradaDocumento(TextBox tb, IValidadorDocumento validador) {
      if (String.IsNullOrEmpty(tb.Text)) {
        MessageBox.Show($@"Informe um valor no campo {validador} para validar.");
        return;
      }
      if (tb == tbIe && cbUf.SelectedIndex == -1) {
        MessageBox.Show(@"Selecione a UF da IE!");
        return;
      }
      ExibeValidacao(tb, validador.ValidaDocumento(tb.Text));
    }

    private void ExibeValidacao(TextBox control, ResultadoValidacao validacao) {
      lblResultado.BackColor = validacao.EhDocumentoValido ? Color.LightGreen : Color.Red;
      lblResultado.Text = control.Tag.ToString();
      lblResultado.Text += validacao.EhDocumentoValido ? @" Válido(a)" : @" Inválido(a)";
      control.Text = validacao.Documento;
    }

    private void btnValidaCpf_Click(object sender, EventArgs e) {
      IValidadorDocumento validador = ValidadorRegistry.documentos[(String)tbCpf.Tag];
      ValidaEntradaDocumento(tbCpf, validador);
    }

    private void btnValidarCnpj_Click(object sender, EventArgs e) {
      IValidadorDocumento validador = ValidadorRegistry.documentos[(String)tbCnpj.Tag];
      ValidaEntradaDocumento(tbCnpj, validador);
    }

    private void btnValidarIe_Click(object sender, EventArgs e) {
      ValidaEntradaDocumento(tbIe, (IValidadorDocumento)cbUf.SelectedItem);
    }

  }

}