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

            var result = $"id title {color} {metadata}";

            switch (Mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                case OptionBuilderMode.Multiple:
                    return $@"groups {{ {result} }}";

                default:
                    return $@"group {{ {result} }}";
            }
        }
    }
}
