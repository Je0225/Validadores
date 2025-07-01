using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidacaoIeParana: ValidacaoDocumentos {

    public ValidacaoIeParana() {
      PesosDv1 = new Int32[] { 3, 2, 7, 6, 5, 4, 3, 2 };
      PesosDv2 = new Int32[] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
    }

    public ResultadoValidacao ValidaIe(String ieInformada) {
      String documentoFormatado = "";
      Boolean ehIeValida = EhIsento(ieInformada);
      String ie = RetornaSoNumeros(ieInformada);
      
      if (QuantiaDigitosValida(ie, 10)) {
        Int32 digito1 = CalculaDvIe(ie, PesosDv1, true);
        Int32 digito2 = CalculaDvIe(ie, PesosDv2, false);
        ehIeValida = ie[8].ToString() == digito1.ToString() && ie[9].ToString() == digito2.ToString();
        documentoFormatado = ie.Insert(3, ".").Insert(9, "-");
      }
      return new ResultadoValidacao(ehIeValida, ieInformada, documentoFormatado);
    }

  }
}
