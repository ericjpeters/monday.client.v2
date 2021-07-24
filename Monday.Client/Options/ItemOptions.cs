using System;
using System.Linq;

namespace Monday.Client.Options
{
    public interface IItemOptions : IBaseOptions
    {
        bool IncludeBoard { get; set; }
        bool IncludeGroup { get; set; }
        bool IncludeColumnValues { get; set; }
        bool IncludeName { get; set; }
        bool IncludeCreatorId { get; set; }
        bool IncludeCreatedAt { get; set; }
        bool IncludeUpdatedAt { get; set; }
        bool IncludeCreator { get; set; }
        bool IncludeSubscribers { get; set; }

        BoardOptions BoardOptions { get; set; }
        GroupOptions GroupOptions { get; set; }
        ColumnValueOptions ColumnValueOptions { get; set; }
        UserOptions CreatorOptions { get; set; }
        UserOptions SubscriberOptions { get; set; }
    }

    public class ItemOptions : BaseOptions, IItemOptions
    {
        public bool IncludeBoard { get; set; } = false;
        public bool IncludeGroup { get; set; } = false;
        public bool IncludeColumnValues { get; set; } = false;
        public bool IncludeName { get; set; } = true;
        public bool IncludeCreatorId { get; set; } = true;
        public bool IncludeCreatedAt { get; set; } = true;
        public bool IncludeUpdatedAt { get; set; } = true;
        public bool IncludeCreator { get; set; } = true;
        public bool IncludeSubscribers { get; set; } = false;

        public BoardOptions BoardOptions { get; set; } = new BoardOptions
        {
            IncludeBoardStateType = true,
            IncludeBoardFolderId = true
        };
        public GroupOptions GroupOptions { get; set; } = new GroupOptions
        {
            IncludeColor = true
        };
        public ColumnValueOptions ColumnValueOptions { get; set; } = new ColumnValueOptions();
        public UserOptions CreatorOptions { get; set; } = new UserOptions
        {
            BaseNameSingular = "creator",
            BaseNamePlural = "creators"
        };
        public UserOptions SubscriberOptions { get; set; } = new UserOptions
        {
            BaseNameSingular = "subscriber",
            BaseNamePlural = "subscribers"
        };

        public ItemOptions()
            : base("item", "items")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            if (!Include)
                return String.Empty;

            var model = BaseNameSingular;
            if (mode == OptionBuilderMode.Multiple)
                model = BaseNamePlural;

            var attributes = String.Empty;
            if (attrs != null)
            {
                attributes = attrs.Aggregate(String.Empty, (_c, _n) => $",{_n.key}:{_n.val}");
                if (attributes.Length > 0)
                    attributes = $"({attributes.Substring(1)})";
            }

            var name = String.Empty;
            if (IncludeName)
                name = $@"name";

            var creatorId = String.Empty;
            if (IncludeCreatorId)
                creatorId = $@"creator_id";

            var createdAt = String.Empty;
            if (IncludeCreatedAt)
                createdAt = $@"created_at";

            var updatedAt = String.Empty;
            if (IncludeUpdatedAt)
                updatedAt = $@"updated_at";

            var creator = String.Empty;
            if (IncludeCreator)
                creator = CreatorOptions.Build(OptionBuilderMode.Single);

            var board = String.Empty;
            if(IncludeBoard)
                board = BoardOptions.Build(OptionBuilderMode.Single);

            var group = String.Empty;
            if(IncludeGroup)
                group = GroupOptions.Build(OptionBuilderMode.Single);

            var columnValues = String.Empty;
            if(IncludeColumnValues)
                columnValues = ColumnValueOptions.Build(OptionBuilderMode.Multiple);

            var subscribers = String.Empty;
            if(IncludeSubscribers)
                subscribers = SubscriberOptions.Build(OptionBuilderMode.Multiple);

            return $@"
{model}{attributes} {{
    id {name} {creatorId} {createdAt} {updatedAt} {creator} {board} {group} {columnValues} {subscribers}
}}";
        }
    }
}
