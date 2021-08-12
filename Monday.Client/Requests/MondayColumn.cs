﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Monday.Client.Requests
{
    public enum MondayColumnDataType
    {
        Text,
        LongText
    }

    public interface IMondayColumn
    {
        string Name { get; set; }
        string Value { get; set; }
        MondayColumnDataType DataType { get; set; }
    }

    public interface IMondayColumns
    { 
    }

    public class MondayColumn : IMondayColumn
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public MondayColumnDataType DataType { get; set; } = MondayColumnDataType.Text;
    }

    public class MondayColumns : IMondayColumns
    {
        private string _rawJson = null;
        private IList<IMondayColumn> _columns = new List<IMondayColumn>();

        public MondayColumns(string rawJson)
        {
            _rawJson = rawJson;
        }

        public MondayColumns(params MondayColumn[] columns)
        {
            foreach (var col in columns)
            {
                _columns.Add(col);
            }
        }

        public void AddText(string name, string value) {
            _columns.Add(new MondayColumn { 
                Name = name,
                Value = value,
                DataType = MondayColumnDataType.Text
            });
        }
        
        public void AddLongText(string name, string value) {
            _columns.Add(new MondayColumn
            {
                Name = name,
                Value = value,
                DataType = MondayColumnDataType.LongText
            });
        }

        public override string ToString()
        {
            if(!String.IsNullOrWhiteSpace(_rawJson))
                return _rawJson;


            var sb = new StringBuilder($@"""{{");
            var first = true;
            foreach (var item in _columns) 
            {
                if (!first)
                    sb.Append(",");
                first = false;

                switch (item.DataType)
                {
                    case MondayColumnDataType.LongText:
                        sb.Append($@"\""{item.Name}\"": {{\""text\"": \""{item.Value}\""}}");
                        break;

                    case MondayColumnDataType.Text:
                    default:
                        sb.Append($@"\""{item.Name}\"": \""{item.Value}\""");
                        break;
                }
            }
            sb.Append($@"}}""");
            return sb.ToString();
        }
    }
}
