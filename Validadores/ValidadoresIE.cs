using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidadoresIe : ValidadoresDocumentos{

    public RetornoValidacoes IeParana(String ieInformada) {
      string ie = Regex.Replace(ieInformada, @"[^\d]", "");
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 10)
      };

      int soma = 0;
      int x = 3;
      for (int i = 0; i < ie.Length - 2; i++) {
        soma += Convert.ToInt32(ie[i].ToString()) * x;
        x = x == 2 ? 7 : x - 1;
      }
      int digito1 = 11 - (soma % 11);
      digito1 = digito1 == 10 || digito1 == 11 ? 0 : digito1;
      
      soma = 0;
      x = 4;
      for (int i = 0; i < ie.Length - 1; i++) {
        soma += Convert.ToInt32(ie[i].ToString()) * x;
        x = x == 2 ? 7 : x - 1;
      }
      int digito2 = 11 - (soma % 11);
      digito2 = digito2 == 10 || digito2 == 11 ? 0 : digito2;
      
      validacao.EhValido = ie[8].ToString() == digito1.ToString() && ie[9].ToString() == digito2.ToString();
      validacao.DocumentoFormatado = ie.Insert(3, ".").Insert(9, "-");

      return validacao;
    }

    public RetornoValidacoes IeAcre(String IeInformada) {
      string ie = Regex.Replace(IeInformada, @"[^\d]", "");
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 13) && (ie[0].ToString() == "0" || ie[1].ToString() == "1")
      };

      int soma = 0;
      int x = 4;
      for (int i = 0; i < ie.Length - 2; i++) {
        soma += Convert.ToInt32(ie[i].ToString()) * x;
        x = x == 2 ? 9 : x - 1;
      }
      int digito1 = 11 - (soma % 11);
      digito1 = digito1 == 11 || digito1 == 10 ? 0 : digito1;
      
      soma = 0;
      x = 5;
      for (int i = 0; i < ie.Length - 1; i++) {
        soma += Convert.ToInt32(ie[i].ToString()) * x;
        x = x == 2 ? 9 : x - 1;
      }
      int digito2 = 11 - (soma % 11);
      digito2 = digito2 == 11 || digito2 == 10 ? 0 : digito2;
      
      validacao.EhValido = digito2.ToString() == ie[12].ToString() && digito1.ToString() == ie[11].ToString();
      validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(14, "-");

      return validacao;
    }

    public RetornoValidacoes IeTocantins(String ieInformada) {
      string ie = Regex.Replace(ieInformada, @"[^\d]", "");
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 9)
      };
      int soma = 0;
      int x = 9;
      for (int i = 0; i < ie.Length - 1; i++) {
        soma += Convert.ToInt32(ie[i].ToString()) * x;
        x--;
      }
      int digito = 11 - (soma % 11);
      digito = digito == 11 || digito == 10 ? 0 : digito;
      
      validacao.EhValido = digito.ToString() == ie[8].ToString();
      validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(9, "-");
      
      return validacao;
    }

    public RetornoValidacoes ValidacaoPE(String ieInformada) {
      String ie = Regex.Replace(ieInformada, @"[^\d]", "");
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 9) || QuantiaDigitosValida(ie, 14)
      };
      if (ie.Length == 9) {
        ValidacaoAtualPe(ie, validacao);
      } else if (ie.Length == 14) {
        ValidacaoAntigaPe(ie, validacao);
      }
      return validacao;
    }

    private void ValidacaoAtualPe(string ie, RetornoValidacoes validacao) {
      int soma = 0;
      int x = 8;
      for (int i = 0; i < ie.Length - 2; i++) {
        soma += Convert.ToInt32(ie[i].ToString()) * x;
        x--;
      }
      int digito1 = 11 - (soma % 11);
      digito1 = digito1 == 10 || digito1 == 11 ? 0 : digito1;
      
      soma = 0;
      x = 9;
      for (int i = 0; i < ie.Length - 1; i++) {
        soma += Convert.ToInt32(ie[i].ToString()) * x;
        x--;
      }
      int digito2 = 11 - (soma % 11);
      digito2 = digito2 == 10 || digito2 == 11 ? 0 : digito2;
      
      validacao.EhValido = digito1.ToString() == ie[7].ToString() && digito2.ToString() == ie[8].ToString();
      validacao.DocumentoFormatado = ie.Insert(8, "-");
    }

    private void ValidacaoAntigaPe(String ie, RetornoValidacoes validacao) {
      int soma = 0;
      int x = 5;
      for (int i = 0; i < ie.Length - 1; i++) {
        soma += Convert.ToInt32(ie[i].ToString()) * x;
        x = x == 1 ? 9 : x - 1;
      }
      int digito1 = 11 - (soma % 11);
      digito1 = digito1 == 10 || digito1 == 11 ? 0 : digito1;
      
      validacao.EhValido = digito1.ToString() == ie[13].ToString();
      validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(4, ".").Insert(8, ".").Insert(16, "-");
    }
  }
}
