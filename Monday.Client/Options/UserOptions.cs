using System;
using System.Linq;

namespace Monday.Client.Options
{
    public interface IUserOptions : IBaseOptions
    {
        bool IncludeName { get; set; }
        bool IncludeEmail { get; set; }
        bool IncludeUrl { get; set; }
        bool IncludePhoto { get; set; }
        bool IncludeTitle { get; set; }
        bool IncludeBirthday { get; set; }
        bool IncludeCountryCode { get; set; }
        bool IncludeLocation { get; set; }
        bool IncludeTimeZoneIdentifier { get; set; }
        bool IncludePhone { get; set; }
        bool IncludeMobilePhone { get; set; }
        bool IncludeIsGuest { get; set; }
        bool IncludeIsPending { get; set; }
        bool IncludeIsEnabled { get; set; }
        bool IncludeCreatedAt { get; set; }
    }

    public class UserOptions : BaseOptions, IUserOptions
    {
        public bool IncludeName { get; set; } = true;
        public bool IncludeEmail { get; set; } = true;
        public bool IncludeUrl { get; set; } = true;
        public bool IncludePhoto { get; set; } = true;
        public bool IncludeTitle { get; set; } = true;
        public bool IncludeBirthday { get; set; } = true;
        public bool IncludeCountryCode { get; set; } = true;
        public bool IncludeLocation { get; set; } = true;
        public bool IncludeTimeZoneIdentifier { get; set; } = true;
        public bool IncludePhone { get; set; } = true;
        public bool IncludeMobilePhone { get; set; } = true;
        public bool IncludeIsGuest { get; set; } = true;
        public bool IncludeIsPending { get; set; } = true;
        public bool IncludeIsEnabled { get; set; } = true;
        public bool IncludeCreatedAt { get; set; } = true;

        public UserOptions()
            : base("user")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var name = GetField(IncludeName, "name");
            var email = GetField(IncludeEmail, "email");
            var url = GetField(IncludeUrl, "url");
            var photo = GetField(IncludePhoto, "photo_original");
            var title = GetField(IncludeTitle, "title");
            var birthday = GetField(IncludeBirthday, "birthday");
            var countryCode = GetField(IncludeCountryCode, "country_code");
            var location = GetField(IncludeLocation, "location");
            var timeZoneIdentifier = GetField(IncludeTimeZoneIdentifier, "time_zone_identifier");
            var phone = GetField(IncludePhone, "phone");
            var mobilePhone = GetField(IncludeMobilePhone, "mobile_phone");
            var isGuest = GetField(IncludeIsGuest, "is_guest");
            var isPending = GetField(IncludeIsPending, "is_pending");
            var enabled = GetField(IncludeIsEnabled, "enabled");
            var createdAt = GetField(IncludeCreatedAt,"created_at");

            return $@"
{modelName}{modelAttributes} {{
    id {name} {email} {url} {photo} {title} {birthday} {countryCode} {location}
    {timeZoneIdentifier} {phone} {mobilePhone} {isGuest} {isPending} {enabled} {createdAt}
}}";
        }
    }

    public class CreatorOptions : UserOptions {
        public CreatorOptions()
        {
            NameSingular = "creator";
            NamePlural = "creators";
        }
    }

    public class SubscriberOptions : UserOptions
    {
        public SubscriberOptions()
        {
            NameSingular = "subscriber";
            NamePlural = "subscribers";
        }
    }
}
