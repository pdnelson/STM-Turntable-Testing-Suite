using System.Text;

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

        public static string secondsToTimeString(uint seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);

            StringBuilder finalString = new();

            if (timeSpan.Days > 0) finalString.Append(timeSpan.Days + "d, ");
            finalString.Append(timeSpan.Hours.ToString("D2") + ":" + timeSpan.Minutes.ToString("D2") + ":" + timeSpan.Seconds.ToString("D2"));

            return finalString.ToString();
        }
    }
}
