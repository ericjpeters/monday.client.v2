using System;
using System.Linq;

namespace Monday.Client.Options
{
    public interface ICreatorOptions : IBaseOptions
    {
        bool IncludeName { get; set; }
        bool IncludeEmail { get; set; }
    }

    public class CreatorOptions : BaseOptions, ICreatorOptions
    {
        public bool IncludeName { get; set; } = true;
        public bool IncludeEmail { get; set; } = true;

        internal override string Build(OptionBuilderMode mode, (string key, string val)[] attrs = null)
        {
            if (!Include)
                return String.Empty;

            var model = "creator";
            if (mode == OptionBuilderMode.Multiple)
                model = "creators";

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

            return $@"
{model}{attributes} {{
    id {name} {email}
}}";
        }
    }
}
