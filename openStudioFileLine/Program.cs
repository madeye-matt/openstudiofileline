using System;
using System.Collections.Generic;
using System.Text;

namespace openStudioFileLine
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                String filename = args[0];
                int fileline;
                int.TryParse(args[1], out fileline);
                EnvDTE80.DTE2 dte2 = null;
                //Console.WriteLine("Checkpoint #1");
                dte2 = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.14.0");
                //Console.WriteLine("Checkpoint #2");
                dte2.MainWindow.Activate();
                //Console.WriteLine("Checkpoint #3");
                EnvDTE.Window w = dte2.ItemOperations.OpenFile(filename, EnvDTE.Constants.vsViewKindTextView);
                //Console.WriteLine("Checkpoint #4");
                ((EnvDTE.TextSelection)dte2.ActiveDocument.Selection).GotoLine(fileline, true);
                //Console.WriteLine("Checkpoint #5");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
