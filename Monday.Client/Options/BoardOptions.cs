using System;

namespace Monday.Client.Options
{
    public interface IBoardOptions : IBaseOptions
    {
        bool IncludeState { get; set; }
        bool IncludeBoardFolderId { get; set; }
        bool IncludePermissions { get; set; }
    }
    
    public class BoardOptions : BaseOptions, IBoardOptions
    {
        public bool IncludeState { get; set; } = false;
        public bool IncludeBoardFolderId { get; set; } = false;
        public bool IncludePermissions { get; set; } = false;

        internal override string Build(OptionBuilderMode mode)
        {
            if (!Include)
                return String.Empty;

            var state = String.Empty;
            if (IncludeState)
                state = "state";

            var boardFolderId = String.Empty;
            if (IncludeBoardFolderId)
                boardFolderId = "board_folder_id";

            var permissions = String.Empty;
            if (IncludePermissions)
                permissions = "permissions";

            var result = $"id name description board_kind {state} {boardFolderId} {permissions}";

            switch (mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                case OptionBuilderMode.Multiple:
                    return $@"boards {{ {result} }}";

                default:
                    return $@"board {{ {result} }}";
            }
        }
    }
}
