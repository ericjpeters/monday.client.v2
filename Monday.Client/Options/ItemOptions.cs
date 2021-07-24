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
        CreatorOptions CreatorOptions { get; set; }
        SubscriberOptions SubscriberOptions { get; set; }
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
        public CreatorOptions CreatorOptions { get; set; } = new CreatorOptions
        {
        };
        public SubscriberOptions SubscriberOptions { get; set; } = new SubscriberOptions
        {
        };

        public ItemOptions()
            : base("item", "items")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var name = GetField(IncludeName, "name");
            var createdAt = GetField(IncludeCreatedAt, "created_at");
            var creatorId = GetField(IncludeCreatorId, "creator_id");
            var updatedAt = GetField(IncludeUpdatedAt, "updated_at");

            var creator = GetField(IncludeCreator, CreatorOptions.Build(OptionBuilderMode.Single));
            var board = GetField(IncludeBoard, BoardOptions.Build(OptionBuilderMode.Single));
            var group = GetField(IncludeGroup, GroupOptions.Build(OptionBuilderMode.Single));
            var columnValues = GetField(IncludeColumnValues, ColumnValueOptions.Build(OptionBuilderMode.Multiple));
            var subscribers = GetField(IncludeSubscribers, SubscriberOptions.Build(OptionBuilderMode.Multiple));

            return $@"
{modelName}{modelAttributes} {{
    id {name} {creatorId} {createdAt} {updatedAt} {creator} {board} {group} {columnValues} {subscribers}
}}";
        }
    }
}