using ExercicioContaCorrente.Domain;
using ExercicioContaCorrente.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioContaCorrente.Applications
{
    public class ContaService
    {
        public ContaService()
        {
        }

        public ContaCorrenteMem _contaDAO = new ContaCorrenteMem();

        public Conta AddConta(Conta conta)
        {
            try
            {
                //conta.Validate(); //Valida o produto

                //conta = _contaDAO.Add(conta);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
                //MessageBox.Show(e.Message);
            }

            return conta;
        }

        public Conta WithdrawMoney(Conta conta)
        {
            return conta;
        }
    }
}
