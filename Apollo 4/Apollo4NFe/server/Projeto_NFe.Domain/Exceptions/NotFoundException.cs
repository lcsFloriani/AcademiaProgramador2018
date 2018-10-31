﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Exceptions
{
	public class NotFoundException : BusinessException
	{
		public NotFoundException() : base( ErrorCodes.NotFound, "Registry not found" ) { }
	}
}
