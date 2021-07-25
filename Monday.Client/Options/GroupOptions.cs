namespace Monday.Client.Options
{
    public interface IGroupOptions : IBaseOptions
    {
        bool IncludeTitle { get; set; }
        bool IncludeColor { get; set; }
        bool IncludeIsArchived { get; set; }
        bool IncludeIsDeleted { get; set; }
    }

    public class GroupOptions : BaseOptions, IGroupOptions
    {
        public bool IncludeTitle { get; set; } = true;
        public bool IncludeColor { get; set; } = false;
        public bool IncludeIsArchived { get; set; } = true;
        public bool IncludeIsDeleted { get; set; } = true;

        public GroupOptions()
           : base("group")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var title = GetField(IncludeTitle, "title");
            var color = GetField(IncludeColor, "color");
            var isArchived = GetField(IncludeIsArchived, "archived");
            var isDeleted = GetField(IncludeIsDeleted, "deleted");

            return $@"
{modelName}{modelAttributes} {{
    id {title} {color} {isArchived} {isDeleted}
}}";
        }
    }

    public class TopGroupOptions : GroupOptions
    {
        public TopGroupOptions()
        {
            NameSingular = "top_group";
            NamePlural = "top_group";
        }
    }
}
