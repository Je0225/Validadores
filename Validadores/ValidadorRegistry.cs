using System;
using System.Collections.Generic;
using Validadores.Validadores;
using Validadores.Validadores.Contratos;

namespace Validadores {
  static class ValidadorRegistry {

    public static readonly IValidadorDocumento[] estados = {
      new ValidadorIeParana(),
      new ValidadorIeAcre(),
      new ValidadorIeTocantins(),
      new ValidadorIePernambuco()
    };

    public static readonly Dictionary<String, IValidadorDocumento> documentos = new Dictionary<String, IValidadorDocumento>() {
      {"CNPJ", new ValidadorCnpj()},
      {"CPF", new ValidadorCpf()}
    };

  }
}
