using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidadoresDocumentos {

    protected Boolean QuantiaDigitosValida(String documento, Int32 quantiaEsperada) {
      return documento.Length == quantiaEsperada && documento.Distinct().Count() > 1;
    }

    protected String RetornaSoNumeros(String documento) {
      return Regex.Replace(documento, @"[^\d]", "");
    }

    protected String RetornaSoNumerosELetras(String documento) {
      return Regex.Replace(documento.ToUpper(), @"[^\dA-Z]", "");
    }

  }
}
