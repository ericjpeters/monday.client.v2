using System;

namespace Monday.Client.Options
{
    public interface IGroupOptions : IOptionsBuilder
    {
        bool IncludeColor { get; set; }
    }
    
    public class GroupOptions : OptionsBuilder, IGroupOptions
    {
        public bool IncludeColor { get; set; } = false;

        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            var color = String.Empty;
            if (IncludeColor)
                color = "color";

            var metadata = String.Empty;
            if (IncludeMetadata)
                metadata = "archived deleted";

            return $@"group {{ id title {color} {metadata} }}";
        }
    }
}
