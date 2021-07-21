using System;

namespace Monday.Client.Options
{
    public interface IBaseOptions 
    {
        bool Include { get; set; }
        bool IncludeMetadata { get; set; }
    }

    public abstract class BaseOptions : IBaseOptions
    {
        public bool Include { get; set; } = true;
        public bool IncludeMetadata { get; set; } = true;

        internal abstract string Build(OptionBuilderMode Mode);
    }

    public class OptionsBuilder
    {
        internal string Build(IBaseOptions opt)
        {
            return Build(opt, OptionBuilderMode.Single);
        }

        internal string Build(IBaseOptions opt, OptionBuilderMode Mode)
        {
            if(opt is BaseOptions o)
                return o.Build(Mode);

            return String.Empty;
        }
    }
}
