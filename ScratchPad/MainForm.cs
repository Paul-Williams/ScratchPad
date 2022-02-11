using PW.IO.FileSystemObjects;
using PW.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace ScratchPad {
  public partial class MainForm : Form {
    public MainForm() {
      InitializeComponent();
    }

    private FilePath DocPath { get; } =
      (DirectoryPath)Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
      + (DirectoryName)"ScratchPad"
      + (FileName)"ScratchDoc.txt";


    private void Form_Load(object sender, EventArgs e) {
      try {
        Icon = Properties.Resources.Text_Edit;
        DocPath.DirectoryPath.CreateIfNotExists();
        LoadDoc();
      }
      catch (Exception ex) {
        MsgBox.ShowError(ex);
      }
    }


    private void LoadDoc() {
      try {
        if (!DocPath.Exists) return;
        TextBox.Text = File.ReadAllText(DocPath.Value);
        TextBox.SelectionStart = 0;
        TextBox.SelectionLength = 0;
        EnsureMinimumLineCount();
      }
      catch (Exception ex) {
        MsgBox.ShowError(ex, "Unable to load ScratchDoc");
      }
    }

    private void SaveDoc() {
      try {
        File.WriteAllText(DocPath.Value, TextBox.Text);
      }
      catch (Exception ex) {
        MsgBox.ShowError(ex, "Unable to save ScratchDoc");
      }
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
      SaveDoc();
    }

    private void TextBox_TextChanged(object sender, EventArgs e) {
      EnsureMinimumLineCount();
    }

    private const int MinLines = 29;

    /// <summary>
    /// Ensures a minimum number of lines for the text-box. Adds blank lines to the end as required.
    /// </summary>
    private void EnsureMinimumLineCount() {

      TextBox.ReadOnly = false;
      var lines = TextBox.Lines;
      var lineCount = lines.Length;
      int dif = MinLines - lineCount;

      if (dif > 0) {
        Array.Resize(ref lines, MinLines);
        for (int i = lines.Length; i < MinLines; i++) lines[i] = Environment.NewLine;

        var selPos = TextBox.SelectionStart;
        var selLen = TextBox.SelectionLength;

        TextBox.Lines = lines;

        TextBox.SelectionStart = selPos;
        TextBox.SelectionLength = selLen;        
      }

      TextBox.ReadOnly = false;
    }
  }
}
