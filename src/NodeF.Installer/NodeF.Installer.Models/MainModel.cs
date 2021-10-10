using System.ComponentModel;

namespace NodeF.Installer.Models
{
    public class MainModel
    {
        public DNSModel DNS { get; set; } = new();
        public PersonalizationModel Personalization { get; set; } = new();
        public ServerModel Server { get; set; } = new();
    }
}
