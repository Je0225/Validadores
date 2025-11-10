using System;
using Validadores.CalculosDvs;
using Validadores.CalculosDvs.Contratos;
using Validadores.Helpers;
using Validadores.Validadores.Contratos;

namespace Validadores.Validadores {
  internal class ValidadorIeAcre : IValidadorDocumento {

    private readonly ValidadorIeHelper helper = new ValidadorIeHelper();

    public Int32[] PesosDv1 { get; } = { 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    public Int32[] PesosDv2 { get; } = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    public ICalculoDigitosVerificadores CalculadorDv { get; set; } = new CalculoDigitosVerficadoresIe();

    public ResultadoValidacao ValidaDocumento(String documento) {
      String documentoFormatado = "";
      Boolean ehIeValida = helper.EhIsento(documento);
      string ie = helper.RetornaSoNumeros(documento);

      if (helper.QuantiaDigitosValida(ie, 13) && (ie[0].ToString() == "0" || ie[1].ToString() == "1")) {
        Int32 digito1 = CalculadorDv.CalculaDv1(ie, PesosDv1);
        Int32 digito2 = CalculadorDv.CalculaDv2(ie, PesosDv2);
        ehIeValida = digito2.ToString() == ie[12].ToString() && digito1.ToString() == ie[11].ToString();
        documentoFormatado = ie.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(14, "-");
      }
      return new ResultadoValidacao(ehIeValida, documento, documentoFormatado);
    }

    public override String ToString() {
      return "AC";
    }

  }
}
