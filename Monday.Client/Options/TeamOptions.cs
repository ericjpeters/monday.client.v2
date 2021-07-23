using System;

namespace Monday.Client.Options
{
    public interface ITeamOptions : IBaseOptions
    {
    }
    
    public class TeamOptions : BaseOptions, ITeamOptions
    {
        internal override string Build(OptionBuilderMode mode)
        {
            if (!Include)
                return String.Empty;

            var result = $"id name picture_url";

            switch (mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                case OptionBuilderMode.Multiple:
                    return $@"teams {{ {result} }}";

                default:
                    return $@"team {{ {result} }}";
            }
        }
    }
}
