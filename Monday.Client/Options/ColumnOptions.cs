using System;

namespace Monday.Client.Options
{
    public interface IColumnOptions : IBaseOptions
    {
    }
    
    public class ColumnOptions : BaseOptions, IColumnOptions
    {
        internal override string Build(OptionBuilderMode mode)
        {
            if (!Include)
                return String.Empty;

            var result = $"id, title, type, archived settings_str";

            switch (mode)
            {
                case OptionBuilderMode.Raw:
                    return result;

                case OptionBuilderMode.Multiple:
                    return $@"columns {{ {result} }}";

                default:
                    return $@"column {{ {result} }}";
            }
        }
    }
}
