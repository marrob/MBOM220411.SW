namespace Konvolucio.MBOM220411.Events
{
    using System.Windows.Forms;

    public class TreeNodeChangedAppEvent : IApplicationEvent
    {
        public TreeNode SelectedNode { get; private set; }

        public class SelectionSourceType { }

        public TreeNodeChangedAppEvent(TreeNode selectedNode)
        {
            SelectedNode = selectedNode;
        }
    }

}
