
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Web.Models.Admin
{
    public class ListUsersViewModel
    {
        public UserRecord.Types.PublicData[] UserRecords { get; set; }
    }
}
