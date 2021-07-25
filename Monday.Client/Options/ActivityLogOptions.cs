namespace Monday.Client.Options
{
    public interface IActivityLogOptions : IBaseOptions
    {
        bool IncludeAccountId { get; set; }
        bool IncludeCreatedAt { get; set; }
        bool IncludeData { get; set; }
        bool IncludeEntity { get; set; }
        bool IncludeEvent { get; set; }
        bool IncludeUserId { get; set; }
    }

    public class ActivityLogOptions : BaseOptions, IActivityLogOptions
    {
        public bool IncludeAccountId { get; set; } = false;
        public bool IncludeCreatedAt { get; set; } = false;
        public bool IncludeData { get; set; } = true;
        public bool IncludeEntity { get; set; } = false;
        public bool IncludeEvent { get; set; } = true;
        public bool IncludeUserId { get; set; } = true;

        public ActivityLogOptions()
            : base("activity_log")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var accountId = GetField(IncludeAccountId, "account_id");
            var createdAt = GetField(IncludeCreatedAt, "created_at");
            var data = GetField(IncludeData, "data");
            var entity = GetField(IncludeEntity, "entity");
            var evt = GetField(IncludeEvent, "event");
            var userId = GetField(IncludeUserId, "user_id");

            return $@"
{modelName}{modelAttributes} {{
    id {accountId} {createdAt} {data} {entity} {evt} {userId} 
}}";
        }
    }
}