using System;

namespace Validadores.CalculosDvs.Contratos {
  internal interface ICalculoDigitosVerificadores {

    Int32 CalculaDv1(String documento, Int32[] pesos);

    Int32 CalculaDv2(String documento, Int32[] pesos);

  }
}
