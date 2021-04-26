using System;
using System.IO;

using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using Serilog.Formatting.Json;

namespace Serilog.Sinks.WPF
{
    public class WinFormsSinkInternal : ILogEventSink
    {
        public delegate void LogHandler (string str);
        public delegate void LogClear();
        public event LogHandler OnLogReceived;
        public event LogClear OnLogClear;
        private readonly ITextFormatter _textFormatter;

        public WinFormsSinkInternal(ITextFormatter textFormatter)
        {
            _textFormatter = textFormatter ?? throw new ArgumentNullException(nameof(textFormatter));
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            var renderSpace = new StringWriter();
            _textFormatter.Format(logEvent, renderSpace);
            FireEvent(renderSpace.ToString());
        }

        public void Clear()
        {
            OnLogClear?.Invoke();
        }
        private void FireEvent (string str)
        {
            OnLogReceived?.Invoke(str + Environment.NewLine);
        }
    }

    public static class WindFormsSink
    {
        public static readonly WinFormsSinkInternal SimpleTextBoxSink = new WinFormsSinkInternal(new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message} {Exception}"));
        public static readonly WinFormsSinkInternal JsonTextBoxSink = new WinFormsSinkInternal(new JsonFormatter());
    }
}
