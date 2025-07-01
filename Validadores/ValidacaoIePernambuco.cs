using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidacaoIePernambuco : ValidacaoDocumentos{

    private Int32[] PesosValidacaoAntiga { get; }

    public ValidacaoIePernambuco() {
      PesosDv1 = new Int32[] { 8, 7, 6, 5, 4, 3, 2 };
      PesosDv2 = new Int32[] { 9, 8, 7, 6, 5, 4, 3, 2 };
      PesosValidacaoAntiga = new Int32[] { 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2 };
    }

    public ResultadoValidacao ValidaIe(String ieInformada) {
      String documentoFormatado = "";
      Boolean ehIeValida = EhIsento(ieInformada);
      String ie = RetornaSoNumeros(ieInformada);

      if (QuantiaDigitosValida(ie, 9)) {
        Int32 digito1 = CalculaDvIe(ie, PesosDv1, true);
        Int32 digito2 = CalculaDvIe(ie, PesosDv2, false);
        ehIeValida = digito1.ToString() == ie[7].ToString() && digito2.ToString() == ie[8].ToString();
        documentoFormatado = ie.Insert(8, "-");
      } else if (QuantiaDigitosValida(ie, 14)) {
        Int32 digito = CalculaDvIe(ie, PesosValidacaoAntiga, false);
        ehIeValida = digito.ToString() == ie[13].ToString();
        documentoFormatado = ie.Insert(2, ".").Insert(4, ".").Insert(8, ".").Insert(16, "-");
      }
      return new ResultadoValidacao(ehIeValida, ieInformada, documentoFormatado);
    }

  }
}
