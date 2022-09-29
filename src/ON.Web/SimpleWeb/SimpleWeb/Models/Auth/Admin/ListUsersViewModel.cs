
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Auth.Admin
{
    public class ListUsersViewModel
    {
        public UserNormalRecord[] UserRecords { get; set; }
    }
}
