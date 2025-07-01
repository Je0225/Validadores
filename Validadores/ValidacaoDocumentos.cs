using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validadores {
  internal class ValidacaoDocumentos {

    protected Int32[] PesosDv1 { get; set; }

    protected Int32[] PesosDv2 { get; set; }

    private const String ISENTO = "ISENTO";

    protected Boolean EhIsento(String ieInformada) {
      return ieInformada.Trim().ToUpper() == ISENTO;
    }

    protected Boolean QuantiaDigitosValida(String documento, Int32 quantiaEsperada) {
      documento = documento.Trim().ToUpper();
      return documento.Length == quantiaEsperada && documento.Distinct().Count() > 1 && !EhIsento(documento);
    }

    protected String RetornaSoNumeros(String documento) {
      documento = documento.Trim().ToUpper();
      return Regex.Replace(documento, @"[^\d]", "");
    }

    protected String RetornaSoNumerosELetras(String documento) {
      documento = documento.Trim().ToUpper();
      return Regex.Replace(documento, @"[^\dA-Z]", "");
    }

    protected Int32 CalculaDvIe(String documento, Int32[] pesos, Boolean ehDv1) {
      Int32 soma = 0;
      Int32 indexDv = ehDv1 ? 2 : 1;

      Int32 indexPeso = 0;
      for (Int32 i = 0; i < documento.Length - indexDv; i++) {
        soma += Convert.ToInt32(documento[i].ToString()) * pesos[indexPeso];
        indexPeso++;
      }
      Int32 resto = 11 - (soma % 11);
      return resto < 2 ? 0 : resto;
    }

    protected Int32 CalculaDvCpfCnpj(Boolean ehCpf, String documento, Boolean ehDv1, Int32[] pesos) {
      Int32 soma = 0;
      Int32 indexDv = ehDv1 ? 2 : 1;
      Int32 indexPeso = 0;

      for (Int32 i = 0; i < documento.Length - indexDv; i++) {
        Int32 numero = ehCpf ?
          Convert.ToInt32(documento[i].ToString()) * pesos[indexPeso] :
          Char.IsLetter(documento[i]) ? Convert.ToInt32(documento[i]) - 48 : Convert.ToInt32(documento[i].ToString());
        soma += numero * pesos[indexPeso];
        indexPeso++;
      }
      Int32 resto = ehCpf ? (soma * 10) % 11 : soma % 11;
      return ehCpf ?
        (resto == 10 ? 0 : resto) :
        (resto < 2 ? 0 : 11 - resto);
    }
  }
}
