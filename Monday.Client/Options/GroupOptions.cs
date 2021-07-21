using System;

namespace Monday.Client.Options
{
    public interface IGroupOptions : IBaseOptions
    {
        bool IncludeColor { get; set; }
    }
    
    public class GroupOptions : BaseOptions, IGroupOptions
    {
        public bool IncludeColor { get; set; } = false;

        internal override string Build(OptionBuilderMode Mode)
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
