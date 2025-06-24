using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidadoresDocumentos {

    protected Boolean QuantiaDigitosValida(String documento, Int32 quantiaEsperada) {
      return documento.Length == quantiaEsperada && documento.Distinct().Count() > 1;
    }

  }
}
