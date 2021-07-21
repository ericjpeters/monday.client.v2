using System;

namespace Monday.Client.Options
{
    public interface IColumnValuesOptions : IOptionsBuilder
    {
        bool IncludeValue { get; set; }
        bool IncludeType { get; set; }
        bool IncludeAdditionalInfo { get; set; }
    }

    public class ColumnValuesOptions : OptionsBuilder, IColumnValuesOptions
    {
        public bool IncludeValue { get; set; } = true;
        public bool IncludeType { get; set; } = true;
        public bool IncludeAdditionalInfo { get; set; } = true;

        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            var type = String.Empty;
            if (IncludeType)
                type = "type";

            var value = String.Empty;
            if (IncludeValue)
                value = "value";

            var additionalInfo = String.Empty;
            if (IncludeAdditionalInfo)
                additionalInfo = "additional_info";

            return $@"column_values {{ id text title {type} {value} {additionalInfo} }} ";
        }
    }
}
