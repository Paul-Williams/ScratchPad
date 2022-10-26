using PW.IO.FileSystemObjects;
using PW.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace ScratchPad
{
  public partial class MainForm : Form
  {
    private const int MinLines = 29;

    private int AutoSaveInterval;
    private bool isDirty;

    public MainForm() => InitializeComponent();

    private FilePath DocPath { get; } =
      (DirectoryPath)Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
      + (DirectoryName)"ScratchPad"
      + (FileName)"ScratchDoc.txt";


    private void Form_Load(object sender, EventArgs e)
    {
      try
      {
        Icon = Properties.Resources.Text_Edit;
        DocPath.DirectoryPath.Create();
        LoadDoc();
        TextBox.TextChanged += TextBox_TextChanged;
        AutoSaveInterval = SaveTimer.Interval;
      }
      catch (Exception ex)
      {
        MsgBox.ShowError(ex);
      }
    }


    private void LoadDoc()
    {
      try
      {
        if (DocPath.Exists)
        {
          TextBox.Text = File.ReadAllText(DocPath);
          TextBox.SelectionStart = 0;
          TextBox.SelectionLength = 0;
        }
        TextBox.SetMinimumLineCount(MinLines);
      }
      catch (Exception ex)
      {
        MsgBox.ShowError(ex, "Unable to load ScratchDoc");
      }
    }

    public bool IsDirty 
    { 
      get => isDirty; 
      set 
      {
        if (isDirty == value) return;
        isDirty = value;

        // Add or remote a * to the end of the window title to denote dirty status.
        Text = isDirty ? Text += '*' : Text[0..^1];
      }
    
    }

    private void SaveDoc()
    {
      if (!IsDirty) return;

      try
      {
        File.WriteAllText(DocPath, TextBox.Text);
        IsDirty = false;
      }
      catch (Exception ex)
      {
        MsgBox.ShowError(ex, "Unable to save ScratchDoc");
      }
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      SaveTimer.Stop();
      SaveDoc();
    }

    // This handler should only be attached once the document has been loaded.
    private void TextBox_TextChanged(object? sender, EventArgs e)
    {
      TextBox.SetMinimumLineCount(MinLines);
      // Reset the timer each time a key is pressed, so that it only saves after a period of inactivity.      
      SaveTimer.Interval = AutoSaveInterval;
      if (!SaveTimer.Enabled) SaveTimer.Enabled = true;

      IsDirty = true;
    }

    private void SaveTimer_Tick(object sender, EventArgs e)
    {
      SaveTimer.Stop();
      SaveDoc();
    }
  }
}
