﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Modal
{
    public abstract class Entidade
    {
        public int Id { get; set; }

        public abstract void Validacoes();

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Entidade entidade = obj as Entidade;
            if (entidade == null)
                return false;
            else
                return Id.Equals(entidade.Id);
        }
    }
}
