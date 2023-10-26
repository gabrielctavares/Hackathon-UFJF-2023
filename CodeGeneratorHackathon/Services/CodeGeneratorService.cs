using CodeGeneratorHackathon.Models;
using System;
using System.IO;

namespace CodeGeneratorHackathon.Services
{    
    public class CodeGeneratorService
    {
        private readonly ViewRenderService _renderService;
        public CodeGeneratorService(ViewRenderService renderService)
        {
            _renderService = renderService;
        }
        public async Task Generate(string projectPath, IList<ClassModel> listClassModels)
        {
            var basePath = Path.GetDirectoryName(projectPath);

            foreach (var classModel in listClassModels)
            {

                await Generate(basePath, ViewConverter.ClassView, classModel, $"{classModel.Name}.cs");
                await Generate(basePath, ViewConverter.ConfigurationView, classModel, $"{classModel.Name}Configuration.cs");
                
                if (!classModel.IsAbstract)
                {
                    await Generate(basePath, ViewConverter.ControllerView, classModel, $"{classModel.Name}Controller.cs");
                    await Generate(basePath, ViewConverter.ServiceView, classModel, $"{classModel.Name}Service.cs");
                }                    
            }

            await GenerateDataContext(projectPath);
        }

        private async Task GenerateDataContext(string projectPath)
        {

            var list = new ListModels();
            list.ProjectName = Path.GetFileNameWithoutExtension(projectPath);
            var basePath = Path.GetDirectoryName(projectPath);
            var folder = Path.Combine(basePath, ViewConverter.ServiceView.ToPath());
            if (Directory.Exists(folder))
            {
                string[] nomesArquivos = Directory.GetFiles(folder);
                foreach (string nomeArquivo in nomesArquivos)
                {
                    var nomeLimpo = Path.GetFileNameWithoutExtension(nomeArquivo).Replace("Service", "");
                    list.Models.Add(nomeLimpo);
                }
            }
            await Generate(basePath, ViewConverter.DataContextView, list, "DataContext.cs");
        }

        private async Task Generate(string basePath, ViewConverter converter, object data, string filename)
        {  
            var generatedCode = await _renderService.RenderRazorViewToStringAsync(converter, data);
            generatedCode = generatedCode.Trim();

            var folder = Path.Combine(basePath, converter.ToPath());
            
            if(!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var path = Path.Combine(folder, filename);
            await File.WriteAllTextAsync(path, generatedCode);
        }
    }

}
