using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validadores {
  internal class ResultadoValidacao {

    public String Documento { get; }

    public Boolean EhDocumentoValido { get;}

    public ResultadoValidacao(Boolean ehDocumentoValido, String documento, String documentoFormatado) {
      EhDocumentoValido = ehDocumentoValido;
      Documento = String.IsNullOrEmpty(documentoFormatado) ? documento : documentoFormatado;
    }

  }
}
