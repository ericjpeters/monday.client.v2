using System;

namespace Monday.Client.Options
{
    public interface ITagOptions : IBaseOptions
    {
    }
    
    public class TagOptions : BaseOptions, ITagOptions
    {
        public TagOptions()
           : base("tag", "tags")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            if (!Include)
                return String.Empty;

            var result = $"id name color";

            switch (mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                case OptionBuilderMode.Multiple:
                    return $@"tags {{ {result} }}";

                default:
                    return $@"tag {{ {result} }}";
            }
        }
    }
}
