using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Validadores {
  internal class ValidadoresCpfCnpj : ValidadoresDocumentos {

    public RetornoValidacoes ValidaCpf(String cpfInformado) {
      String cpf = Regex.Replace(cpfInformado, @"[^\d]", "");
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(cpf, 11)
      };

      int soma = 0;
      int x = 10;
      for (int i = 0; i < cpf.Length - 2; i++) {
        soma += Convert.ToInt32(cpf[i].ToString()) * x;
        x--;
      }
      int digito1 = (soma * 10) % 11;
      digito1 = digito1 == 10 ? 0 : digito1;

      soma = 0;
      x = 11;
      for (int i = 0; i < cpf.Length - 1; i++) {
        soma += Convert.ToInt32(cpf[i].ToString()) * x;
        x--;
      }
      int digito2 = (soma * 10) % 11;
      digito2 = digito2 == 10 ? 0 : digito2;
      
      validacao.EhValido = cpf[9].ToString() == digito1.ToString() && cpf[10].ToString() == digito2.ToString();
      validacao.DocumentoFormatado = cpfInformado.Insert(3, ".").Insert(7, ".").Insert(11, "-");

      return validacao;
    }

    public RetornoValidacoes ValidaCnpj(String cnpjInformado) {
      string cnpj = Regex.Replace(cnpjInformado, @"[^\d]", "");
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(cnpj, 14)
      };

      int soma = 0;
      int x = 5;
      for (int i = 0; i < cnpj.Length - 2; i++) {
        soma += Convert.ToInt32(cnpj[i].ToString()) * x;
        x = x == 2 ? 9 : x - 1;
      }
      int digito1 = soma % 11;
      digito1 = digito1 < 2 ? 0 : digito1;
      digito1 = 11 - digito1;

      soma = 0;
      x = 6;
      for (int i = 0; i < cnpj.Length - 1; i++) {
        soma += Convert.ToInt32(cnpj[i].ToString()) * x;
        x = x == 2 ? 9 : x - 1;
      }

      int digito2 = soma % 11;
      digito2 = digito2 < 2 ? 0 : digito2;
      digito2 = 11 - digito2;

      validacao.EhValido = cnpj[12].ToString() == digito1.ToString() && cnpj[13].ToString() == digito2.ToString();
      validacao.DocumentoFormatado = cnpjInformado.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");

      return validacao;
    }

  }
}
