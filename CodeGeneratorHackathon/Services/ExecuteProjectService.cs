using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics;

namespace CodeGeneratorHackathon.Services
{
    public class ExecuteProjectService
    {
        private async Task<bool> ExecuteProcess(string basePath, string comando)
        {
            var dotnetProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = comando,
                    WorkingDirectory = basePath,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            dotnetProcess.Start();
            await dotnetProcess.WaitForExitAsync();

            return dotnetProcess.ExitCode == 0;
        }
        private bool ExecuteCMD(string basePath, string comando)
        {
            var cmdProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    UseShellExecute = true,
                    WorkingDirectory = basePath,
                    Arguments = "/c " +comando,
                    
                }
            };
            cmdProcess.Start();
            return true;
        }

        public async Task ExecuteService(string path)
        {
            var basePath = Path.GetDirectoryName(path);
            var updateName = $"Update{Guid.NewGuid()}";
            var migrationsCommand = $"ef migrations add {updateName}";

            if (!await ExecuteProcess(basePath, migrationsCommand))
                throw new Exception("Não foi possível gerar as migrações do sistema.");

            var runCommand = $"dotnet run";

            if(!ExecuteCMD(basePath, runCommand))
                throw new Exception("Não foi possível iniciar o sistema.");
        }

    }
}

