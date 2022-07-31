using FortisAPI.Standard.Models;

namespace ON.Authorization.ParallelEconomy.Service.Clients.Models
{
    public static class ParallelEconomyExtensions
    {
        public static ResponseContact ToResponseContact(this List1 item)
        {
            return new ResponseContact()
            {
                Data = new Data3()
                {
                    AccountNumber = item.AccountNumber,
                    Active = item.Active,
                    Address = item.Address,
                    Balance = item.Balance,
                    CellPhone = item.CellPhone,
                    CompanyName = item.CompanyName,
                    ContactApiId = item.ContactApiId,
                    ContactC1 = item.ContactC1,
                    ContactC2 = item.ContactC2,
                    ContactC3 = item.ContactC3,
                    CreatedTs = item.CreatedTs,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    EmailTrxReceipt = item.EmailTrxReceipt,
                    HeaderMessage = item.HeaderMessage,
                    HeaderMessageType = item.HeaderMessageType,
                    HomePhone = item.HomePhone,
                    Id = item.Id,
                    LocationId = item.LocationId,
                    ModifiedTs = item.ModifiedTs,
                    OfficePhone = item.OfficePhone,
                    OfficePhoneExt = item.OfficePhoneExt,
                    ParentId = item.ParentId,
                    UpdateIfExists = item.UpdateIfExists,
                }
            };

        }

    }
}
