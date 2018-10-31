using BancoTabajara.Dominio.Enum;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Infra.ORM.Contexto;
using System.Data.Entity;
using System.Linq;

namespace BancoTabajara.Infra.ORM.Funcionalidades.Contas
{
    public class ContaRepositorio : IContaRepositorio
    {
        private BancoTabajaraDbContexto _contexto;
        private int _linhasAfetadasNoAtualizar = 0;
        private int _linhasAfetadasNoAtualizarEstado = 1;
        private int _maiorQue = 0;

        public ContaRepositorio(BancoTabajaraDbContexto contexto)
        {
            _contexto = contexto;
        }

        public Conta Adicionar(Conta conta)
        {
            Conta novaConta = _contexto.Contas.Add(conta);
            _contexto.SaveChanges();

            return novaConta;
        }

        public bool Atualizar(Conta conta)
        {
            _contexto.Contas.Attach(conta);
            _contexto.Entry(conta).State = EntityState.Modified;

            return _contexto.SaveChanges() > _linhasAfetadasNoAtualizar;
        }

        public bool AtualizarEstado(Conta conta)
        {
            _contexto.Contas.Attach(conta);

            _contexto.Entry(conta).Property(c => c.Estado).IsModified = true;

            return _contexto.SaveChanges() == _linhasAfetadasNoAtualizarEstado;

        }
        public bool AtualizarComMovimentacao(OperacaoContaEnum operacaoConta, params Conta[] contas)
        {
            foreach (Conta conta in contas)
            {
                _contexto.Entry(conta).Property(c => c.Saldo).IsModified = true;
            }
            return _contexto.SaveChanges() == (int) operacaoConta;
        }

        public Conta BuscarPorId(long id)
        {
            Conta conta = _contexto.Contas.Include(c => c.Cliente).Include(c => c.Movimentacoes).FirstOrDefault(c => c.Id == id);

            if (conta == null)
                throw new NaoEncontradoExcecao();

            return conta; 
        }

        public IQueryable<Conta> Listagem(int quantidade)
        {
            return _contexto.Contas.Include(c => c.Cliente).Include(c => c.Movimentacoes).Take(quantidade);
        }

        public bool Excluir(Conta conta)
        {
            _contexto.Entry(conta).State = EntityState.Deleted;

            return _contexto.SaveChanges() > _linhasAfetadasNoAtualizar;
        }

        public bool VerificarNumeroConta(Conta conta)
        {
            int count = (from c in _contexto.Contas where c.Id == conta.Id && c.NumeroConta == conta.NumeroConta select c).Count();

            return count > _maiorQue;
        }
    }
}
