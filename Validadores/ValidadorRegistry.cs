using System;
using System.Collections.Generic;
using Validadores.Validadores;
using Validadores.Validadores.Contratos;

namespace Validadores {
  static class ValidadorRegistry {

    public static readonly IValidadorDocumento[] Estados = {
      new ValidadorIeParana(),
      new ValidadorIeAcre(),
      new ValidadorIeTocantins(),
      new ValidadorIePernambuco()
    };

    public static readonly Dictionary<String, IValidadorDocumento> Documentos = new Dictionary<String, IValidadorDocumento>() {
      {"CNPJ", new ValidadorCnpj()},
      {"CPF", new ValidadorCpf()}
    };

  }
}
