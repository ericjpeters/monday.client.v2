using System;

namespace Monday.Client.Options
{
    public interface IColumnOptions : IBaseOptions
    {
    }
    
    public class ColumnOptions : BaseOptions, IColumnOptions
    {
        public ColumnOptions()
            : base("column", "columns")
        {
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            if (!Include)
                return String.Empty;

            var result = $"id title type archived settings_str";

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
