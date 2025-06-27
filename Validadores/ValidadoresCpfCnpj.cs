using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Validadores {

  internal class ValidadoresCpfCnpj: ValidadoresDocumentos {

    public RetornoValidacoes ValidaCpf(String cpfInformado) {
      String cpf = RetornaSoNumeros(cpfInformado);
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(cpf, 11)
      };
      if (validacao.EhValido) {
        Int32 digito1 = CalculaDv(true, cpf, true, 10);
        Int32 digito2 = CalculaDv(true, cpf, false, 11);
        validacao.EhValido = cpf[9].ToString() == digito1.ToString() && cpf[10].ToString() == digito2.ToString();
        validacao.DocumentoFormatado = cpfInformado.Insert(3, ".").Insert(7, ".").Insert(11, "-");
      }
      return validacao;
    }

    public RetornoValidacoes ValidaCnpj(String cnpjInformado) {
      String cnpj = RetornaSoNumerosELetras(cnpjInformado);
      RetornoValidacoes validacao = new RetornoValidacoes {
        EhValido = QuantiaDigitosValida(cnpj, 14)
      };
      if (validacao.EhValido) {
        Int32 digito1 = CalculaDv(false, cnpj, true, 5);
        Int32 digito2 = CalculaDv(false, cnpj, false, 6);
        validacao.EhValido = cnpj[12].ToString() == digito1.ToString() && cnpj[13].ToString() == digito2.ToString();
        validacao.DocumentoFormatado = cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
      }
      return validacao;
    }

    private Int32 CalculaDv(Boolean ehCpf, String documento, Boolean dv1, Int32 x ) {
      Int32 soma = 0;
      Int32 indexDv = dv1 ? 2 : 1;
      for (Int32 i = 0; i < documento.Length - indexDv; i++) {
        Int32 numero = ehCpf ? 
          Convert.ToInt32(documento[i].ToString()) * x :
          Char.IsLetter(documento[i]) ? Convert.ToInt32(documento[i]) - 48 : Convert.ToInt32(documento[i].ToString());
        soma += numero * x;
        x = ehCpf ? x - 1 : x == 2 ? 9 : x - 1;
      }
      Int32 resto = ehCpf ? (soma * 10) % 11 : soma % 11;
      return ehCpf ? 
        (resto == 10 ? 0 : resto) : 
        (resto < 2 ? 0 : 11 - resto);
    }
  }

}
