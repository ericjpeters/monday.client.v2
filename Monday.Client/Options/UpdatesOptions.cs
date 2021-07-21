﻿using System;

namespace Monday.Client.Options
{
    public interface IUpdatesOptions : IOptionsBuilder
    {
        int Limit { get; set; }
    }

    public class UpdatesOptions : OptionsBuilder, IUpdatesOptions
    {
        public int Limit { get; set; } = 100000;

        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            return $@"
updates(limit: {Limit}) {{ 
    id body text_body replies {{
        id body text_body creator_id creator {{ 
            id name email 
        }} 
        created_at updated_at 
    }} 
    creator_id creator {{ 
        id name email 
    }} 
    created_at updated_at 
}}";
        }
    }
}
