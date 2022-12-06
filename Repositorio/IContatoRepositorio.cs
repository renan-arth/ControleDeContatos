using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio : IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
    }
}
