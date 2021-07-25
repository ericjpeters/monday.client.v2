using Monday.Client.Extensions;
using Monday.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        bool IncludeActivityLogs { get; set; }
        bool IncludeCommunication { get; set; }
        bool IncludeGroups { get; set; }
        bool IncludeItems { get; set; }
        bool IncludeOwner { get; set; }
        bool IncludePosition { get; set; }
        bool IncludeSubscribers { get; set; }
        bool IncludeTags { get; set; }
        bool IncludeTopGroup { get; set; }
        bool IncludeUpdatedAt { get; set; }
        bool IncludeUpdates { get; set; }
        bool IncludeViews { get; set; }
        bool IncludeWorkspace { get; set; }
        bool IncludeWorkspaceId { get; set; }

        ColumnOptions ColumnOptions { get; set; }
        ActivityLogOptions ActivityLogOptions { get; set; }
        GroupOptions GroupOptions { get; set; }
        ItemOptions ItemOptions { get; set; }
        OwnerOptions OwnerOptions { get; set; }
        SubscriberOptions SubscriberOptions { get; set; }
        TagOptions TagOptions { get; set; }
        TopGroupOptions TopGroupOptions { get; set; }
        UpdateOptions UpdateOptions { get; set; }
        BoardViewOptions BoardViewOptions { get; set; }
        WorkspaceOptions WorkspaceOptions { get; set; }
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
        public bool IncludeActivityLogs { get; set; } = false;
        public bool IncludeCommunication { get; set; } = false;
        public bool IncludeGroups { get; set; } = false;
        public bool IncludeItems { get; set; } = false;
        public bool IncludeOwner { get; set; } = false;
        public bool IncludePosition { get; set; } = false;
        public bool IncludeSubscribers { get; set; } = false;
        public bool IncludeTags { get; set; } = false;
        public bool IncludeTopGroup { get; set; } = false;
        public bool IncludeUpdatedAt { get; set; } = false;
        public bool IncludeUpdates { get; set; } = false;
        public bool IncludeViews { get; set; } = false;
        public bool IncludeWorkspace { get; set; } = false;
        public bool IncludeWorkspaceId { get; set; } = false;

        public ColumnOptions ColumnOptions { get; set; } = new ColumnOptions();
        public ActivityLogOptions ActivityLogOptions { get; set; } = new ActivityLogOptions();
        public GroupOptions GroupOptions { get; set; } = new GroupOptions();
        public ItemOptions ItemOptions { get; set; } = new ItemOptions();
        public OwnerOptions OwnerOptions { get; set; } = new OwnerOptions();
        public SubscriberOptions SubscriberOptions { get; set; } = new SubscriberOptions();
        public TagOptions TagOptions { get; set; } = new TagOptions();
        public TopGroupOptions TopGroupOptions { get; set; } = new TopGroupOptions();
        public UpdateOptions UpdateOptions { get; set; } = new UpdateOptions();
        public BoardViewOptions BoardViewOptions { get; set; } = new BoardViewOptions();
        public WorkspaceOptions WorkspaceOptions { get; set; } = new WorkspaceOptions();

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
            var columns = GetField(IncludeColumns, ColumnOptions.Build(OptionBuilderMode.Multiple));
            var permissions = GetField(IncludePermissions, "permissions");
            var activityLogs = GetField(IncludeActivityLogs, ActivityLogOptions.Build(OptionBuilderMode.Multiple));
            var communication = GetField(IncludeCommunication, "communication");
            var groups = GetField(IncludeGroups, GroupOptions.Build(OptionBuilderMode.Multiple));
            var items = GetField(IncludeItems, ItemOptions.Build(OptionBuilderMode.Multiple));
            var owner = GetField(IncludeOwner, OwnerOptions.Build(OptionBuilderMode.Single));
            var pos = GetField(IncludePosition, "pos");
            var subscribers = GetField(IncludeSubscribers, SubscriberOptions.Build(OptionBuilderMode.Multiple));
            var tags = GetField(IncludeTags, TagOptions.Build(OptionBuilderMode.Multiple));
            var topGroup = GetField(IncludeTopGroup, TopGroupOptions.Build(OptionBuilderMode.Single));
            var updatedAt = GetField(IncludeUpdatedAt, "updated_at");
            var updates = GetField(IncludeUpdates, UpdateOptions.Build(OptionBuilderMode.Multiple));
            var views = GetField(IncludeViews, BoardViewOptions.Build(OptionBuilderMode.Multiple));
            var workspace = GetField(IncludeWorkspace, WorkspaceOptions.Build(OptionBuilderMode.Single));
            var workspaceId = GetField(IncludeWorkspaceId, "workspace_id");

            return $@"
{modelName}{modelAttributes} {{
    id {name} {description} {boardAccessType} {boardStateType} {boardFolderId} {columns} {permissions}
    {activityLogs} {communication} {groups} {items} {owner} {pos} {subscribers} {tags} {topGroup} 
    {updatedAt} {updates} {views} {workspace} {workspaceId}
}}";
        }
    }
}