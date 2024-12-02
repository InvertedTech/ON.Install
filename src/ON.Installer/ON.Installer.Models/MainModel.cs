using System;
using System.ComponentModel;

namespace ON.Installer.Models
{
    public class MainModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DNSModel DNS { get; set; } = new();
        public ServerModel Server { get; set; } = new();
        public CredentialsModel Credentials { get; set; } = new();
        public ProductSelectionModel ProductSelection { get; set; } = new();
        public BusinessModel Business { get; set; } = new();
    }
}
