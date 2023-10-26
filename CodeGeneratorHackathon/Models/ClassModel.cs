namespace CodeGeneratorHackathon.Models
{
    public class ClassModel
    {
        public string ProjectName { get; set; }
        public string Name { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsSubclass { get; set; }
        public string BaseClassName { get; set; }
        public List<PropertyModel> Properties { get; set; }

        public ClassModel()
        {
            Properties = new List<PropertyModel>();
        }
    }
}
