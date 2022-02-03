using System;
using System.ComponentModel;

namespace ON.Installer.Models
{
    public class MainModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DNSModel DNS { get; set; } = new();
        public PersonalizationModel Personalization { get; set; } = new();
        public ServerModel Server { get; set; } = new();
        public CredentialsModel Credentials { get; set; } = new();
        public PaymentModel Payment { get; set; } = new();
    }
}
