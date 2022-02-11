using System;
using System.Windows.Forms;

namespace ScratchPad
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
#if !DEBUG
#pragma warning disable CA1416 // Validate platform compatibility
      PW.LaunchPad.RegistrationManager.Register("ScratchPad", Application.ExecutablePath);
#pragma warning restore CA1416 // Validate platform compatibility
#endif


      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
