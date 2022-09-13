namespace Konvolucio.MBOM220411.Events
{
    class TableContentChanged : IApplicationEvent
    {
        public string TableName { get; private set; } 
        public TableContentChanged(string name)
        {
            TableName = name;
        }
    }
}
