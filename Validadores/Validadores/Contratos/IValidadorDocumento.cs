using System;
using Validadores.CalculosDvs.Contratos;

namespace Validadores.Validadores.Contratos {
  internal interface IValidadorDocumento {

    Int32[] PesosDv1 { get; }

    Int32[] PesosDv2 { get; }

    ICalculoDigitosVerificadores CalculadorDv { get; set; }

    ResultadoValidacao ValidaDocumento(String documento);

  }
}
