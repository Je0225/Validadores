using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidadoresIe : ValidadoresDocumentos{

    public ResultadoValidacoes IeParana(String ieInformada) {
      string ie = RetornaSoNumeros(ieInformada);
      ResultadoValidacoes validacao = new ResultadoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 10)
      };
      if (validacao.EhValido) {
        Int32 digito1 = CalculaDv(ie, new Int32[]{3,2, 7, 6, 5, 4, 3, 2}, true);
        Int32 digito2 = CalculaDv(ie, new Int32[]{ 4, 3, 2, 7, 6, 5, 4, 3, 2}, false);
        validacao.EhValido = ie[8].ToString() == digito1.ToString() && ie[9].ToString() == digito2.ToString();
        validacao.DocumentoFormatado = ie.Insert(3, ".").Insert(9, "-");
      }
      return validacao;
    }

    public ResultadoValidacoes IeAcre(String ieInformada) {
      string ie = RetornaSoNumeros(ieInformada);
      ResultadoValidacoes validacao = new ResultadoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 13) && (ie[0].ToString() == "0" || ie[1].ToString() == "1")
      };
      if (validacao.EhValido) {
        Int32 digito1 = CalculaDv(ie, new Int32[]{ 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }, true);
        Int32 digito2 = CalculaDv(ie, new Int32[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}, false);
        validacao.EhValido = digito2.ToString() == ie[12].ToString() && digito1.ToString() == ie[11].ToString();
        validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(14, "-");
      }
      return validacao;
    }

    public ResultadoValidacoes IeTocantins(String ieInformada) {
      string ie = RetornaSoNumeros(ieInformada);
      ResultadoValidacoes validacao = new ResultadoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 9) || QuantiaDigitosValida(ie, 11)
      };
      if (ie.Length == 11) {
        ie = ie.Remove(2, 2);
      }
      if (validacao.EhValido) {
        Int32 digito = CalculaDv(ie, new Int32[]{ 9, 8, 7, 6, 5, 4, 3, 2}, false);
        validacao.EhValido = digito.ToString() == ie[8].ToString();
        validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(9, "-");
      }
      // retornar com todos os digitos
      return validacao;
    }

    public ResultadoValidacoes ValidacaoPE(String ieInformada) {
      String ie = RetornaSoNumeros(ieInformada);
      ResultadoValidacoes validacao = new ResultadoValidacoes {
        EhValido = QuantiaDigitosValida(ie, 9) || QuantiaDigitosValida(ie, 14)
      };
      if (ie.Length == 9) {
        ValidacaoAtualPe(ie, validacao);
      } else if (ie.Length == 14) {
        ValidacaoAntigaPe(ie, validacao);
      }
      return validacao;
    }

    private void ValidacaoAtualPe(string ie, ResultadoValidacoes validacao) {
      Int32 digito1 = CalculaDv(ie, new Int32[]{ 8, 7, 6, 5, 4, 3, 2 }, true);
      Int32 digito2 = CalculaDv(ie, new Int32[] { 9, 8, 7, 6, 5, 4, 3, 2 }, false);
      validacao.EhValido = digito1.ToString() == ie[7].ToString() && digito2.ToString() == ie[8].ToString();
      validacao.DocumentoFormatado = ie.Insert(8, "-");
    }

    private void ValidacaoAntigaPe(String ie, ResultadoValidacoes validacao) {
      Int32 digito = CalculaDv(ie, new Int32[] { 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2 }, false);
      validacao.EhValido = digito.ToString() == ie[13].ToString();
      validacao.DocumentoFormatado = ie.Insert(2, ".").Insert(4, ".").Insert(8, ".").Insert(16, "-");
    }

    private Int32 CalculaDv(String documento, Int32[] pesos, Boolean ehDv1) {
      Int32 soma = 0;
      Int32 indexDv = ehDv1 ? 2 : 1;

      Int32 indexPeso = 0;
      for (Int32 i = 0; i < documento.Length - indexDv; i++) {
        soma += Convert.ToInt32(documento[i].ToString()) * pesos[indexPeso];
        indexPeso++;
      }
      Int32 resto = 11 - (soma % 11);
      return resto < 2 ? 0 : resto;
    }

  }
}
