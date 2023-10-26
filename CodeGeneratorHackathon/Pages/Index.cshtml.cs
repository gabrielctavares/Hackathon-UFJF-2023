using CodeGeneratorHackathon.Models;
using CodeGeneratorHackathon.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using CodeGeneratorHackathon.Utils;

namespace CodeGeneratorHackathon.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CodeGeneratorService _generatorService;
        private readonly ExecuteProjectService _executeService;


        [BindProperty]
        public string Projeto { get; set; }

        [BindProperty]
        public string ConteudoODL { get; set; }

        public IndexModel(ILogger<IndexModel> logger, CodeGeneratorService generatorService, ExecuteProjectService executeProjectService)
        {
            _logger = logger;
            _generatorService = generatorService;
            _executeService = executeProjectService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if (Path.GetExtension(Projeto).ToLower() != ".csproj" || !System.IO.File.Exists(Projeto))
            {
                TempData["Erro"] = "Informe um caminho de projeto válido";
                return Page();
            }

            var action = Request.Form["action"];

            switch (action)
            {
                case "GerarCodigo":
                    await GerarCodigo();
                    break;
                case "IniciarSistema":
                    await IniciarSistema();
                    break;
            }

            return Page();
        }

        private async Task GerarCodigo()
        {
            try
            {

                var item = ODLParser.Parse(ConteudoODL, Projeto);
                await _generatorService.Generate(Projeto, item);
            }
            catch (Exception e)
            {
                TempData["Erro"] = $"{e.Message}{Environment.NewLine}Verifique a ODL e tente novamente";
            }
        }
        private async Task IniciarSistema()
        {
            try
            {
                await _executeService.ExecuteService(Projeto);
            }
            catch (Exception e)
            {
                TempData["Erro"] = $"{e.Message}{Environment.NewLine}Verifique as configurações e tente novamente";
            }
        }
    }
}