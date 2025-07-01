using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validadores {
  internal class Validadores{

    public String[] Estados { get; } = new[] { "PR", "AC", "TO", "PE" };

    private ValidacaoIeParana ValidadorPr { get; } = new ValidacaoIeParana();

    private ValidacaoIeAcre ValidadorAc { get; } = new ValidacaoIeAcre();

    private ValidacaoIeTocantins ValidadorTo { get; } = new ValidacaoIeTocantins();

    private ValidacaoIePernambuco ValidadorPe { get; } = new ValidacaoIePernambuco();

    private ValidacaoCPF ValidadorCpf { get; } = new ValidacaoCPF();

    private ValidacaoCnpj ValidadorCnpj { get; } = new ValidacaoCnpj();

    public ResultadoValidacao ValidaIeParana(String ieInformada) {
      return ValidadorPr.ValidaIe(ieInformada);
    }

    public ResultadoValidacao ValidaIeAcre(String ieInformada) {
      return ValidadorAc.ValidaIe(ieInformada);
    }

    public ResultadoValidacao ValidaIeTocantins(String ieInformada) {
      return ValidadorTo.ValidaIe(ieInformada);
    }

    public ResultadoValidacao ValidaIePernambuco(String ieInformada) {
      return ValidadorPe.ValidaIe(ieInformada);
    }

    public ResultadoValidacao ValidaCpf(String cpfInformada) {
      return ValidadorCpf.ValidaDocumento(cpfInformada);
    }

    public ResultadoValidacao ValidaCnpj(String cnpjInformado) {
      return ValidadorCnpj.ValidaDocumento(cnpjInformado);
    }

  }
}
