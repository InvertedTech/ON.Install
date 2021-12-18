using System;
using System.ComponentModel;

namespace NodeF.Installer.Models
{
    public class MainModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DNSModel DNS { get; set; } = new();
        public PersonalizationModel Personalization { get; set; } = new();
        public ServerModel Server { get; set; } = new();
        public CredentialsModel Credentials { get; set; } = new();
    }
}
