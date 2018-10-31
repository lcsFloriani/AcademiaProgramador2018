using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Projeto_NFe.Infra.Validators;

namespace Projeto_NFe.Infra.Extension_Methods
{
	public static class EntityValidatorExtensions
	{
		public static IRuleBuilderOptions<T, TProperty> CpfCnpjValid<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
		{
			return ruleBuilder.SetValidator( new CpfCnpjValidator() );
		}
	}
}
