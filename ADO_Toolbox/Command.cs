using System;
using System.Collections.Generic;

namespace ADO_Toolbox
{
    public class Command 
    {
        internal string Query { get; private set; }
        internal bool IsStoredProcedure { get; private set; }
        internal Dictionary<string, object> Parameters { get; private set; }

        public Command(string Command, bool isStoredProcedure = false)
        {
            Parameters = new Dictionary<string, object>();
            Query = Command;
            IsStoredProcedure = isStoredProcedure;
        }

        public void AddParameter(string ParameterName, object Value)
        {
            Parameters.Add(ParameterName, Value);
        }
    }
}
