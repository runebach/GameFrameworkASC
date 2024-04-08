using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameFrameworkASC.TracingAndLogging
{
    public sealed class GameLogger
    {
        /// <summary>
        /// Et traceSource objekt
        /// </summary>
        private static TraceSource _traceSource;
        /// <summary>
        /// An instance field of the class that also initializes an object of the class
        /// </summary>
        private static readonly GameLogger instance = new GameLogger();

        /// <summary>
        /// a public property of the class that only has a get method. This returns the instance of the class.
        /// </summary>
        public static GameLogger Instance { get { return instance; } }
        

        /// <summary>
        /// The constructer of the class. Initializes some important information.
        /// </summary>
        private GameLogger()
        {
            _traceSource = new TraceSource("GameLogger");
            _traceSource.Switch = new SourceSwitch("GameLog", "All");
            CreateListener(new ConsoleTraceListener());
            CreateListener(new TextWriterTraceListener(new StreamWriter($"TextTrace.txt") { AutoFlush = true }));

        }

        /// <summary>
        /// The public method that returns the instance of the object.
        /// </summary>
        /// <returns></returns>
        public static GameLogger GetGameLogger()
        {
            return instance;
        }

        /// <summary>
        /// Method that adds a listener to the tracesource. 
        /// </summary>
        /// <param name="traceListener">The tracelistener object that is to be added to the tracesource</param>
        /// <param name="filter">the filter that is applied to the tracelistener</param>
        private void CreateListener(TraceListener traceListener, EventTypeFilter? filter = null)
        {
            if(filter != null)
            {
                traceListener.Filter = filter;
            }
            _traceSource.Listeners.Add(traceListener);
        }

        /// <summary>
        /// TraceEvent method. Calls the TraceEvent method of the traceSource object.
        /// </summary>
        /// <param name="type">The type of events you want to trace</param>
        /// <param name="id">Id you want to trace</param>
        /// <param name="message">Message you want to send along with the trace</param>
        public static void TraceEvent(TraceEventType type, int id, string message)
        {
            _traceSource.TraceEvent(type, id, message);
        }





    }
}
