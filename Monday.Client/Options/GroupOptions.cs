using System;

namespace Monday.Client.Options
{
    public interface IGroupOptions : IBaseOptions
    {
        bool IncludeColor { get; set; }
        bool IncludeIsArchived { get; set; }
        bool IncludeIsDeleted { get; set; }
    }

    public class GroupOptions : BaseOptions, IGroupOptions
    {
        public bool IncludeColor { get; set; } = false;
        public bool IncludeIsArchived { get; set; } = true;
        public bool IncludeIsDeleted { get; set; } = true;

        internal override string Build(OptionBuilderMode mode, (string key, string val)[] attrs)
        {
            if (!Include)
                return String.Empty;

            var color = String.Empty;
            if (IncludeColor)
                color = "color";

            var archived = String.Empty;
            if (IncludeIsArchived)
                archived = "archived";

            var deleted = String.Empty;
            if (IncludeIsDeleted)
                deleted = "deleted";

            var result = $"id title {color} {archived} {deleted}";

            switch (mode)
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
