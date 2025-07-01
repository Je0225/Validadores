using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validadores {
  internal class ResultadoValidacoes {

    private String documento;

    public String DocumentoFormatado {
      get => documento;
      set => documento = EhValido ? value : "";
    }

    public Boolean EhValido { get; set; }

  }
}
