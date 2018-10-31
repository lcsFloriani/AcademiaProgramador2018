using ExercicioContaCorrente.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioContaCorrente.Infra.Data
{
    public class ContaCorrenteMem
    {
        private static List<Conta> _contas = new List<Conta>();

        public static int id = 0;

        public void Insert(Conta conta)
        {
            id++;
            conta.id = id;
            _contas.Add(conta);
        }

        public void Update(Conta conta)
        {
            Conta contaEncontrada = _contas.Find(delegate (Conta t) { return t.numero == conta.numero; });

            contaEncontrada.numero = conta.numero;
            contaEncontrada.saldo = conta.saldo;
            contaEncontrada.especial = conta.especial;
        }

        public void Delete(Conta conta)
        {
            conta = _contas.Find(delegate (Conta t) { return t.numero == conta.numero; });

            _contas.Remove(conta);
        }

        public Conta GetById(long numero)
        {
            return _contas.Find(delegate (Conta t) { return t.numero == numero; });
        }

        public List<Conta> GetAll()
        {
            return _contas;
        }
    }
}

