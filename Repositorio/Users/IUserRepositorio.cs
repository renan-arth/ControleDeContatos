using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio.Users
{
    public interface IUserRepositorio
    {
        UserModel ListarPorId(int Id);

        List<UserModel> BuscarTodos();

        UserModel Adicionar(UserModel usuario);

        UserModel Atualizar(UserModel usuario);

        bool Apagar(int id);
    }
}
