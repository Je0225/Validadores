using System;
using Validadores.CalculosDvs;
using Validadores.CalculosDvs.Contratos;
using Validadores.Helpers;
using Validadores.Validadores.Contratos;

namespace Validadores.Validadores {
  internal class ValidadorIePernambuco : IValidadorDocumento{

    private readonly ValidadorIeHelper helper = new ValidadorIeHelper();

    public Int32[] PesosDv1 { get; } = { 8, 7, 6, 5, 4, 3, 2 };

    public Int32[] PesosDv2 { get; } = { 9, 8, 7, 6, 5, 4, 3, 2 };

    private Int32[] PesosValidacaoAntiga { get; } = { 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2 };

    public ICalculoDigitosVerificadores CalculadorDv { get; set; } = new CalculoDigitosVerficadoresIe();

    public ResultadoValidacao ValidaDocumento(String documento) {
      String documentoFormatado = "";
      Boolean ehIeValida = helper.EhIsento(documento);
      String ie = helper.RetornaSoNumeros(documento);

      if (helper.QuantiaDigitosValida(ie, 9)) {
        Int32 digito1 = CalculadorDv.CalculaDv1(ie, PesosDv1);
        Int32 digito2 = CalculadorDv.CalculaDv2(ie, PesosDv2);
        ehIeValida = digito1.ToString() == ie[7].ToString() && digito2.ToString() == ie[8].ToString();
        documentoFormatado = ie.Insert(8, "-");
      } else if (helper.QuantiaDigitosValida(ie, 14)) {
        Int32 digito = CalculadorDv.CalculaDv2(ie, PesosValidacaoAntiga);
        ehIeValida = digito.ToString() == ie[13].ToString();
        documentoFormatado = ie.Insert(2, ".").Insert(4, ".").Insert(8, ".").Insert(16, "-");
      }
      return new ResultadoValidacao(ehIeValida, documento, documentoFormatado);
    }

    public override String ToString() {
      return "PE";
    }

  }
}
