using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio.Users
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly BancoContext _context;
        public UserRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public UserModel ListarPorId(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> BuscarTodos()
        {
            //Carregando tudo que está no banco de dados em uma lista
            return _context.Users.ToList();
        }

        public UserModel Adicionar(UserModel usuario)
        {
            usuario.CreationDate = DateTime.Now;

            _context.Users.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public UserModel Atualizar(UserModel usuario)
        {
            UserModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null)
                throw new Exception("Houve um erro na atualização do usuário!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.UpdateDate = DateTime.Now;

            _context.Users.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UserModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null)
                throw new Exception("Houve um erro na atualização do usuário!");

            _context.Users.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}
