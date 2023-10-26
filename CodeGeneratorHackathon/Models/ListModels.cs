namespace CodeGeneratorHackathon.Models
{
    public class ListModels
    {
        public ListModels() { 
            Models = new List<string>();
        }
        public string ProjectName { get; set; }
        public IList<string> Models { get; set; }

    }
}
