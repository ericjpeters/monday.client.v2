﻿using Monday.Client.Requests;
using System;

namespace Monday.Client.Options
{
    public interface IColumnValuesOptions : IBaseOptions
    {
        bool IncludeTitle { get; set; }
        bool IncludeValue { get; set; }
        bool IncludeType { get; set; }
        bool IncludeText { get; set; }
        bool IncludeAdditionalInfo { get; set; }
    }

    public class ColumnValueOptions : BaseOptions, IColumnValuesOptions
    {
        public bool IncludeTitle { get; set; } = true;
        public bool IncludeValue { get; set; } = true;
        public bool IncludeType { get; set; } = true;
        public bool IncludeText { get; set; } = true;
        public bool IncludeAdditionalInfo { get; set; } = true;

        public ColumnValueOptions()
            : base("column_value")
        {
        }

        public ColumnValueOptions(RequestMode mode)
            : this()
        {
            switch (mode)
            {
                case RequestMode.Minimum:
                    IncludeTitle = false;
                    IncludeValue = false;
                    IncludeType = false;
                    IncludeText = false;
                    IncludeAdditionalInfo = false;
                    break;

                case RequestMode.Maximum:
                    IncludeTitle = true;
                    IncludeValue = true;
                    IncludeType = true;
                    IncludeText = true;
                    IncludeAdditionalInfo = true;
                    break;

                case RequestMode.Default:
                default:
                    IncludeTitle = true;
                    IncludeValue = true;
                    IncludeType = true;
                    IncludeText = true;
                    IncludeAdditionalInfo = true;
                    break;
            }
        }

        internal override string Build(OptionBuilderMode mode, (string key, object val)[] attrs = null)
        {
            var modelName = GetModelName(mode);
            var modelAttributes = GetModelAttributes(attrs);

            var title = GetField(IncludeTitle, "title");
            var value = GetField(IncludeValue, "value");
            var type = GetField(IncludeType, "type");
            var valueText = GetField(IncludeText, "text");
            var information = GetField(IncludeAdditionalInfo, "additional_info");

            return $@"
{modelName}{modelAttributes} {{
    id {title} {value} {type} {valueText} {information}
}}";
        }
    }
}
