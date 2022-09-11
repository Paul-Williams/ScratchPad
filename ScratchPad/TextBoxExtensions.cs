using System;
using System.Linq;
using System.Windows.Forms;

namespace ScratchPad;

public static class TextBoxExtensions
{
  /// <summary>
  /// Ensures a minimum number of lines for the text-box. Adds blank lines to the end as required.
  /// </summary>
  public static void SetMinimumLineCount(this TextBox textBox, int minimum)
  {
    var lines = textBox.Lines;

    if (lines.Length < minimum)
    {
      // Prevent user changes to text box while resizing.
      textBox.ReadOnly = true;

      Array.Resize(ref lines, minimum);

      // Instantiate new strings as blank lines.
      for (int i = lines.Length; i < minimum; i++) lines[i] = Environment.NewLine;

      // Remember selection
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
