namespace CodeGeneratorHackathon.Models
{
    public enum ComplexTypeRelation
    {
        None,
        OneToOne,
        OneToMany,
    }
    public class PropertyModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsComplexType { get; set; }
        public ComplexTypeRelation Relation { get; set; }
        public string ForeignKey { get => $"{Name}Id";}
    }
}
