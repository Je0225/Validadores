using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validadores {
   internal class ValidacaoIeAcre : ValidacaoDocumentos{

    public ValidacaoIeAcre() {
      PesosDv1 = new Int32[] { 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
      PesosDv2 = new Int32[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
    }

    public ResultadoValidacao ValidaIe(String ieInformada) {
      String documentoFormatado = "";
      Boolean ehIeValida = EhIsento(ieInformada);
      string ie = RetornaSoNumeros(ieInformada);
      
      if (QuantiaDigitosValida(ie, 13) && (ie[0].ToString() == "0" || ie[1].ToString() == "1")) {
        Int32 digito1 = CalculaDvIe(ie, PesosDv1, true);
        Int32 digito2 = CalculaDvIe(ie, PesosDv2, false);
        ehIeValida = digito2.ToString() == ie[12].ToString() && digito1.ToString() == ie[11].ToString();
        documentoFormatado = ie.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(14, "-");
      }
      return new ResultadoValidacao(ehIeValida, ieInformada, documentoFormatado);
    }

  }
}
