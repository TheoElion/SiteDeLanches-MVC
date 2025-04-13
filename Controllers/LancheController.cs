using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class LancheController : Controller
{

    private readonly ILanchesRepository _lancheRepository;

    public LancheController(ILanchesRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    public IActionResult List()
    {
        var lanchesListViewModel = new LancheListViewModel();
        lanchesListViewModel.Lanches = _lancheRepository.Lanches;
        lanchesListViewModel.CategoriaAtual = "Categoria atual";

        return View(lanchesListViewModel);
    }
}
