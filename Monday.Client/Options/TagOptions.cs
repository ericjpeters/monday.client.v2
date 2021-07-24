using System;

namespace Monday.Client.Options
{
    public interface ITagOptions : IBaseOptions
    {
    }
    
    public class TagOptions : BaseOptions, ITagOptions
    {
        internal override string Build(OptionBuilderMode mode, (string key, string val)[] attrs)
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
