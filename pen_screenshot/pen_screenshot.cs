using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pen_screenshot
{
    public class DLLEntry
    {
        #if WIN64
            [DllExport("RVExtension", CallingConvention = CallingConvention.Winapi)]
        #else
            [DllExport("_RVExtension@12", CallingConvention = CallingConvention.Winapi)]
        #endif
        public static void RVExtension(StringBuilder output, int outputSize, [MarshalAs(UnmanagedType.LPStr)] string input)
        {
            int colonIndex = input.IndexOf(":");
            if (colonIndex == -1)
            {
                output.Append("Failed: No colon found in input string");
                return;
            }
            string operationType = input.Substring(0, colonIndex);

            if (operationType.Equals("configure"))
            {
                // future option for configuration of captured images
                // e.g. compression, resolution, saturation, contrast, etc
                string configInfo = input.Substring(colonIndex + 1, input.Length - colonIndex - 1);
                output.Append("Success: Configuration changes were made");
                return;
            }
            else if (operationType.Equals("capture"))
            {
                string imagePath = input.Substring(colonIndex + 1, input.Length - colonIndex - 1);

                bool isAware = SetProcessDPIAware();

                Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

                using (Bitmap bitmap = new Bitmap(screenBounds.Width, screenBounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, screenBounds.Size);
                    }

                    try
                    {
                        bitmap.Save(imagePath);
                        output.Append("Success: Image saved");
                    }
                    catch
                    {
                        output.Append("Failed: Issue saving image");
                    }
                }

                return;
            }

            output.Append("Failed: Operation type didn't match existing options");
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
    }
}
