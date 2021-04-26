namespace Serilog.Sinks.WPF
{
    public static class WindFromsSinkExtensions
    {
        /// <summary>
        /// Write the simple formatted text logs directly to textbox. simple textbox control can be used from toolbox
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToSimpleTextBox(this LoggerConfiguration configuration)
        {;
            WindFormsSink.SimpleTextBoxSink.Clear();
            return configuration.WriteTo.Sink(WindFormsSink.SimpleTextBoxSink);
        }

        /// <summary>
        /// Write the compact json formatted text logs directly to textbox. json textbox control can be used from toolbox
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToJsonTextBox(this LoggerConfiguration configuration)
        {
            WindFormsSink.JsonTextBoxSink.Clear();
            return configuration.WriteTo.Sink(WindFormsSink.JsonTextBoxSink);
        }
        public static void LoggerClear(this LoggerConfiguration configuration)
        { 
            if(WindFormsSink.JsonTextBoxSink!=null) WindFormsSink.JsonTextBoxSink.Clear();
            if (WindFormsSink.SimpleTextBoxSink != null) WindFormsSink.SimpleTextBoxSink.Clear();
        }
    }
}
