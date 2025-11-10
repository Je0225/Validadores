using System;
using System.Linq;

namespace Validadores.Helpers {
  internal class ValidadorIeTocantisHelper : ValidadorIeHelper {

    public Boolean ValidaDigitos3E4SaoValidos(String ie) {
      String[] digitosValidos = { "01", "02", "03", "99" };
      return digitosValidos.Contains(ie.Substring(2, 2));
    }

  }
}
