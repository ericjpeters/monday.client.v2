namespace Monday.Client.Options
{
    public interface IWorkspaceOptions : IBaseOptions
    {
    }

    public class WorkspaceOptions : BaseOptions, IWorkspaceOptions
    {
        public WorkspaceOptions()
            : base("workspace")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            return $@"
{modelName}{modelAttributes} {{
    id 
}}";
        }
    }
}