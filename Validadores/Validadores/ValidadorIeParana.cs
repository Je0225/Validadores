using System;
using Validadores.CalculosDvs;
using Validadores.CalculosDvs.Contratos;
using Validadores.Helpers;
using Validadores.Validadores.Contratos;

namespace Validadores.Validadores {
  internal class ValidadorIeParana : IValidadorDocumento{

    private readonly ValidadorIeHelper helper = new ValidadorIeHelper();

    public Int32[] PesosDv1 { get; } = { 3, 2, 7, 6, 5, 4, 3, 2 };

    public Int32[] PesosDv2 { get; } = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };

    public ICalculoDigitosVerificadores CalculadorDv { get; set; } = new CalculoDigitosVerficadoresIe();

    public ResultadoValidacao ValidaDocumento(String documento) {
      String documentoFormatado = "";
      Boolean ehIeValida = helper.EhIsento(documento);
      String ie = helper.RetornaSoNumeros(documento);

      if (helper.QuantiaDigitosValida(ie, 10)) {
        Int32 digito1 = CalculadorDv.CalculaDv1(ie,  PesosDv1);
        Int32 digito2 = CalculadorDv.CalculaDv2(ie,  PesosDv2);
        ehIeValida = ie[8].ToString() == digito1.ToString() && ie[9].ToString() == digito2.ToString();
        documentoFormatado = ie.Insert(3, ".").Insert(9, "-");
      }
      return new ResultadoValidacao(ehIeValida, documento, documentoFormatado);
    }

    public override String ToString() {
      return "PR";
    }

  }
}
