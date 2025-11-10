using System;
using Validadores.CalculosDvs;
using Validadores.CalculosDvs.Contratos;
using Validadores.Helpers;
using Validadores.Validadores.Contratos;

namespace Validadores.Validadores {
  internal class ValidadorCnpj : IValidadorDocumento {

    private readonly ValidadorCnpjHelper helper = new ValidadorCnpjHelper();

    public Int32[] PesosDv1 { get; } = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    public Int32[] PesosDv2 { get; } = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    public ICalculoDigitosVerificadores CalculadorDv { get; set; } = new CalculoDigitosVerificadoresCnpj();

    public ResultadoValidacao ValidaDocumento(String cnpjInformado) {
      Boolean ehCnpjValido = false;
      String documentoFormatado = "";
      String cnpj = helper.RetornaSoNumerosELetras(cnpjInformado);

      if (helper.QuantiaDigitosValida(cnpj, 14)) {
        Int32 digito1 = CalculadorDv.CalculaDv1(cnpj, PesosDv1);
        Int32 digito2 = CalculadorDv.CalculaDv2(cnpj, PesosDv2);
        ehCnpjValido = cnpj[12].ToString() == digito1.ToString() && cnpj[13].ToString() == digito2.ToString();
        documentoFormatado = cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
      }
      return new ResultadoValidacao(ehCnpjValido, cnpj, documentoFormatado);
    }

    public override String ToString() {
      return "CNPJ";
    }

  }
}