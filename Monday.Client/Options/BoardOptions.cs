using System;
using System.Linq;

namespace Monday.Client.Options
{
    public interface IBoardOptions : IBaseOptions
    {
        bool IncludeName { get; set; }
        bool IncludeDescription { get; set; }
        bool IncludeBoardAccessType { get; set; }
        bool IncludeBoardStateType { get; set; }
        bool IncludeBoardFolderId { get; set; }
        bool IncludeColumns { get; set; }
        bool IncludePermissions { get; set; }

        ColumnOptions ColumnOptions { get; set; }
    }

    public class BoardOptions : BaseOptions, IBoardOptions
    {
        public bool IncludeName { get; set; } = true;
        public bool IncludeDescription { get; set; } = true;
        public bool IncludeBoardAccessType { get; set; } = true;
        public bool IncludeBoardStateType { get; set; } = false;
        public bool IncludeBoardFolderId { get; set; } = false;
        public bool IncludeColumns { get; set; } = false;
        public bool IncludePermissions { get; set; } = false;

        public ColumnOptions ColumnOptions { get; set; } = new ColumnOptions();

        public BoardOptions()
            : base("board")
        { 
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var name = GetField(IncludeName, "name");
            var description = GetField(IncludeDescription, "description");
            var boardAccessType = GetField(IncludeBoardAccessType, "board_kind");
            var boardStateType = GetField(IncludeBoardStateType, "state");
            var boardFolderId = GetField(IncludeBoardFolderId, "board_folder_id");
            var permissions = GetField(IncludePermissions, "permissions");
            
            var columns = GetField(IncludeColumns, ColumnOptions.Build(OptionBuilderMode.Multiple));

            return $@"
{modelName}{modelAttributes} {{
    id {name} {description} {boardAccessType} {boardStateType} {boardFolderId} {permissions} {columns}
}}";
        }
    }
}
