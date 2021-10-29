using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NodeF.Authentication
{
    public class NodeUser : ClaimsPrincipal
    {
        public Guid Id { get; set; } = Guid.Empty;
        public const string IdType = "Id";

        public string UserName { get; set; } = "";
        public const string UserNameType = "sub";

        public string DisplayName { get; set; } = "";
        public const string DisplayNameType = "Display";

        public List<string> Idents { get; private set; } = new List<string>();
        public const string IdentsType = "Idents";

        public List<Claim> ExtraClaims { get; private set; } = new List<Claim>();

        public string JwtToken { get; set; } = "";


        public IEnumerable<Claim> ToClaims()
        {
            if (Id != Guid.Empty)
                yield return new Claim(IdType, Id.ToString());

            if (!string.IsNullOrWhiteSpace(UserName))
                yield return new Claim(UserNameType, UserName);

            if (!string.IsNullOrWhiteSpace(DisplayName))
                yield return new Claim(DisplayNameType, DisplayName);

            if (Idents.Count != 0)
                yield return new Claim(IdentsType, string.Join(';', Idents));

            foreach (var c in ExtraClaims)
                yield return c;
        }

        public static NodeUser Parse(IEnumerable<Claim> claims)
        {
            if (claims == null)
                return null;

            var user = new NodeUser();

            foreach (var claim in claims)
                user.LoadClaim(claim);

            if (!user.IsValid())
                return null;

            return user;
        }

        private bool IsValid()
        {
            return Id != Guid.Empty;
        }

        private void LoadClaim(Claim claim)
        {
            switch (claim.Type)
            {
                case IdType:
                    Id = Guid.Parse(claim.Value);
                    return;
                case UserNameType:
                    UserName = claim.Value;
                    return;
                case DisplayNameType:
                    DisplayName = claim.Value;
                    return;
                case IdentsType:
                    Idents.AddRange(claim.Value.Split(';'));
                    return;
                default:
                    ExtraClaims.Add(claim);
                    return;
            }
        }
    }
}
