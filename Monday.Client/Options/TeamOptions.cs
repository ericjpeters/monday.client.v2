using System;

namespace Monday.Client.Options
{
    public interface ITeamOptions : IBaseOptions
    {
        bool IncludeName { get; set; }
        bool IncludePhoto { get; set; }
        bool IncludeUsers { get; set; }

        UserOptions UserOptions { get; set; }
    }

    public class TeamOptions : BaseOptions, ITeamOptions
    {
        public bool IncludeName { get; set; } = true;
        public bool IncludePhoto { get; set; } = true;
        public bool IncludeUsers { get; set; } = false;

        public UserOptions UserOptions { get; set; } = new UserOptions();

        public TeamOptions()
           : base("team")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var name = GetField(IncludeName, "name");
            var photo = GetField(IncludePhoto, "picture_url");

            var users = GetField(IncludeUsers, UserOptions.Build(OptionBuilderMode.Multiple));

            return $@"
{modelName}{modelAttributes} {{
    id {name} {photo} {users}
}}";
        }
    }
}
