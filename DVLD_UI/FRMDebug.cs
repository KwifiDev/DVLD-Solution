using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;

namespace DVLD_UI
{
    /// <summary>
    /// Represents the debug form.
    /// </summary>
    public partial class FRMDebug : KryptonForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FRMDebug"/> class.
        /// </summary>
        public FRMDebug()
        {
            InitializeComponent();
        }

        private bool _isHandlingCheckEvent = false;

        /// <summary>
        /// Handles the AfterCheck event of the KryptonTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void KryptonTreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (_isHandlingCheckEvent) return;

            _isHandlingCheckEvent = true;

            try
            {
                UpdateParentNodeCheckState(e.Node.Parent);
                CheckAllChildNodes(e.Node);
            }
            finally
            {
                _isHandlingCheckEvent = false;
            }
        }

        /// <summary>
        /// Checks or unchecks all child nodes of the specified node.
        /// </summary>
        /// <param name="node">The node whose child nodes will be checked or unchecked.</param>
        private void CheckAllChildNodes(TreeNode node)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                subNode.Checked = node.Checked;
            }
        }

        /// <summary>
        /// Updates the check state of the parent node based on the check states of its child nodes.
        /// </summary>
        /// <param name="parentNode">The parent node to update.</param>
        private void UpdateParentNodeCheckState(TreeNode parentNode)
        {
            if (parentNode != null)
            {
                bool anyChildNodeChecked = false;

                foreach (TreeNode subNode in parentNode.Nodes)
                {
                    if (subNode.Checked)
                    {
                        anyChildNodeChecked = true;
                        break;
                    }
                }

                parentNode.Checked = anyChildNodeChecked;

                UpdateParentNodeCheckState(parentNode.Parent);
            }
        }
    }
}
