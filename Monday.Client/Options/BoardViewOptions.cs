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
        public bool IncludeName { get; set; } = true;
        public bool IncludeSettings { get; set; } = true;
        public bool IncludeType { get; set; } = false;

        public BoardViewOptions()
            : base("view")
        {
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