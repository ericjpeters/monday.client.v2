using System;

namespace Monday.Client.Options
{
    public interface ISubscribersOptions : IOptionsBuilder
    {
    }

    public class SubscribersOptions : OptionsBuilder, ISubscribersOptions
    {
        public override string Build(OptionBuilderMode Mode)
        {
            if (!Include)
                return String.Empty;

            return $@"subscribers {{ id name email }} ";
        }
    }
}
