using System;
using Validadores.CalculosDvs.Contratos;

namespace Validadores.CalculosDvs {

  internal class CalculoDigitosVerificadoresCpf: ICalculoDigitosVerificadores {

    private const Int32 INDEX_DV1 = 2;

    private const Int32 INDEX_DV2 = 1;

    private Int32 CalculaDv(String documento, Int32 indexDv, Int32[] pesos) {
      Int32 soma = 0;
      Int32 indexPeso = 0;

      for (Int32 i = 0; i < documento.Length - indexDv; i++) {
        Int32 numero = Convert.ToInt32(documento[i].ToString());
        soma += numero * pesos[indexPeso];
        indexPeso++;
      }
      Int32 resto = (soma * 10) % 11;
      return resto == 10 ? 0 : resto;
    }

    public Int32 CalculaDv1(String documento, Int32[] pesos) {
      return CalculaDv(documento, INDEX_DV1, pesos);
    }

    public Int32 CalculaDv2(String documento, Int32[] pesos) {
      return CalculaDv(documento, INDEX_DV2, pesos);
    }

  }
}
