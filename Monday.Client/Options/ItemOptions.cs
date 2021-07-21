using System;

namespace Monday.Client.Options
{
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
}
