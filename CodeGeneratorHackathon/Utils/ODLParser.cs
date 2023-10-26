using CodeGeneratorHackathon.Models;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CodeGeneratorHackathon.Utils
{
    public static class ODLParser
    {
        public static IList<ClassModel> Parse(string odlString, string projectPath)
        {
            var list = new List<ClassModel>();
            var projectName = Path.GetFileNameWithoutExtension(projectPath);

            //pattern utilizando grupos de captura para identificar as propriedades
            string pattern = @"(?i)(class|struct)\s+(\w+)\s*\w*\s*(\w*)?\s*{([^}]*)}";

            var regex = new Regex(pattern,RegexOptions.Singleline);

            var matches = regex.Matches(odlString);

            if (!Validar(matches, odlString))
                throw new Exception("Há uma Classe|Estrutura inválida.");


            foreach (Match match in matches.Cast<Match>())
            {

                var classModel = new ClassModel();
                classModel.Name = match.Groups[2].Value;
                classModel.IsSubclass = !string.IsNullOrWhiteSpace(match.Groups[3].Value);
                classModel.BaseClassName = match.Groups[3].Value;
                classModel.Properties = GetProperties(match.Groups[4].Value);
                classModel.IsAbstract = CheckAbstract(odlString, classModel.Name);
                classModel.ProjectName = projectName;

                list.Add(classModel);
            }
            return list;
        }   

        private static bool CheckAbstract(string odlString, string name)
        {
            string pattern = @$"(?i)extends\s+{name}";
            var regex = new Regex(pattern, RegexOptions.Singleline);            
            return regex.IsMatch(odlString);
        }

        private static List<PropertyModel> GetProperties(string value)
        {
            var properties = new List<PropertyModel>();
            string pattern = @"(?i)(\w+\s+)?(\w+\s+)?(\w+)\s+(\w+);";
            var regex = new Regex(pattern, RegexOptions.Singleline);
            var matches = regex.Matches(value);

            if (!Validar(matches, value))
                throw new Exception("Há um atributo inválido.");

            foreach (Match match in matches.Cast<Match>())
            {
                var property = new PropertyModel();
                property.IsComplexType = !string.IsNullOrWhiteSpace(match.Groups[2].Value);
                property.Name = Capitalize(match.Groups[4].Value);
                property.Type = property.IsComplexType ? match.Groups[3].Value : ParseType(match.Groups[3].Value);
                property.Relation = GetRelation(property.IsComplexType, property.Type);
                properties.Add(property);                
            }
            return properties;
        }

        private static bool Validar(MatchCollection matches, string input)
        {
            input = Regex.Replace(input, "[^a-zA-Z{}]", ""); 
            int totalLength = 0;
            foreach (Match match in matches)
                totalLength += Regex.Replace(match.Value, "[^a-zA-Z{}]", "").Length;

            return totalLength == input.Length;
        }

        private static ComplexTypeRelation GetRelation(bool isComplexType, string type)
        {
            if (!isComplexType)
                return ComplexTypeRelation.None;

            if (type.ToLower().Contains("list<"))
                return ComplexTypeRelation.OneToMany;

            return ComplexTypeRelation.OneToOne;
        }

        private static string Capitalize(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return char.ToUpper(value[0]) + value[1..];

            return value;
        }

        private static string ParseType(string value)
        {
            value = value.Trim().ToLower();
            
            if (value.Equals("boolean")) 
                return "bool";

            if (value.Equals("date") || value.Equals("timestamp"))
                return "DateTime";

            if (value.Equals("time"))
                return "TimeSpan";
            
            if (value.Contains("set<"))
                return value.Replace("set<", "List<");

            if (value.Contains("bag<"))
                return value.Replace("bag<", "List<");

            if (value.Contains("array<"))
                return value.Replace("array<", "List<");

            return value;
        }
    }
}
