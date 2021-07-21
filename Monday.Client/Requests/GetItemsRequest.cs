using System;

namespace Monday.Client.Requests
{
    public interface IGetItemsRequest
    {
        int BoardId { get; set; }
        int Limit { get; set; }

        IBoardOptions BoardOptions { get; set; }
        IGroupOptions GroupOptions { get; set; }
        IItemOptions ItemOptions { get; set; }
    }

    public class GetItemsRequest : IGetItemsRequest
    {
        public int BoardId { get; set; }

        public int Limit { get; set; } = 100000;
        public IBoardOptions BoardOptions { get; set; } = new BoardOptions();
        public IGroupOptions GroupOptions { get; set; } = new GroupOptions();
        public IItemOptions ItemOptions { get; set; } = new ItemOptions();

        public GetItemsRequest(int boardId)
        {
            BoardId = boardId;
        }
    }

    public interface IGetItemRequest
    {
        int ItemId { get; set; }

        IBoardOptions BoardOptions { get; set; }
        IGroupOptions GroupOptions { get; set; }
        IColumnValuesOptions ColumnValuesOptions { get; set; }
        ISubscribersOptions SubscribersOptions { get; set; }
        IUpdatesOptions UpdatesOptions { get; set; }
    }

    public class GetItemRequest : IGetItemRequest
    {
        public int ItemId { get; set; }
        public IBoardOptions BoardOptions { get; set; } = new BoardOptions
        {
            IncludeState = true,
            IncludeBoardFolderId = true
        };
        public IGroupOptions GroupOptions { get; set; } = new GroupOptions
        {
            IncludeColor = true
        };
        public IColumnValuesOptions ColumnValuesOptions { get; set; } = new ColumnValuesOptions();
        public ISubscribersOptions SubscribersOptions { get; set; } = new SubscribersOptions();
        public IUpdatesOptions UpdatesOptions { get; set; } = new UpdatesOptions();

        public GetItemRequest(int itemId)
        {
            ItemId = itemId;
        }
    }

    public interface IOptionsBuilder
    {
        bool Include { get; set; }
        bool IncludeMetadata { get; set; }

        string Build();
        string Build(OptionBuilderMode Mode);
    }

    public abstract class OptionsBuilder : IOptionsBuilder
    {
        public bool Include { get; set; } = true;
        public bool IncludeMetadata { get; set; } = true;

        public string Build()
        {
            return Build(OptionBuilderMode.Single);
        }

        public abstract string Build(OptionBuilderMode Mode);
    }

    public interface IBoardOptions : IOptionsBuilder
    {
        bool IncludeState { get; set; }
        bool IncludeBoardFolderId { get; set; }
    }

    public class BoardOptions : OptionsBuilder, IBoardOptions
    {
        public bool IncludeState { get; set; } = false;
        public bool IncludeBoardFolderId { get; set; } = false;

        public override string Build(OptionBuilderMode Mode)
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

    public interface IGroupOptions : IOptionsBuilder
    {
        bool IncludeColor { get; set; }
    }

    public class GroupOptions : OptionsBuilder, IGroupOptions
    {
        public bool IncludeColor { get; set; } = false;

        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            var color = String.Empty;
            if (IncludeColor)
                color = "color";

            var metadata = String.Empty;
            if (IncludeMetadata)
                metadata = "archived deleted";

            return $@"group {{ id title {color} {metadata} }}";
        }
    }

    public interface IItemOptions : IOptionsBuilder
    {
    }

    public class ItemOptions : OptionsBuilder, IItemOptions
    {
        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            var metadata = String.Empty;
            if (IncludeMetadata)
                metadata = $@"creator_id created_at updated_at creator {{ id name email }}";

            var result = $@"id name {metadata}";

            switch (Mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                default:
                    return $@"item {{ {result} }}";
            }
        }
    }

    public enum OptionBuilderMode
    {
        Single,
        Raw
    }

    public interface IColumnValuesOptions : IOptionsBuilder
    {
        bool IncludeValue { get; set; }
        bool IncludeType { get; set; }
        bool IncludeAdditionalInfo { get; set; }
    }

    public class ColumnValuesOptions : OptionsBuilder, IColumnValuesOptions
    {
        public bool IncludeValue { get; set; } = true;
        public bool IncludeType { get; set; } = true;
        public bool IncludeAdditionalInfo { get; set; } = true;

        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            var type = String.Empty;
            if (IncludeType)
                type = "type";

            var value = String.Empty;
            if (IncludeValue)
                value = "value";

            var additionalInfo = String.Empty;
            if(IncludeAdditionalInfo)
                additionalInfo = "additional_info";

            return $@"column_values {{ id text title {type} {value} {additionalInfo} }} ";
        }
    }
    public interface ISubscribersOptions : IOptionsBuilder
    {
    }

    public class SubscribersOptions : OptionsBuilder, ISubscribersOptions
    {
        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            return $@"subscribers {{ id name email }} ";
        }
    }
    public interface IUpdatesOptions : IOptionsBuilder
    {
        int Limit { get; set; }
    }

    public class UpdatesOptions : OptionsBuilder, IUpdatesOptions
    {
        public int Limit { get; set; } = 100000;

        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            return $@"
updates(limit: {Limit}) {{ 
    id body text_body replies {{
        id body text_body creator_id creator {{ 
            id name email 
        }} 
        created_at updated_at 
    }} 
    creator_id creator {{ 
        id name email 
    }} 
    created_at updated_at 
}}";
        }
    }
}
