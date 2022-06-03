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

      PW.AppRegistration.RegistrationManager.Register();// "ScratchPad", Application.ExecutablePath);

#endif


      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
