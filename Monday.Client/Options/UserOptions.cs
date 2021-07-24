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

        internal override string Build(OptionBuilderMode mode, (string key, string val)[] attrs)
        {
            if (!Include)
                return String.Empty;

            var model = "user";
            if (mode == OptionBuilderMode.Multiple)
                model = "users";

            var attributes = String.Empty;
            if (attrs != null)
            {
                attributes = attrs.Aggregate(String.Empty, (_c, _n) => $",{_n.key}:{_n.val}");
                if (attributes.Length > 0)
                    attributes = $"({attributes.Substring(1)})";
            }

            var name = String.Empty;
            if (IncludeName)
                name = "name";

            var email = String.Empty;
            if (IncludeEmail)
                email = "email";

            var url = String.Empty;
            if (IncludeUrl)
                url = "url";

            var photoOriginal = String.Empty;
            if (IncludePhoto)
                photoOriginal = "photo_original";

            var title = String.Empty;
            if (IncludeTitle)
                title = "title";

            var birthday = String.Empty;
            if (IncludeBirthday)
                birthday = "birthday";

            var countryCode = String.Empty;
            if (IncludeCountryCode)
                countryCode = "country_code";

            var location = String.Empty;
            if (IncludeLocation)
                location = "location";

            var timeZoneIdentifier = String.Empty;
            if (IncludeTimeZoneIdentifier)
                timeZoneIdentifier = "time_zone_identifier";

            var phone = String.Empty;
            if (IncludePhone)
                phone = "phone";

            var mobilePhone = String.Empty;
            if (IncludeMobilePhone)
                mobilePhone = "mobile_phone";

            var isGuest = String.Empty;
            if (IncludeIsGuest)
                isGuest = "is_guest";

            var isPending = String.Empty;
            if (IncludeIsPending)
                isPending = "is_pending";

            var enabled = String.Empty;
            if (IncludeIsEnabled)
                enabled = "enabled";

            var createdAt = String.Empty;
            if (IncludeCreatedAt)
                createdAt = "created_at";

            return $@"
{model}{attributes} {{
    id {name} {email} {url} {photoOriginal} {title} {birthday} {countryCode} {location}
    {timeZoneIdentifier} {phone} {mobilePhone} {isGuest} {isPending} {enabled} {createdAt}
}}";
        }
    }
}
