using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ON.Authentication
{
    public class ONUser : ClaimsPrincipal
    {
        public const string ROLE_ADMIN = "admin";
        public const string ROLE_WRITER = "writer";
        public const string ROLE_PUBLISHER = "publisher";

        public Guid Id { get; set; } = Guid.Empty;
        public const string IdType = "Id";

        public string UserName { get; set; } = "";
        public const string UserNameType = "sub";

        public string DisplayName { get; set; } = "";
        public const string DisplayNameType = "Display";

        public uint SubscriptionLevel { get; set; } = 0;
        public const string SubscriptionLevelType = "SubscriptionLevel";

        public string SubscriptionProvider { get; set; }
        public const string SubscriptionProviderType = "SubscriptionProvider";

        public List<string> Idents { get; private set; } = new List<string>();
        public const string IdentsType = "Idents";

        public List<string> Roles { get; private set; } = new List<string>();
        public const string RolesType = ClaimTypes.Role;
        public bool IsAdmin { get => IsInRole(ROLE_ADMIN); }
        public bool IsPublisher { get => IsInRole(ROLE_PUBLISHER); }
        public bool IsPublisherOrHigher { get => IsPublisher || IsAdmin; }
        public bool IsWriter { get => IsInRole(ROLE_WRITER); }
        public bool IsWriterOrHigher { get => IsWriter || IsPublisherOrHigher; }

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

            foreach (var r in Roles)
                yield return new Claim(RolesType, r);

            foreach (var c in ExtraClaims)
                yield return c;
        }

        public static ONUser Parse(IEnumerable<Claim> claims)
        {
            if (claims == null)
                return null;

            var user = new ONUser();

            foreach (var claim in claims)
                user.LoadClaim(claim);

            if (!user.IsValid())
                return null;

            return user;
        }

        public override bool IsInRole(string role)
        {
            return Roles.Contains(role);
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
                case RolesType:
                    Roles.Add(claim.Value);
                    return;
                case SubscriptionLevelType:
                    if (uint.TryParse(claim.Value, out uint i))
                        SubscriptionLevel = i;
                    return;
                case SubscriptionProviderType:
                    SubscriptionProvider = claim.Value;
                    return;
                default:
                    ExtraClaims.Add(claim);
                    return;
            }
        }
    }
}
