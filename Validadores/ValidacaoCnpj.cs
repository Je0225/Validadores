using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidacaoCnpj : ValidacaoDocumentos{

    public ValidacaoCnpj() {
      PesosDv1 = new Int32[] {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};
      PesosDv2 = new Int32[] {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
    }

    public ResultadoValidacao ValidaDocumento(String cnpjInformado) {
      Boolean ehCnpjValido = false;
      String documentoFormatado = "";
      String cnpj = RetornaSoNumerosELetras(cnpjInformado);
      
      if (QuantiaDigitosValida(cnpj, 14)) {
        Int32 digito1 = CalculaDvCpfCnpj(false, cnpj, true, PesosDv1);
        Int32 digito2 = CalculaDvCpfCnpj(false, cnpj, false, PesosDv2);
        ehCnpjValido = cnpj[12].ToString() == digito1.ToString() && cnpj[13].ToString() == digito2.ToString();
        documentoFormatado = cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
      }
      return new ResultadoValidacao(ehCnpjValido, cnpj, documentoFormatado );
    }

  }
}
