using System;

namespace Monday.Client.Options
{
    public interface IOwnerOptions : IBaseOptions
    {
    }
    
    public class OwnerOptions : BaseOptions, IOwnerOptions
    {
        internal override string Build(OptionBuilderMode mode)
        {
            if (!Include)
                return String.Empty;

            var result = $"id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at";

            switch (mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                case OptionBuilderMode.Multiple:
                    return $@"owners {{ {result} }}";

                default:
                    return $@"owner {{ {result} }}";
            }
        }
    }
}
