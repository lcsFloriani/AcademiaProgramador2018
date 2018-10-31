using System;

using FluentValidation.Validators;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;

namespace Projeto_NFe.Infra.Validators
{
	public class CpfCnpjValidator : PropertyValidator
	{
		private int _cpfLength = 11;
		private int _cnpjLength = 14;
		private bool _messageExist = false;

		public CpfCnpjValidator(): base("{PropertyName} {Message}") {}

		protected override bool IsValid(PropertyValidatorContext context)
		{
			var value = context.PropertyValue as string;

			long val = 0;
			bool success = Int64.TryParse( value, out val );

			if (success) {
				if (IsCpfValid( context, value ))
					return true;

				if (IsCnpjValid( context, value ))
					return true;

				if (!_messageExist)
					context.MessageFormatter.AppendArgument( "Message", "Formato do dados invalido." );

				return false;
			} else {
				context.MessageFormatter.AppendArgument( "Message", "Não pode ter pontuação." );
				return false;
			}
		}

		private bool IsCpfValid(PropertyValidatorContext context, string cpf)
		{
			bool isValid = true;

			if (cpf.Length == _cpfLength) {
				if (!Cpf.ValidateCPF( cpf )) {
					context.MessageFormatter.AppendArgument( "Message", "CPF inválido" );
					isValid = false;
					_messageExist = true;
				}
			} else {
				isValid = false;
			}
			return isValid;
		}
		private bool IsCnpjValid(PropertyValidatorContext context, string cnpj)
		{
			bool isValid = true;

			if (cnpj.Length == _cnpjLength) {
				if (!Cnpj.ValidateCNPJ( cnpj )) {
					context.MessageFormatter.AppendArgument( "Message", "CNPJ inválido" );
					isValid = false;
					_messageExist = true;
				}
			} else {
				isValid = false;
			}

			return isValid;
		}
	}
}

