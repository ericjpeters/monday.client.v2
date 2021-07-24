using System;

namespace Monday.Client.Options
{
    public interface ITeamOptions : IBaseOptions
    {
    }
    
    public class TeamOptions : BaseOptions, ITeamOptions
    {
        public TeamOptions()
           : base("team", "teams")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
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
