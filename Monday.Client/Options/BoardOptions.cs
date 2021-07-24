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

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            if (!Include)
                return String.Empty;

            var model = "board";
            if (mode == OptionBuilderMode.Multiple)
                model = "boards";

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

            var description = String.Empty;
            if (IncludeDescription)
                description = "description";

            var boardAccessType = String.Empty;
            if (IncludeBoardAccessType)
                boardAccessType = "board_kind";

            var boardStateType = String.Empty;
            if (IncludeBoardStateType)
                boardStateType = "state";

            var boardFolderId = String.Empty;
            if (IncludeBoardFolderId)
                boardFolderId = "board_folder_id";

            var permissions = String.Empty;
            if (IncludePermissions)
                permissions = "permissions";

            var columns = String.Empty;
            if (IncludeColumns)
                columns = ColumnOptions.Build(OptionBuilderMode.Multiple);

            return $@"
{model}{attributes} {{
    id {name} {description} {boardAccessType} {boardStateType} {boardFolderId} {permissions} {columns}
}}";
        }
    }
}
