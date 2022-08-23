using Locadora.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Components
{
    public class NotificacaoViewComponent : ViewComponent
    {
        private readonly MainContext _db;

        public NotificacaoViewComponent(MainContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = _db.Notificacoes.Where(x => !x.Lida).ToList();
            return await Task.FromResult((IViewComponentResult)View("Exibir", notificacoes));
        }
    }
}