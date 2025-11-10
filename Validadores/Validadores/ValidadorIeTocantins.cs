using System;
using Validadores.CalculosDvs;
using Validadores.CalculosDvs.Contratos;
using Validadores.Helpers;
using Validadores.Validadores.Contratos;

namespace Validadores.Validadores {
  internal class ValidadorIeTocantins : IValidadorDocumento {

    private readonly ValidadorIeTocantisHelper helper = new ValidadorIeTocantisHelper();

    public Int32[] PesosDv1 { get; } = null;

    public Int32[] PesosDv2 { get; } = { 9, 8, 7, 6, 5, 4, 3, 2 };

    public ICalculoDigitosVerificadores CalculadorDv { get; set; } = new CalculoDigitosVerficadoresIe();

    public ResultadoValidacao ValidaDocumento(String documento) {
      String documentoFormatado = "";
      Boolean ehIeValida = helper.EhIsento(documento);
      String ie = helper.RetornaSoNumeros(documento);

      if (helper.QuantiaDigitosValida(ie, 11) && helper.ValidaDigitos3E4SaoValidos(ie)) {
        String ieCom9Digitos = ie.Remove(2, 2);
        Int32 digito = CalculadorDv.CalculaDv2(ieCom9Digitos, PesosDv2);
        ehIeValida = digito.ToString() == ieCom9Digitos[8].ToString();
        documentoFormatado = ie.Insert(2, ".").Insert(9, "-");
      }
      return new ResultadoValidacao(ehIeValida, documento, documentoFormatado);
    }

    public override String ToString() {
      return "TO";
    }

  }
}
