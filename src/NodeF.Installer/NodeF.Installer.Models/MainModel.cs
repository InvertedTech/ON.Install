using System.ComponentModel;

namespace NodeF.Installer.Models
{
    public class MainModel : IChangeTracking
    {
        public PersonalizationModel Personalization { get; set; }

        public bool IsChanged
        {
            get;
            private set;
        }

        public void AcceptChanges()
        {
            IsChanged = false;
        }
    }
}
