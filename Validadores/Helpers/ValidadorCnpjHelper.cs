using System;
using System.Text.RegularExpressions;

namespace Validadores.Helpers {
  internal class ValidadorCnpjHelper : ValidadorHelper{

    public String RetornaSoNumerosELetras(String documento) {
      documento = documento.Trim().ToUpper();
      return Regex.Replace(documento, @"[^\dA-Z]", "");
    }

  }
}
