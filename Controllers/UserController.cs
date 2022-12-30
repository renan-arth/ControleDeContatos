using ControleDeContatos.Models;
using ControleDeContatos.Repositorio.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepositorio _userRepositorio;

        public UserController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
        }

        public IActionResult Index()
        {
            List<UserModel> usuarios = _userRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UserModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}