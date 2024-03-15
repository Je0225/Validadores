using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Validadores {

    public partial class FormPrincipal: Form {

        public FormPrincipal() {
            InitializeComponent();
            lblResultado.Text = "";
            cbUf.Items.Insert(0, "PR");
            cbUf.Items.Insert(1, "AC");
            cbUf.Items.Insert(2, "TO");
            cbUf.Items.Insert(3, "PE");
        }

        public void Validado() {
            lblResultado.BackColor = Color.LightGreen;
            lblResultado.Text = "Validado";
        }

        public void Invalido() {
            lblResultado.BackColor = Color.Red;
            lblResultado.Text = "Inválido";
        }

        private void btnValidaCpf_Click(object sender, EventArgs e) {
            string textoCpf = Regex.Replace(tbCpf.Text, @"[^\d]", "");

            if (textoCpf.Distinct().Count() == 1) {
                Invalido();
                return;
            }

            if (textoCpf.Length != 11) {
                Invalido();
                return;
            }

            int soma = 0;
            int x = 10;
            for (int i = 0; i < textoCpf.Length - 2; i++) {
                soma = soma + Convert.ToInt32(textoCpf[i].ToString()) * x;
                x--;
            }
            int digito1 = (soma * 10) % 11;
            if (digito1 == 10) {
                digito1 = 0;
            }

            soma = 0;
            x = 11;
            for (int i = 0; i < textoCpf.Length - 1; i++) {
                soma = soma + Convert.ToInt32(textoCpf[i].ToString()) * x;
                x--;
            }
            int digito2 = (soma * 10) % 11;
            if (digito2 == 10) {
                digito2 = 0;
            }

            if (textoCpf[9].ToString() == digito1.ToString() && textoCpf[10].ToString() == digito2.ToString()) {
                Validado();
                tbCpf.Text = textoCpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                //tbCpf.Text = textoCpf.Substring(0,3) + "." + textoCpf.Substring(3,3) + "." + textoCpf.Substring(6,3) + "-" + textoCpf.Substring(9, 2);
            } else {
                Invalido();
            }
        }

        private void btnValidarCnpj_Click(object sender, EventArgs e) {
            string textoCnpj = Regex.Replace(tbCnpj.Text, @"[^\d]", "");

            if (textoCnpj.Length != 14) {
                Invalido();
                return;
            }

            int soma = 0;
            int x = 5;
            for (int i = 0; i < textoCnpj.Length - 2; i++) {
                soma = soma + Convert.ToInt32(textoCnpj[i].ToString()) * x;
                if (x == 2) {
                    x = 9;
                } else {
                    x--;
                }
            }
            int digito1 = soma % 11;
            if (digito1 < 2) {
                digito1 = 0;
            }
            digito1 = 11 - digito1;

            soma = 0;
            x = 6;
            for (int i = 0; i < textoCnpj.Length - 1; i++) {
                soma = soma + Convert.ToInt32(textoCnpj[i].ToString()) * x;
                if (x == 2) {
                    x = 9;
                } else {
                    x--;
                }
            }
            int digito2 = soma % 11;
            if (digito2 < 2) {
                digito2 = 0;
            }
            digito2 = 11 - digito2;

            if (textoCnpj[12].ToString() == digito1.ToString() && textoCnpj[13].ToString() == digito2.ToString()) {
                tbCnpj.Text = textoCnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                Validado();
            } else {
                Invalido();
            }
        }

        private void btnValidarIe_Click(object sender, EventArgs e) {
            string ie = Regex.Replace(tbIe.Text, @"[^\d]", "");
            switch (cbUf.SelectedIndex) {
                case 0:
                    IeParana();
                    break;
                case 1:
                    IeAcre();
                    break;
                case 2:
                    IeTocantins();
                    
                    break;
                case 3:
                    EscolhaValidacaoPE();
                    break;
                default:
                    MessageBox.Show("Selecione a UF da IE!");
                    return;
            }
        }

        private void IeParana() {
           string ie = Regex.Replace(tbIe.Text, @"[^\d]", "");

            if (ie.Length != 10) {
                Invalido();
            }

            int soma = 0;
            int x = 3;
            for (int i = 0; i < ie.Length - 2; i++) {
                soma = soma + Convert.ToInt32(ie[i].ToString()) * x;
                if (x == 2) {
                    x = 7;
                } else {
                    x--;
                }
            }
            int digito1 = 11 - (soma % 11);
            if (digito1 == 10 || digito1 == 11) {
                digito1 = 0;
            }

            soma = 0;
            x = 4;
            for (int i = 0; i < ie.Length - 1; i++) {
                soma = soma + Convert.ToInt32(ie[i].ToString()) * x;
                if (x == 2) {
                    x = 7;
                } else {
                    x--;
                }
            }
            int digito2 = 11 - (soma % 11);
            if (digito2 == 10 || digito2 == 11) {
                digito2 = 0;
            }

            if (ie[8].ToString() == digito1.ToString() && ie[9].ToString() == digito2.ToString()) {
               tbIe.Text = ie.Insert(3, ".").Insert(9, "-");
                Validado();
            } else {
                Invalido();
            }
        }

        private void IeAcre() {
            string ie = Regex.Replace(tbIe.Text, @"[^\d]", "");

            if (ie.Length != 13 || ie[0].ToString() != "0" || ie[1].ToString() != "1") {
                Invalido();
                return;
            }

            int soma = 0;
            int x = 4;
            for (int i = 0; i < ie.Length - 2; i++) {
                soma = soma + Convert.ToInt32(ie[i].ToString()) * x;
                if (x == 2) {
                    x = 9;
                } else {
                    x--;
                }
            }
            int digito1 = 11 - (soma % 11);
            if (digito1 == 11 || digito1 == 10) {
                digito1 = 0;
            }

            soma = 0;
            x = 5;
            for (int i = 0; i < ie.Length - 1; i++) {
                soma += Convert.ToInt32(ie[i].ToString()) * x;
                if (x == 2) {
                    x = 9;
                } else {
                    x--;
                }
            }
            int digito2 = 11 - (soma % 11);
            if (digito2 == 11 || digito2 == 10) {
                digito2 = 0;
            }

            if (digito2.ToString() == ie[12].ToString() && digito1.ToString() == ie[11].ToString()) {
                tbIe.Text = ie.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(14, "-");
                Validado();
            } else {
                Invalido();
            }
        }

        private void IeTocantins() {
            string ie = Regex.Replace(tbIe.Text, @"[^\d]", "");

            if (ie.Length != 9) {
                Invalido();
                return;
            }

            int soma = 0;
            int x = 9;
            for (int i = 0; i < ie.Length - 1; i++) {
                soma += Convert.ToInt32(ie[i].ToString()) * x;
                x--;
            }
            int digito = 11 - (soma % 11);
            if (digito == 11 || digito == 10) {
                digito = 0;
            }

            if (digito.ToString() == ie[8].ToString()) {
                tbIe.Text = ie.Insert(2, ".").Insert(9 , "-");
                Validado();
            } else {
                Invalido();
            }
        }

        public void EscolhaValidacaoPE() {
            string ie = Regex.Replace(tbIe.Text, @"[^\d]", "");
            if (ie.Length == 9) {
                ValidacaoAtualPE(ie);
            }
            else if (ie.Length == 14) {
                ValidacaoAntigaPE(ie);
            } else {
                Invalido();
            }
        }

        private void ValidacaoAtualPE(string ie) {
            int soma = 0;
            int x = 8;
            for (int i = 0; i < ie.Length - 2; i++) {
                soma += Convert.ToInt32(ie[i].ToString()) * x;
                x--;
            }
            int digito1 = 11 - (soma % 11);
            if (digito1 == 10 || digito1 == 11) {
                digito1 = 0;
            }

            soma = 0;
            x = 9;
            for (int i = 0; i < ie.Length - 1; i++) {
                soma += Convert.ToInt32(ie[i].ToString()) * x;
                x--;
            }
            int digito2 = 11 - (soma % 11);
            if (digito2 == 10 || digito2 == 11) {
                digito2 = 0;
            }

            if (digito1.ToString() == ie[7].ToString() && digito2.ToString() == ie[8].ToString()) {
                tbIe.Text = ie.Insert(8, "-");
                Validado();
            } else {
                Invalido();
            }
        }

        private void ValidacaoAntigaPE(String ie) {
            int soma = 0 ;
            int x = 5;
            for (int i = 0; i < ie.Length - 1; i++) {
                soma += Convert.ToInt32(ie[i].ToString()) * x;
                if (x == 1) {
                    x = 9;
                } else {
                    x--;
                }
            }
            int digito1 = 11 - (soma % 11);
            if (digito1 == 10 || digito1 == 11)
            {
                digito1 = 0; 
            }
            if (digito1.ToString() == ie[13].ToString()) {
                tbIe.Text = ie.Insert(2, ".").Insert(4, ".").Insert(8, ".").Insert(16, "-");
                Validado();
            } else {
                Invalido();
            }
        }

    }

}