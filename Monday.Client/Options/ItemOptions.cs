using System;

namespace Monday.Client.Options
{
    public interface IItemOptions : IBaseOptions
    {
        bool IncludeCreatorId { get; set; }
        bool IncludeCreatedAt { get; set; }
        bool IncludeUpdatedAt { get; set; }
        bool IncludeCreator { get; set; }

        CreatorOptions CreatorOptions { get; set; }
    }

    public class ItemOptions : BaseOptions, IItemOptions
    {
        public bool IncludeCreatorId { get; set; } = true;
        public bool IncludeCreatedAt { get; set; } = true;
        public bool IncludeUpdatedAt { get; set; } = true;
        public bool IncludeCreator { get; set; } = true;

        public CreatorOptions CreatorOptions { get; set; } = new CreatorOptions();

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            if (!Include)
                return String.Empty;

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

            var result = $@"id name {creatorId} {createdAt} {updatedAt} {creator}";

            switch (mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                case OptionBuilderMode.Multiple:
                    return $@"items {{ {result} }}";

                default:
                    return $@"item {{ {result} }}";
            }
        }
    }
}
