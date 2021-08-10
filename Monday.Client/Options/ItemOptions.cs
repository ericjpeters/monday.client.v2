using Monday.Client.Requests;
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
            : this(RequestMode.Default)
        { 
        }

        public ItemOptions(RequestMode mode)
            : base("item", "items")
        {
            switch (mode)
            {
                case RequestMode.Minimum:
                    IncludeBoard = false;
                    IncludeGroup = false;
                    IncludeColumnValues = false;
                    IncludeName = false;
                    IncludeCreatorId = false;
                    IncludeCreatedAt = false;
                    IncludeUpdatedAt = false;
                    IncludeCreator = false;
                    IncludeSubscribers = false;
                    break;

                case RequestMode.Maximum:
                    IncludeBoard = true;
                    IncludeGroup = true;
                    IncludeColumnValues = true;
                    IncludeName = true;
                    IncludeCreatorId = true;
                    IncludeCreatedAt = true;
                    IncludeUpdatedAt = true;
                    IncludeCreator = true;
                    IncludeSubscribers = true;
                    BoardOptions = new BoardOptions
                    {
                        IncludeName = true,
                        IncludeDescription = true,
                        IncludeBoardAccessType = true,
                        IncludeBoardStateType = true,
                        IncludeBoardFolderId = true,
                        IncludePermissions = true,
                        IncludeColumns = false
                    };
                    GroupOptions = new GroupOptions
                    {
                        IncludeTitle = true,
                        IncludeColor = true,
                        IncludeIsArchived = true,
                        IncludeIsDeleted = true,
                    };
                    ColumnValueOptions = new ColumnValueOptions
                    {
                        IncludeTitle = true,
                        IncludeValue = true,
                        IncludeType = true,
                        IncludeText = true,
                        IncludeAdditionalInfo = true
                    };
                    CreatorOptions = new CreatorOptions
                    {
                        IncludeName = true,
                        IncludeEmail = true,
                        IncludeUrl = true,
                        IncludePhoto = true,
                        IncludeTitle = true,
                        IncludeBirthday = true,
                        IncludeCountryCode = true,
                        IncludeLocation = true,
                        IncludeTimeZoneIdentifier = true,
                        IncludePhone = true,
                        IncludeMobilePhone = true,
                        IncludeIsGuest = true,
                        IncludeIsPending = true,
                        IncludeIsEnabled = true,
                        IncludeCreatedAt = true
                    };
                    SubscriberOptions = new SubscriberOptions
                    {
                        IncludeName = true,
                        IncludeEmail = true,
                        IncludeUrl = true,
                        IncludePhoto = true,
                        IncludeTitle = true,
                        IncludeBirthday = true,
                        IncludeCountryCode = true,
                        IncludeLocation = true,
                        IncludeTimeZoneIdentifier = true,
                        IncludePhone = true,
                        IncludeMobilePhone = true,
                        IncludeIsGuest = true,
                        IncludeIsPending = true,
                        IncludeIsEnabled = true,
                        IncludeCreatedAt = true
                    };
                    break;

                case RequestMode.Default:
                default:
                    IncludeColumnValues = true;
                    CreatorOptions = new CreatorOptions
                    {
                        IncludeUrl = false,
                        IncludePhoto = false,
                        IncludeTitle = false,
                        IncludeBirthday = false,
                        IncludeCountryCode = false,
                        IncludeLocation = false,
                        IncludeTimeZoneIdentifier = false,
                        IncludePhone = false,
                        IncludeMobilePhone = false,
                        IncludeIsGuest = false,
                        IncludeIsPending = false,
                        IncludeIsEnabled = false,
                        IncludeCreatedAt = false
                    };
                    IncludeBoard = true;
                    BoardOptions = new BoardOptions
                    {
                        IncludeBoardStateType = true,
                        IncludeBoardFolderId = true
                    };
                    IncludeGroup = true;
                    GroupOptions = new GroupOptions
                    {
                        IncludeColor = true
                    };
                    IncludeSubscribers = true;
                    SubscriberOptions = new SubscriberOptions
                    {
                        IncludeUrl = false,
                        IncludePhoto = false,
                        IncludeTitle = false,
                        IncludeBirthday = false,
                        IncludeCountryCode = false,
                        IncludeLocation = false,
                        IncludeTimeZoneIdentifier = false,
                        IncludePhone = false,
                        IncludeMobilePhone = false,
                        IncludeIsGuest = false,
                        IncludeIsPending = false,
                        IncludeIsEnabled = false,
                        IncludeCreatedAt = false
                    };
                    break;
            }
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