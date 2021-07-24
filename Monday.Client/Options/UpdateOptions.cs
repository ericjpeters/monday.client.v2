﻿using System;

namespace Monday.Client.Options
{
    public interface IUpdateOptions : IBaseOptions
    {
        bool IncludeItemId { get; set; }
        bool IncludeCreatorId { get; set; }
        bool IncludeCreator { get; set; }
        bool IncludeBody { get; set; }
        bool IncludeBodyText { get; set; }
        bool IncludeReplies { get; set; }
        bool IncludeCreatedAt { get; set; }
        bool IncludeUpdatedAt { get; set; }

        UserOptions CreatorOptions { get; set; }
        ReplyOptions RepliesOptions { get; set; }
    }

    public class UpdateOptions : BaseOptions, IUpdateOptions
    {
        public bool IncludeItemId { get; set; }
        public bool IncludeCreatorId { get; set; }
        public bool IncludeCreator { get; set; }
        public bool IncludeBody { get; set; }
        public bool IncludeBodyText { get; set; }
        public bool IncludeReplies { get; set; }
        public bool IncludeCreatedAt { get; set; }
        public bool IncludeUpdatedAt { get; set; }

        public UserOptions CreatorOptions { get; set; }
        public ReplyOptions RepliesOptions { get; set; }

        public UpdateOptions()
           : base("update")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var itemId = GetField(IncludeItemId, "item_id");
            var creatorId = GetField(IncludeCreatorId, "creator_id");
            var body = GetField(IncludeBody, "body");
            var bodyText = GetField(IncludeBodyText, "text_body");
            var createdAt = GetField(IncludeCreatedAt, "created_at");
            var updatedAt = GetField(IncludeUpdatedAt, "updated_at");

            var creator = GetField(IncludeCreator, "creator");
            var replies = GetField(IncludeReplies, "replies");

            return $@"
{modelName}{modelAttributes} {{
    id {itemId} {creatorId} {body} {bodyText} {createdAt} {updatedAt} {creator} {replies}
}}";
        }
    }
}
