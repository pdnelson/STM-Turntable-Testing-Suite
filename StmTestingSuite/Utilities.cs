namespace StmTestingSuite
{
    class Utilities
    {
        public static void WriteToUiFromThread<T>(T writeTo, Action codeBlock) where T : Form
        {
            if (writeTo.InvokeRequired)
            {
                IAsyncResult result = writeTo.BeginInvoke(new MethodInvoker(delegate ()
                {
                    codeBlock();
                }));
            }
            else if (writeTo.IsHandleCreated)
            {
                codeBlock();
            }
        }
    }
}
