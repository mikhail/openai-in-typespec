using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI.FineTuning;

[CodeGenModel("ListFineTuningJobEventsRequest")]
public class ListEventsOptions
{
    [CodeGenMember("JobId")]
    internal string OperationId { get; set; }

    [CodeGenMember("After")]
    public string After { get; set; }

    [CodeGenMember("Limit")]
    public int? PageSize { get; set; }
}
