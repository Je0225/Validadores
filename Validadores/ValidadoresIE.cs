using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidadoresIe : ValidadoresDocumentos{

    public RetornoValidacoes IeParana(String ieInformada) {
      string ie = RetornaSoNumeros(ieInformada);
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 10)
      };
      if (validacao.EhValido) {
        Int32 digito1 = CalculaDv(ie, 3, true, true, 2, 7);
        Int32 digito2 = CalculaDv(ie, 4, false, true, 2, 7);
        validacao.EhValido = ie[8].ToString() == digito1.ToString() && ie[9].ToString() == digito2.ToString();
        validacao.DocumentoFormatado = ie.Insert(3, ".").Insert(9, "-");
      }
      return validacao;
    }

    public RetornoValidacoes IeAcre(String ieInformada) {
      string ie = RetornaSoNumeros(ieInformada);
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 13) && (ie[0].ToString() == "0" || ie[1].ToString() == "1")
      };
      if (validacao.EhValido) {
        Int32 digito1 = CalculaDv(ie, 4, true, true, 2, 9);
        Int32 digito2 = CalculaDv(ie, 5, false, true, 2, 9);
        validacao.EhValido = digito2.ToString() == ie[12].ToString() && digito1.ToString() == ie[11].ToString();
        validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(14, "-");
      }
      return validacao;
    }

    public RetornoValidacoes IeTocantins(String ieInformada) {
      string ie = RetornaSoNumeros(ieInformada);
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 9)
      };
      if (validacao.EhValido) {
        Int32 digito = CalculaDv(ie, 9, false, false);
        validacao.EhValido = digito.ToString() == ie[8].ToString();
        validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(9, "-");
      }
      return validacao;
    }

    public RetornoValidacoes ValidacaoPE(String ieInformada) {
      String ie = RetornaSoNumeros(ieInformada);
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
      Int32 digito1 = CalculaDv(ie, 8, true, false);
      Int32 digito2 = CalculaDv(ie, 9, false, false);
      validacao.EhValido = digito1.ToString() == ie[7].ToString() && digito2.ToString() == ie[8].ToString();
      validacao.DocumentoFormatado = ie.Insert(8, "-");
    }

    private void ValidacaoAntigaPe(String ie, RetornoValidacoes validacao) {
      Int32 digito = CalculaDv(ie, 5, false, true, 1 , 9);
      validacao.EhValido = digito.ToString() == ie[13].ToString();
      validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(4, ".").Insert(8, ".").Insert(16, "-");
    }

    private Int32 CalculaDv(String documento, Int32 x, Boolean ehDv1, Boolean valorXTemCondicao, Int32 condicaoX = 0, Int32 condicaoXverdadeira = 0) {
      Int32 soma = 0;
      Int32 indexDv = ehDv1 ? 2 : 1;
      for (Int32 i = 0; i < documento.Length - indexDv; i++) {
        soma += Convert.ToInt32(documento[i].ToString()) * x;
        x = valorXTemCondicao ?
          (x == condicaoX ? condicaoXverdadeira : x - 1) : (x - 1);
      }
      Int32 resto = 11 - (soma % 11);
      return resto == 10 || resto == 11 ? 0 : resto;
    }

  }
}
