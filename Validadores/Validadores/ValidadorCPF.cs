using System;
using Validadores.CalculosDvs;
using Validadores.CalculosDvs.Contratos;
using Validadores.Helpers;
using Validadores.Validadores.Contratos;

namespace Validadores.Validadores {
  internal class ValidadorCpf : IValidadorDocumento {

    private readonly ValidadorHelper helper  = new ValidadorHelper();

    public Int32[] PesosDv1 { get; } = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

    public Int32[] PesosDv2 { get; } = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

    public ICalculoDigitosVerificadores CalculadorDv { get; set; } = new CalculoDigitosVerificadoresCpf();

    public ResultadoValidacao ValidaDocumento(String documento) {
      Boolean ehCpfValido = false;
      String documentoFormatado = "";
      String cpf = helper.RetornaSoNumeros(documento);

      if (helper.QuantiaDigitosValida(cpf, 11)) {
        Int32 digito1 = CalculadorDv.CalculaDv1(cpf, PesosDv1);
        Int32 digito2 = CalculadorDv.CalculaDv2(cpf, PesosDv2);
        ehCpfValido = cpf[9].ToString() == digito1.ToString() && cpf[10].ToString() == digito2.ToString();
        documentoFormatado = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
      }
      return new ResultadoValidacao(ehCpfValido, cpf, documentoFormatado);
    }

    public override String ToString() {
      return "CPF";
    }

  }
}
