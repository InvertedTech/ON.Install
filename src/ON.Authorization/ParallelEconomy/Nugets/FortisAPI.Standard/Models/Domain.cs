// <copyright file="Domain.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Domain.
    /// </summary>
    public class Domain : BaseModel
    {
        private string logo;
        private string supportEmail;
        private string companyName;
        private string navColor;
        private string buttonPrimaryColor;
        private string logoBackgroundColor;
        private string iconBackgroundColor;
        private string menuTextBackgroundColor;
        private string menuTextColor;
        private string rightMenuBackgroundColor;
        private string rightMenuTextColor;
        private string buttonPrimaryTextColor;
        private string navLogo;
        private string favIcon;
        private string aesKey;
        private string helpText;
        private string emailReplyTo;
        private string email;
        private string customJavascript;
        private string customTheme;
        private string customCss;
        private Models.ContactUserDefaultEntryPageEnum? contactUserDefaultEntryPage;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "logo", false },
            { "support_email", false },
            { "company_name", false },
            { "nav_color", false },
            { "button_primary_color", false },
            { "logo_background_color", false },
            { "icon_background_color", false },
            { "menu_text_background_color", false },
            { "menu_text_color", false },
            { "right_menu_background_color", false },
            { "right_menu_text_color", false },
            { "button_primary_text_color", false },
            { "nav_logo", false },
            { "fav_icon", false },
            { "aes_key", false },
            { "help_text", false },
            { "email_reply_to", false },
            { "email", false },
            { "custom_javascript", false },
            { "custom_theme", false },
            { "custom_css", false },
            { "contact_user_default_entry_page", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Domain"/> class.
        /// </summary>
        public Domain()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Domain"/> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="title">title.</param>
        /// <param name="allowContactSignup">allow_contact_signup.</param>
        /// <param name="allowContactRegistration">allow_contact_registration.</param>
        /// <param name="allowContactLogin">allow_contact_login.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="logo">logo.</param>
        /// <param name="supportEmail">support_email.</param>
        /// <param name="registrationFields">registration_fields.</param>
        /// <param name="companyName">company_name.</param>
        /// <param name="navColor">nav_color.</param>
        /// <param name="buttonPrimaryColor">button_primary_color.</param>
        /// <param name="logoBackgroundColor">logo_background_color.</param>
        /// <param name="iconBackgroundColor">icon_background_color.</param>
        /// <param name="menuTextBackgroundColor">menu_text_background_color.</param>
        /// <param name="menuTextColor">menu_text_color.</param>
        /// <param name="rightMenuBackgroundColor">right_menu_background_color.</param>
        /// <param name="rightMenuTextColor">right_menu_text_color.</param>
        /// <param name="buttonPrimaryTextColor">button_primary_text_color.</param>
        /// <param name="navLogo">nav_logo.</param>
        /// <param name="favIcon">fav_icon.</param>
        /// <param name="aesKey">aes_key.</param>
        /// <param name="helpText">help_text.</param>
        /// <param name="emailReplyTo">email_reply_to.</param>
        /// <param name="email">email.</param>
        /// <param name="customJavascript">custom_javascript.</param>
        /// <param name="customTheme">custom_theme.</param>
        /// <param name="customCss">custom_css.</param>
        /// <param name="contactUserDefaultEntryPage">contact_user_default_entry_page.</param>
        /// <param name="contactUserDefaultAuthRoles">contact_user_default_auth_roles.</param>
        public Domain(
            string url,
            string title,
            bool allowContactSignup,
            bool allowContactRegistration,
            bool allowContactLogin,
            string id,
            int createdTs,
            int modifiedTs,
            string logo = null,
            string supportEmail = null,
            List<Models.RegistrationFieldEnum> registrationFields = null,
            string companyName = null,
            string navColor = null,
            string buttonPrimaryColor = null,
            string logoBackgroundColor = null,
            string iconBackgroundColor = null,
            string menuTextBackgroundColor = null,
            string menuTextColor = null,
            string rightMenuBackgroundColor = null,
            string rightMenuTextColor = null,
            string buttonPrimaryTextColor = null,
            string navLogo = null,
            string favIcon = null,
            string aesKey = null,
            string helpText = null,
            string emailReplyTo = null,
            string email = null,
            string customJavascript = null,
            string customTheme = null,
            string customCss = null,
            Models.ContactUserDefaultEntryPageEnum? contactUserDefaultEntryPage = null,
            object contactUserDefaultAuthRoles = null)
        {
            this.Url = url;
            this.Title = title;
            if (logo != null)
            {
                this.Logo = logo;
            }

            if (supportEmail != null)
            {
                this.SupportEmail = supportEmail;
            }

            this.AllowContactSignup = allowContactSignup;
            this.AllowContactRegistration = allowContactRegistration;
            this.AllowContactLogin = allowContactLogin;
            this.RegistrationFields = registrationFields;
            if (companyName != null)
            {
                this.CompanyName = companyName;
            }

            if (navColor != null)
            {
                this.NavColor = navColor;
            }

            if (buttonPrimaryColor != null)
            {
                this.ButtonPrimaryColor = buttonPrimaryColor;
            }

            if (logoBackgroundColor != null)
            {
                this.LogoBackgroundColor = logoBackgroundColor;
            }

            if (iconBackgroundColor != null)
            {
                this.IconBackgroundColor = iconBackgroundColor;
            }

            if (menuTextBackgroundColor != null)
            {
                this.MenuTextBackgroundColor = menuTextBackgroundColor;
            }

            if (menuTextColor != null)
            {
                this.MenuTextColor = menuTextColor;
            }

            if (rightMenuBackgroundColor != null)
            {
                this.RightMenuBackgroundColor = rightMenuBackgroundColor;
            }

            if (rightMenuTextColor != null)
            {
                this.RightMenuTextColor = rightMenuTextColor;
            }

            if (buttonPrimaryTextColor != null)
            {
                this.ButtonPrimaryTextColor = buttonPrimaryTextColor;
            }

            if (navLogo != null)
            {
                this.NavLogo = navLogo;
            }

            if (favIcon != null)
            {
                this.FavIcon = favIcon;
            }

            if (aesKey != null)
            {
                this.AesKey = aesKey;
            }

            if (helpText != null)
            {
                this.HelpText = helpText;
            }

            if (emailReplyTo != null)
            {
                this.EmailReplyTo = emailReplyTo;
            }

            if (email != null)
            {
                this.Email = email;
            }

            if (customJavascript != null)
            {
                this.CustomJavascript = customJavascript;
            }

            if (customTheme != null)
            {
                this.CustomTheme = customTheme;
            }

            if (customCss != null)
            {
                this.CustomCss = customCss;
            }

            if (contactUserDefaultEntryPage != null)
            {
                this.ContactUserDefaultEntryPage = contactUserDefaultEntryPage;
            }

            this.ContactUserDefaultAuthRoles = contactUserDefaultAuthRoles;
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
        }

        /// <summary>
        /// URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Domain Name
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        [JsonProperty("logo")]
        public string Logo
        {
            get
            {
                return this.logo;
            }

            set
            {
                this.shouldSerialize["logo"] = true;
                this.logo = value;
            }
        }

        /// <summary>
        /// Support Email
        /// </summary>
        [JsonProperty("support_email")]
        public string SupportEmail
        {
            get
            {
                return this.supportEmail;
            }

            set
            {
                this.shouldSerialize["support_email"] = true;
                this.supportEmail = value;
            }
        }

        /// <summary>
        /// Allow Contact Signup.
        /// </summary>
        [JsonProperty("allow_contact_signup")]
        public bool AllowContactSignup { get; set; }

        /// <summary>
        /// Allow Contact Registration.
        /// </summary>
        [JsonProperty("allow_contact_registration")]
        public bool AllowContactRegistration { get; set; }

        /// <summary>
        /// Allow Contact Login.
        /// </summary>
        [JsonProperty("allow_contact_login")]
        public bool AllowContactLogin { get; set; }

        /// <summary>
        /// Registration Fields
        /// </summary>
        [JsonProperty("registration_fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.RegistrationFieldEnum> RegistrationFields { get; set; }

        /// <summary>
        /// Company Name.
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName
        {
            get
            {
                return this.companyName;
            }

            set
            {
                this.shouldSerialize["company_name"] = true;
                this.companyName = value;
            }
        }

        /// <summary>
        /// Nav Color.
        /// </summary>
        [JsonProperty("nav_color")]
        public string NavColor
        {
            get
            {
                return this.navColor;
            }

            set
            {
                this.shouldSerialize["nav_color"] = true;
                this.navColor = value;
            }
        }

        /// <summary>
        /// Button Primary Color.
        /// </summary>
        [JsonProperty("button_primary_color")]
        public string ButtonPrimaryColor
        {
            get
            {
                return this.buttonPrimaryColor;
            }

            set
            {
                this.shouldSerialize["button_primary_color"] = true;
                this.buttonPrimaryColor = value;
            }
        }

        /// <summary>
        /// Logo Background Color.
        /// </summary>
        [JsonProperty("logo_background_color")]
        public string LogoBackgroundColor
        {
            get
            {
                return this.logoBackgroundColor;
            }

            set
            {
                this.shouldSerialize["logo_background_color"] = true;
                this.logoBackgroundColor = value;
            }
        }

        /// <summary>
        /// Icon Background Color.
        /// </summary>
        [JsonProperty("icon_background_color")]
        public string IconBackgroundColor
        {
            get
            {
                return this.iconBackgroundColor;
            }

            set
            {
                this.shouldSerialize["icon_background_color"] = true;
                this.iconBackgroundColor = value;
            }
        }

        /// <summary>
        /// Menu Text Background Color
        /// </summary>
        [JsonProperty("menu_text_background_color")]
        public string MenuTextBackgroundColor
        {
            get
            {
                return this.menuTextBackgroundColor;
            }

            set
            {
                this.shouldSerialize["menu_text_background_color"] = true;
                this.menuTextBackgroundColor = value;
            }
        }

        /// <summary>
        /// Menu Text Color.
        /// </summary>
        [JsonProperty("menu_text_color")]
        public string MenuTextColor
        {
            get
            {
                return this.menuTextColor;
            }

            set
            {
                this.shouldSerialize["menu_text_color"] = true;
                this.menuTextColor = value;
            }
        }

        /// <summary>
        /// Right Menu Background Color.
        /// </summary>
        [JsonProperty("right_menu_background_color")]
        public string RightMenuBackgroundColor
        {
            get
            {
                return this.rightMenuBackgroundColor;
            }

            set
            {
                this.shouldSerialize["right_menu_background_color"] = true;
                this.rightMenuBackgroundColor = value;
            }
        }

        /// <summary>
        /// Right Menu Text Color.
        /// </summary>
        [JsonProperty("right_menu_text_color")]
        public string RightMenuTextColor
        {
            get
            {
                return this.rightMenuTextColor;
            }

            set
            {
                this.shouldSerialize["right_menu_text_color"] = true;
                this.rightMenuTextColor = value;
            }
        }

        /// <summary>
        /// Button Primary Text Color.
        /// </summary>
        [JsonProperty("button_primary_text_color")]
        public string ButtonPrimaryTextColor
        {
            get
            {
                return this.buttonPrimaryTextColor;
            }

            set
            {
                this.shouldSerialize["button_primary_text_color"] = true;
                this.buttonPrimaryTextColor = value;
            }
        }

        /// <summary>
        /// Nav Logo.
        /// </summary>
        [JsonProperty("nav_logo")]
        public string NavLogo
        {
            get
            {
                return this.navLogo;
            }

            set
            {
                this.shouldSerialize["nav_logo"] = true;
                this.navLogo = value;
            }
        }

        /// <summary>
        /// Fav Icon.
        /// </summary>
        [JsonProperty("fav_icon")]
        public string FavIcon
        {
            get
            {
                return this.favIcon;
            }

            set
            {
                this.shouldSerialize["fav_icon"] = true;
                this.favIcon = value;
            }
        }

        /// <summary>
        /// Aes Key.
        /// </summary>
        [JsonProperty("aes_key")]
        public string AesKey
        {
            get
            {
                return this.aesKey;
            }

            set
            {
                this.shouldSerialize["aes_key"] = true;
                this.aesKey = value;
            }
        }

        /// <summary>
        /// Help Text.
        /// </summary>
        [JsonProperty("help_text")]
        public string HelpText
        {
            get
            {
                return this.helpText;
            }

            set
            {
                this.shouldSerialize["help_text"] = true;
                this.helpText = value;
            }
        }

        /// <summary>
        /// Email Reply To.
        /// </summary>
        [JsonProperty("email_reply_to")]
        public string EmailReplyTo
        {
            get
            {
                return this.emailReplyTo;
            }

            set
            {
                this.shouldSerialize["email_reply_to"] = true;
                this.emailReplyTo = value;
            }
        }

        /// <summary>
        /// Email.
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.shouldSerialize["email"] = true;
                this.email = value;
            }
        }

        /// <summary>
        /// Custom Javascript.
        /// </summary>
        [JsonProperty("custom_javascript")]
        public string CustomJavascript
        {
            get
            {
                return this.customJavascript;
            }

            set
            {
                this.shouldSerialize["custom_javascript"] = true;
                this.customJavascript = value;
            }
        }

        /// <summary>
        /// Custom Theme
        /// </summary>
        [JsonProperty("custom_theme")]
        public string CustomTheme
        {
            get
            {
                return this.customTheme;
            }

            set
            {
                this.shouldSerialize["custom_theme"] = true;
                this.customTheme = value;
            }
        }

        /// <summary>
        /// Custom CSS
        /// </summary>
        [JsonProperty("custom_css")]
        public string CustomCss
        {
            get
            {
                return this.customCss;
            }

            set
            {
                this.shouldSerialize["custom_css"] = true;
                this.customCss = value;
            }
        }

        /// <summary>
        /// Contact User Default Entry Page
        /// </summary>
        [JsonProperty("contact_user_default_entry_page")]
        public Models.ContactUserDefaultEntryPageEnum? ContactUserDefaultEntryPage
        {
            get
            {
                return this.contactUserDefaultEntryPage;
            }

            set
            {
                this.shouldSerialize["contact_user_default_entry_page"] = true;
                this.contactUserDefaultEntryPage = value;
            }
        }

        /// <summary>
        /// Contact User Default Auth Role
        /// </summary>
        [JsonProperty("contact_user_default_auth_roles", NullValueHandling = NullValueHandling.Ignore)]
        public object ContactUserDefaultAuthRoles { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Domain : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLogo()
        {
            this.shouldSerialize["logo"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSupportEmail()
        {
            this.shouldSerialize["support_email"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCompanyName()
        {
            this.shouldSerialize["company_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNavColor()
        {
            this.shouldSerialize["nav_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetButtonPrimaryColor()
        {
            this.shouldSerialize["button_primary_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLogoBackgroundColor()
        {
            this.shouldSerialize["logo_background_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetIconBackgroundColor()
        {
            this.shouldSerialize["icon_background_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMenuTextBackgroundColor()
        {
            this.shouldSerialize["menu_text_background_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMenuTextColor()
        {
            this.shouldSerialize["menu_text_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRightMenuBackgroundColor()
        {
            this.shouldSerialize["right_menu_background_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetRightMenuTextColor()
        {
            this.shouldSerialize["right_menu_text_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetButtonPrimaryTextColor()
        {
            this.shouldSerialize["button_primary_text_color"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNavLogo()
        {
            this.shouldSerialize["nav_logo"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFavIcon()
        {
            this.shouldSerialize["fav_icon"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetAesKey()
        {
            this.shouldSerialize["aes_key"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetHelpText()
        {
            this.shouldSerialize["help_text"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmailReplyTo()
        {
            this.shouldSerialize["email_reply_to"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetEmail()
        {
            this.shouldSerialize["email"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCustomJavascript()
        {
            this.shouldSerialize["custom_javascript"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCustomTheme()
        {
            this.shouldSerialize["custom_theme"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCustomCss()
        {
            this.shouldSerialize["custom_css"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContactUserDefaultEntryPage()
        {
            this.shouldSerialize["contact_user_default_entry_page"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLogo()
        {
            return this.shouldSerialize["logo"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSupportEmail()
        {
            return this.shouldSerialize["support_email"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCompanyName()
        {
            return this.shouldSerialize["company_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNavColor()
        {
            return this.shouldSerialize["nav_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeButtonPrimaryColor()
        {
            return this.shouldSerialize["button_primary_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLogoBackgroundColor()
        {
            return this.shouldSerialize["logo_background_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIconBackgroundColor()
        {
            return this.shouldSerialize["icon_background_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMenuTextBackgroundColor()
        {
            return this.shouldSerialize["menu_text_background_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMenuTextColor()
        {
            return this.shouldSerialize["menu_text_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRightMenuBackgroundColor()
        {
            return this.shouldSerialize["right_menu_background_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRightMenuTextColor()
        {
            return this.shouldSerialize["right_menu_text_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeButtonPrimaryTextColor()
        {
            return this.shouldSerialize["button_primary_text_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNavLogo()
        {
            return this.shouldSerialize["nav_logo"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFavIcon()
        {
            return this.shouldSerialize["fav_icon"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAesKey()
        {
            return this.shouldSerialize["aes_key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHelpText()
        {
            return this.shouldSerialize["help_text"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmailReplyTo()
        {
            return this.shouldSerialize["email_reply_to"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmail()
        {
            return this.shouldSerialize["email"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomJavascript()
        {
            return this.shouldSerialize["custom_javascript"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomTheme()
        {
            return this.shouldSerialize["custom_theme"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomCss()
        {
            return this.shouldSerialize["custom_css"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContactUserDefaultEntryPage()
        {
            return this.shouldSerialize["contact_user_default_entry_page"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is Domain other &&                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Logo == null && other.Logo == null) || (this.Logo?.Equals(other.Logo) == true)) &&
                ((this.SupportEmail == null && other.SupportEmail == null) || (this.SupportEmail?.Equals(other.SupportEmail) == true)) &&
                this.AllowContactSignup.Equals(other.AllowContactSignup) &&
                this.AllowContactRegistration.Equals(other.AllowContactRegistration) &&
                this.AllowContactLogin.Equals(other.AllowContactLogin) &&
                ((this.RegistrationFields == null && other.RegistrationFields == null) || (this.RegistrationFields?.Equals(other.RegistrationFields) == true)) &&
                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true)) &&
                ((this.NavColor == null && other.NavColor == null) || (this.NavColor?.Equals(other.NavColor) == true)) &&
                ((this.ButtonPrimaryColor == null && other.ButtonPrimaryColor == null) || (this.ButtonPrimaryColor?.Equals(other.ButtonPrimaryColor) == true)) &&
                ((this.LogoBackgroundColor == null && other.LogoBackgroundColor == null) || (this.LogoBackgroundColor?.Equals(other.LogoBackgroundColor) == true)) &&
                ((this.IconBackgroundColor == null && other.IconBackgroundColor == null) || (this.IconBackgroundColor?.Equals(other.IconBackgroundColor) == true)) &&
                ((this.MenuTextBackgroundColor == null && other.MenuTextBackgroundColor == null) || (this.MenuTextBackgroundColor?.Equals(other.MenuTextBackgroundColor) == true)) &&
                ((this.MenuTextColor == null && other.MenuTextColor == null) || (this.MenuTextColor?.Equals(other.MenuTextColor) == true)) &&
                ((this.RightMenuBackgroundColor == null && other.RightMenuBackgroundColor == null) || (this.RightMenuBackgroundColor?.Equals(other.RightMenuBackgroundColor) == true)) &&
                ((this.RightMenuTextColor == null && other.RightMenuTextColor == null) || (this.RightMenuTextColor?.Equals(other.RightMenuTextColor) == true)) &&
                ((this.ButtonPrimaryTextColor == null && other.ButtonPrimaryTextColor == null) || (this.ButtonPrimaryTextColor?.Equals(other.ButtonPrimaryTextColor) == true)) &&
                ((this.NavLogo == null && other.NavLogo == null) || (this.NavLogo?.Equals(other.NavLogo) == true)) &&
                ((this.FavIcon == null && other.FavIcon == null) || (this.FavIcon?.Equals(other.FavIcon) == true)) &&
                ((this.AesKey == null && other.AesKey == null) || (this.AesKey?.Equals(other.AesKey) == true)) &&
                ((this.HelpText == null && other.HelpText == null) || (this.HelpText?.Equals(other.HelpText) == true)) &&
                ((this.EmailReplyTo == null && other.EmailReplyTo == null) || (this.EmailReplyTo?.Equals(other.EmailReplyTo) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.CustomJavascript == null && other.CustomJavascript == null) || (this.CustomJavascript?.Equals(other.CustomJavascript) == true)) &&
                ((this.CustomTheme == null && other.CustomTheme == null) || (this.CustomTheme?.Equals(other.CustomTheme) == true)) &&
                ((this.CustomCss == null && other.CustomCss == null) || (this.CustomCss?.Equals(other.CustomCss) == true)) &&
                ((this.ContactUserDefaultEntryPage == null && other.ContactUserDefaultEntryPage == null) || (this.ContactUserDefaultEntryPage?.Equals(other.ContactUserDefaultEntryPage) == true)) &&
                ((this.ContactUserDefaultAuthRoles == null && other.ContactUserDefaultAuthRoles == null) || (this.ContactUserDefaultAuthRoles?.Equals(other.ContactUserDefaultAuthRoles) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Url = {(this.Url == null ? "null" : this.Url)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.Logo = {(this.Logo == null ? "null" : this.Logo)}");
            toStringOutput.Add($"this.SupportEmail = {(this.SupportEmail == null ? "null" : this.SupportEmail)}");
            toStringOutput.Add($"this.AllowContactSignup = {this.AllowContactSignup}");
            toStringOutput.Add($"this.AllowContactRegistration = {this.AllowContactRegistration}");
            toStringOutput.Add($"this.AllowContactLogin = {this.AllowContactLogin}");
            toStringOutput.Add($"this.RegistrationFields = {(this.RegistrationFields == null ? "null" : $"[{string.Join(", ", this.RegistrationFields)} ]")}");
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName)}");
            toStringOutput.Add($"this.NavColor = {(this.NavColor == null ? "null" : this.NavColor)}");
            toStringOutput.Add($"this.ButtonPrimaryColor = {(this.ButtonPrimaryColor == null ? "null" : this.ButtonPrimaryColor)}");
            toStringOutput.Add($"this.LogoBackgroundColor = {(this.LogoBackgroundColor == null ? "null" : this.LogoBackgroundColor)}");
            toStringOutput.Add($"this.IconBackgroundColor = {(this.IconBackgroundColor == null ? "null" : this.IconBackgroundColor)}");
            toStringOutput.Add($"this.MenuTextBackgroundColor = {(this.MenuTextBackgroundColor == null ? "null" : this.MenuTextBackgroundColor)}");
            toStringOutput.Add($"this.MenuTextColor = {(this.MenuTextColor == null ? "null" : this.MenuTextColor)}");
            toStringOutput.Add($"this.RightMenuBackgroundColor = {(this.RightMenuBackgroundColor == null ? "null" : this.RightMenuBackgroundColor)}");
            toStringOutput.Add($"this.RightMenuTextColor = {(this.RightMenuTextColor == null ? "null" : this.RightMenuTextColor)}");
            toStringOutput.Add($"this.ButtonPrimaryTextColor = {(this.ButtonPrimaryTextColor == null ? "null" : this.ButtonPrimaryTextColor)}");
            toStringOutput.Add($"this.NavLogo = {(this.NavLogo == null ? "null" : this.NavLogo)}");
            toStringOutput.Add($"this.FavIcon = {(this.FavIcon == null ? "null" : this.FavIcon)}");
            toStringOutput.Add($"this.AesKey = {(this.AesKey == null ? "null" : this.AesKey)}");
            toStringOutput.Add($"this.HelpText = {(this.HelpText == null ? "null" : this.HelpText)}");
            toStringOutput.Add($"this.EmailReplyTo = {(this.EmailReplyTo == null ? "null" : this.EmailReplyTo)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");
            toStringOutput.Add($"this.CustomJavascript = {(this.CustomJavascript == null ? "null" : this.CustomJavascript)}");
            toStringOutput.Add($"this.CustomTheme = {(this.CustomTheme == null ? "null" : this.CustomTheme)}");
            toStringOutput.Add($"this.CustomCss = {(this.CustomCss == null ? "null" : this.CustomCss)}");
            toStringOutput.Add($"this.ContactUserDefaultEntryPage = {(this.ContactUserDefaultEntryPage == null ? "null" : this.ContactUserDefaultEntryPage.ToString())}");
            toStringOutput.Add($"ContactUserDefaultAuthRoles = {(this.ContactUserDefaultAuthRoles == null ? "null" : this.ContactUserDefaultAuthRoles.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");

            base.ToString(toStringOutput);
        }
    }
}