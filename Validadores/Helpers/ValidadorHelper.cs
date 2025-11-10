using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Validadores.Helpers {
  internal class ValidadorHelper {

    public virtual Boolean QuantiaDigitosValida(String documento, Int32 quantiaEsperada) {
      documento = documento.Trim().ToUpper();
      return documento.Length == quantiaEsperada && documento.Distinct().Count() > 1;
    }

    public String RetornaSoNumeros(String documento) {
      documento = documento.Trim().ToUpper();
      return Regex.Replace(documento, @"[^\d]", "");
    }

  }
}
