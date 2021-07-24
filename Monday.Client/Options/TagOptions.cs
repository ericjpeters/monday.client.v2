using System;

namespace Monday.Client.Options
{
    public interface ITagOptions : IBaseOptions
    {
        bool IncludeName { get; set; }
        bool IncludeColor { get; set; }
    }

    public class TagOptions : BaseOptions, ITagOptions
    {
        public bool IncludeName { get; set; } = true;
        public bool IncludeColor { get; set; } = true;

        public TagOptions()
           : base("tag")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var name = GetField(IncludeName, "name");
            var color = GetField(IncludeColor, "color");

            return $@"
{modelName}{modelAttributes} {{
    id {name} {color}
}}";
        }
    }
}
