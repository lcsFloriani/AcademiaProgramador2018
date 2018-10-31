using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Interfaces
{
    public interface ITesteQuestaoSQL
    {

       void AdicionarNaTabelaIntermediaria(Teste teste,  Questao questao);

        
    }
}
