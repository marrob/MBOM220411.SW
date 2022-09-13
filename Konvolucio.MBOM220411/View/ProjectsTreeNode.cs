
namespace Konvolucio.MBOM220411.View
{
    using Data;
    using Events;
    using System.Windows.Forms;

    internal class ProjectsTreeNode:TreeNode
    {

        public ProjectsTreeNode()
        {

            Text = "Projects";


            EventAggregator.Instance.Subscribe<ShowAppEvent>(e1 =>
            {
                foreach (string project in Db.Instance.Projects.Get())
                    this.Nodes.Add(project);
            });
        }
    }
}