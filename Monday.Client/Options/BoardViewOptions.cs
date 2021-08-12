﻿using Monday.Client.Requests;

namespace Monday.Client.Options
{
    public interface IBoardViewOptions : IBaseOptions
    {
        bool IncludeName { get; set; }
        bool IncludeSettings { get; set; }
        bool IncludeType { get; set; }
    }

    public class BoardViewOptions : BaseOptions, IBoardViewOptions
    {
        public bool IncludeName { get; set; }
        public bool IncludeSettings { get; set; }
        public bool IncludeType { get; set; }

        public BoardViewOptions()
            : this(RequestMode.Default)
        {
        }

        public BoardViewOptions(RequestMode mode)
            : base("view")
        {
            switch (mode)
            {
                case RequestMode.Minimum:
                    IncludeName = false;
                    IncludeSettings = false;
                    IncludeType = false;
                    break;

                case RequestMode.Maximum:
                case RequestMode.MaximumChild:
                    IncludeName = true;
                    IncludeSettings = true;
                    IncludeType = true;
                    break;

                case RequestMode.Default:
                default:
                    IncludeName = true;
                    IncludeSettings = true;
                    IncludeType = false;
                    break;

            }
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var name = GetField(IncludeName, "name");
            var settings = GetField(IncludeSettings, "settings_str");
            var type = GetField(IncludeType, "type");

            return $@"
{modelName}{modelAttributes} {{
    id {name} {settings} {type}
}}";
        }
    }
}