using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidaIePr: ValidadoresDocumentos {

    public ValidaIePr(Int32[] pesosDv1, Int32[] pesosDv2) {
      PesosDv1 = pesosDv1;
      PesosDv2 = pesosDv2;
    }

    public ResultadoValidacoes IePr(String ieInformada) {
      return null;
    }

  }
}
