using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidacaoIeTocantins : ValidacaoDocumentos{

    public ValidacaoIeTocantins() {
      PesosDv2 = new Int32[] { 9, 8, 7, 6, 5, 4, 3, 2 };
    }

    private Boolean Digitos3e4SaoValidos(String ie) {
      switch (ie.Substring(2, 2)) {
        case "01": return true;
        case "02": return true;
        case "03": return true;
        case "99": return true;
        default: return false;
      }
    }

    public ResultadoValidacao ValidaIe(String ieInformada) {
      String documentoFormatado = "";
      Boolean ehIeValida = EhIsento(ieInformada);
      String ie = RetornaSoNumeros(ieInformada);
      
      if (QuantiaDigitosValida(ie, 11) && Digitos3e4SaoValidos(ie)) {
        String ieCom9Digitos = ie.Remove(2, 2);
        Int32 digito = CalculaDvIe(ieCom9Digitos, PesosDv2, false);
        ehIeValida = digito.ToString() == ieCom9Digitos[8].ToString();
        documentoFormatado = ie.Insert(2, ".").Insert(9, "-");
      }
      return new ResultadoValidacao(ehIeValida, ieInformada, documentoFormatado);
    }
  }
}
