using Locadora.Data;
using Locadora.Models;
using Locadora.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Locadora.Controllers
{
    public class ContaController : Controller
    {
        private readonly MainContext _db;

        public ContaController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVm loginVm)
        {
            try
            {
                if (string.IsNullOrEmpty(loginVm.Cpf)) throw new Exception("Informe um CPF!");
                if (string.IsNullOrEmpty(loginVm.Senha)) throw new Exception("Informe uma senha!");

                var usuario = _db.Funcionarios.FirstOrDefault(x => x.Cpf == loginVm.Cpf);

                if (usuario == null) throw new Exception("Usuário ou senha inválidos!");

                if (usuario.Ativo == false) throw new Exception("Usuário desativado!");

                var hashExistente = usuario.Senha;

                var usuarioParaValidar = new Funcionario
                {
                    Cpf = loginVm.Cpf,
                    Senha = loginVm.Senha
                };

                if (usuarioParaValidar.ValidarUsuarioSenha(hashExistente))
                {
                    var claims = new List<Claim>
                    {
                        new Claim("UserId", usuario.Nome),
                        new Claim(ClaimTypes.Name, usuario.Nome),
                        new Claim("FullName", usuario.Nome),
                        new Claim(ClaimTypes.Role, usuario.Perfil.ToString()),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        RedirectUri = "~/Home/Index",
                    };                 

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return Redirect(authProperties.RedirectUri);
                }
                else
                {
                    throw new Exception("Usuário ou senha inválidos!");
                }
            }
            catch (Exception e)
            {
                return Redirect($"/Conta/Login?falha=true&msg={e.Message}");
            }
        }

        public async Task<ActionResult> Sair()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Conta");
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(string novaSenha)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirstValue("UserId"));
                var funcionario = _db.Funcionarios.Find(userId);
                funcionario.Senha = funcionario.GerarMd5(novaSenha);
                _db.SaveChanges();
                return Json(new { Success = "Senha alterada com sucesso!" });
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }
    }
}
