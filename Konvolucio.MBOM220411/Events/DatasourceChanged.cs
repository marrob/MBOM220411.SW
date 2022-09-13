namespace Konvolucio.MBOM220411.Events
{
    class DatasourceChanged : IApplicationEvent
    {
        public object Sender { get; private set; } 
        public DatasourceChanged(object sender)
        {
            Sender = sender;
        }
    }
}
