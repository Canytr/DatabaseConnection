using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConnection
{
    public class Logger
    {
        private RichTextBox _logRichTextBox;

        // Constructor ile RichTextBox referansını alıyoruz
        public Logger(RichTextBox richTextBoxLog)
        {
            _logRichTextBox = richTextBoxLog;
        }

        public enum LogLevel
        { 
            Info,
            Warning,
            Error
        }

        public void LogMessage(string message, LogLevel level = LogLevel.Info) 
        {
            if (_logRichTextBox.InvokeRequired)
            {
                _logRichTextBox.Invoke(new Action(() => LogMessage(message, level)));
            }
            else
            {

                string prefix;
                switch (level)
                {
                    case LogLevel.Info:
                        prefix = "[INFO]";
                        break;
                    case LogLevel.Warning:
                        prefix = "[WARNING]";
                        break;
                    case LogLevel.Error:
                        prefix = "[ERROR]";
                        break;
                    default:
                        prefix = "[INFO]";
                        break;
                }

                _logRichTextBox.AppendText($"{DateTime.Now} {prefix}: {message}\r\n");
                _logRichTextBox.SelectionStart = _logRichTextBox.Text.Length;
                _logRichTextBox.ScrollToCaret();
            }
        }

        public void ClearLog()
        {
            if (_logRichTextBox.InvokeRequired)
            {
                _logRichTextBox.Invoke(new Action(ClearLog));
            }
            else
            {
                _logRichTextBox.Clear();
            }
        }
    }
}
