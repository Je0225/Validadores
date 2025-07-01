using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidacaoCPF : ValidacaoDocumentos {

    public ValidacaoCPF() {
      PesosDv1 = new Int32[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      PesosDv2 = new Int32[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    }

    public ResultadoValidacao ValidaDocumento(String cpfInformado) {
      Boolean ehCpfValido = false;
      String documentoFormatado = "";
      String cpf = RetornaSoNumeros(cpfInformado);

      if (QuantiaDigitosValida(cpf, 11)) {
        Int32 digito1 = CalculaDvCpfCnpj(true, cpf, true, PesosDv1);
        Int32 digito2 = CalculaDvCpfCnpj(true, cpf, false, PesosDv2);
        ehCpfValido = cpf[9].ToString() == digito1.ToString() && cpf[10].ToString() == digito2.ToString();
        documentoFormatado = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
      }
      return new ResultadoValidacao(ehCpfValido, cpf, documentoFormatado);
    }
  }
}
