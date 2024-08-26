using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI.FineTuning;

[CodeGenModel("ListFineTuningJobEventsResponse")]
public partial class FineTuningJobEventsList
{
    [CodeGenMember("Object")]
    public string _object;

    [CodeGenMember("ListFineTuningJobEventsResponseData")]
    public IEnumerable<FineTuningJobEvent> Data;
    
} 
