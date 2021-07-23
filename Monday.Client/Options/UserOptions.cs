using System;

namespace Monday.Client.Options
{
    public interface IUserOptions : IBaseOptions
    {
        bool IncludeUrl { get; set; }
        bool IncludePhotoOriginal { get; set; }
        bool IncludeTitle { get; set; }
        bool IncludeBirthday { get; set; }
        bool IncludeCountryCode { get; set; }
        bool IncludeLocation { get; set; }
        bool IncludeTimeZoneIdentifier { get; set; }
        bool IncludePhone { get; set; }
        bool IncludeMobilePhone { get; set; }
        bool IncludeMetadata { get; set; }
    }

    public class UserOptions : BaseOptions, IUserOptions
    {
        public bool IncludeUrl { get; set; } = true;
        public bool IncludePhotoOriginal { get; set; } = true;
        public bool IncludeTitle { get; set; } = true;
        public bool IncludeBirthday { get; set; } = true;
        public bool IncludeCountryCode { get; set; } = true;
        public bool IncludeLocation { get; set; } = true;
        public bool IncludeTimeZoneIdentifier { get; set; } = true;
        public bool IncludePhone { get; set; } = true;
        public bool IncludeMobilePhone { get; set; } = true;
        public bool IncludeMetadata { get; set; } = true;

        internal override string Build(OptionBuilderMode mode)
        {
            if (!Include)
                return String.Empty;

            var url = String.Empty;
            if (IncludeUrl)
                url = "url";

            var photoOriginal = String.Empty;
            if (IncludePhotoOriginal)
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

            var metadata = String.Empty;
            if (IncludeMetadata)
                metadata = "is_guest is_pending enabled created_at";

            var result = $"id name email {url} {photoOriginal} {title} {birthday} {countryCode} {location} {timeZoneIdentifier} {phone} {mobilePhone} {metadata}";

            switch (mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                case OptionBuilderMode.Multiple:
                    return $@"users {{ {result} }}";

                default:
                    return $@"user {{ {result} }}";
            }
        }
    }
}
