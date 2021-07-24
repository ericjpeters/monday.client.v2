using System;

namespace Monday.Client.Options
{
    public interface ISubscribersOptions : IBaseOptions
    {
    }

    public class SubscribersOptions : BaseOptions, ISubscribersOptions
    {
        internal override string Build(OptionBuilderMode mode, (string key, string val)[] attrs)
        {
            if (!Include)
                return String.Empty;

            return $@"subscribers {{ id name email }} ";
        }
    }
}
