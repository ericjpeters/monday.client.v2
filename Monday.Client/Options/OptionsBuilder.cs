namespace Monday.Client.Options
{
    public interface IOptionsBuilder
    {
        bool Include { get; set; }
        bool IncludeMetadata { get; set; }

        string Build();
        string Build(OptionBuilderMode Mode);
    }

    public abstract class OptionsBuilder : IOptionsBuilder
    {
        public bool Include { get; set; } = true;
        public bool IncludeMetadata { get; set; } = true;

        public string Build()
        {
            return Build(OptionBuilderMode.Single);
        }

        public abstract string Build(OptionBuilderMode Mode);
    }
}
