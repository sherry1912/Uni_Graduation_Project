using System.Windows.Forms;

namespace VisualBinaryTree
{
    class TreeError
    {
        public static void DisplayError(string errorMessage)
        {
            MessageBox.Show("The following error has occured, please try again:\n\n" + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
