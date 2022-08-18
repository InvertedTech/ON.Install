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
        public const string ROLE_OWNER = "owner";
        public const string ROLE_ADMIN = "admin";
        public const string ROLE_BACKUP = "backup";
        public const string ROLE_OPS = "ops";
        public const string ROLE_CONTENT_PUBLISHER = "con_publisher";
        public const string ROLE_CONTENT_WRITER = "con_writer";
        public const string ROLE_COMMENT_MODERATOR = "com_mod";
        public const string ROLE_COMMENT_APPELLATE_JUDGE = "com_appellate";

        public const string ROLE_CAN_BACKUP = ROLE_OWNER + "," + ROLE_BACKUP;
        public const string ROLE_CAN_CREATE_CONTENT = ROLE_CAN_PUBLISH + "," + ROLE_CONTENT_WRITER;
        public const string ROLE_CAN_PUBLISH = ROLE_IS_ADMIN_OR_OWNER + "," + ROLE_CONTENT_PUBLISHER;
        public const string ROLE_IS_ADMIN_OR_OWNER = ROLE_OWNER + "," + ROLE_ADMIN;

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

        public bool IsBackup { get => IsInRole(ROLE_BACKUP); }
        public bool IsOwner { get => IsInRole(ROLE_OWNER); }
        public bool IsAdmin { get => IsInRole(ROLE_ADMIN); }
        public bool IsAdminOrHigher { get => IsAdmin || IsOwner; }
        public bool IsPublisher { get => IsInRole(ROLE_CONTENT_PUBLISHER); }
        public bool IsPublisherOrHigher { get => IsPublisher || IsAdminOrHigher; }
        public bool IsWriter { get => IsInRole(ROLE_CONTENT_WRITER); }
        public bool IsWriterOrHigher { get => IsWriter || IsPublisherOrHigher; }

        public bool CanPublish { get => IsPublisherOrHigher; }
        public bool CanCreateContent { get => IsWriterOrHigher; }

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
            return true;// Id != Guid.Empty;
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
