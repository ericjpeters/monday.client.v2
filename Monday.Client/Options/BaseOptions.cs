using System;

namespace Monday.Client.Options
{
    public interface IBaseOptions 
    {
        bool Include { get; set; }
    }

    public abstract class BaseOptions : IBaseOptions
    {
        public bool Include { get; set; } = true;

        internal abstract string Build(OptionBuilderMode mode, (string key, string val)[] attrs);
    }

    public class OptionsBuilder
    {
        internal string Build(IBaseOptions opt, params (string key, string val)[] attrs)
        {
            return Build(opt, OptionBuilderMode.Single, attrs);
        }

        internal string Build(IBaseOptions opt, OptionBuilderMode mode, params (string key, string val)[] attrs)
        {
            if(opt is BaseOptions o)
                return o.Build(mode, attrs);

            return String.Empty;
        }
    }
}
