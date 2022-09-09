using System;
using System.Windows.Forms;

namespace ScratchPad;

public static class TextBoxExtensions
{
  /// <summary>
  /// Ensures a minimum number of lines for the text-box. Adds blank lines to the end as required.
  /// </summary>
  public static void SetMinimumLineCount(this TextBox textBox, int count)
  {
    var lines = textBox.Lines;
    var lineCount = lines.Length;
    int dif = count - lineCount;

    if (dif > 0)
    {
      // Avoid changes while resizing.
      textBox.ReadOnly = true;
      
      Array.Resize(ref lines, count);

      // Fill added lines with new-lines.
      for (int i = lines.Length; i < count; i++) lines[i] = Environment.NewLine;

      // Maintain selection
      var selPos = textBox.SelectionStart;
      var selLen = textBox.SelectionLength;

      textBox.Lines = lines;

      // Restore selection
      textBox.SelectionStart = selPos;
      textBox.SelectionLength = selLen;

      textBox.ReadOnly = false;
    }


  }
}
