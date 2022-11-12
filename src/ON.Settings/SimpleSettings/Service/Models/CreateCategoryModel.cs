using ON.Fragments.Settings;
using System;

namespace ON.Settings.SimpleSettings.Service.Models
{
    public class CreateCategoryModel
    {
        public string ParentCategoryId { get; set; }
        public string DisplayName { get; set; }
        public string UrlStub { get; set; }

        public bool IsValid()
        {
            ParentCategoryId = ParentCategoryId.Trim();
            DisplayName = DisplayName.Trim();
            UrlStub = UrlStub.Trim();

            if (string.IsNullOrEmpty(DisplayName))
                return false;
            if (string.IsNullOrEmpty(UrlStub))
                return false;

            if (!string.IsNullOrEmpty(ParentCategoryId))
            {
                if (!Guid.TryParse(ParentCategoryId, out Guid parentId))
                    return false;
            }

            return true;
        }

        public CategoryRecord ToRecord()
        {
            return new()
            {
                CategoryId = Guid.NewGuid().ToString(),
                DisplayName = DisplayName,
                UrlStub = UrlStub,
                ParentCategoryId = ParentCategoryId,
            };
        }
    }
}
