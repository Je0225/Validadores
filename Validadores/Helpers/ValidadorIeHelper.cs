using System;

namespace Validadores.Helpers {
  internal class ValidadorIeHelper : ValidadorHelper{

    private const String ISENTO = "ISENTO";

    public Boolean EhIsento(String ieInformada) {
      return ieInformada.Trim().ToUpper() == ISENTO;
    }

    public override Boolean QuantiaDigitosValida(String documento, Int32 quantiaEsperada) {
      return base.QuantiaDigitosValida(documento, quantiaEsperada) && !EhIsento(documento);
    }

  }
}
