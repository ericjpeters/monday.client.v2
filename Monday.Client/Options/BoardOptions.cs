﻿using System;

namespace Monday.Client.Options
{
    public interface IBoardOptions : IBaseOptions
    {
        bool IncludeState { get; set; }
        bool IncludeBoardFolderId { get; set; }
    }
    
    public class BoardOptions : BaseOptions, IBoardOptions
    {
        public bool IncludeState { get; set; } = false;
        public bool IncludeBoardFolderId { get; set; } = false;

        internal override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            var state = String.Empty;
            if (IncludeState)
                state = "state";

            var boardFolderId = String.Empty;
            if (IncludeBoardFolderId)
                boardFolderId = "board_folder_id";

            return $@"board {{ id name description board_kind {state} {boardFolderId} }}";
        }
    }
}
