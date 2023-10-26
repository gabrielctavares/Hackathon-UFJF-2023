using System.Reflection;

namespace CodeGeneratorHackathon.Models
{
    public enum ViewConverter
    {
        ClassView,
        ServiceView,
        ControllerView,
        DataContextView,
        ConfigurationView
    }
    public static class EnumExtensions
    {
        public static string ToConverterName(this ViewConverter value)
        {
            return value switch
            {
                ViewConverter.ClassView => "ClassConverter",
                ViewConverter.ServiceView => "ServiceConverter",
                ViewConverter.ControllerView => "ControllerConverter",
                ViewConverter.DataContextView => "DataContextConverter",
                ViewConverter.ConfigurationView => "ConfigurationConverter",
                _ => "",
            };
        }
        public static string ToPath(this ViewConverter value)
        {
            return value switch
            {
                ViewConverter.ClassView => "Models",
                ViewConverter.ServiceView => "Services",
                ViewConverter.ControllerView => "Controllers",
                ViewConverter.DataContextView => "Data",
                ViewConverter.ConfigurationView => Path.Combine("Data", "Configurations"),
                _ => "",
            };
        }
    }

}
