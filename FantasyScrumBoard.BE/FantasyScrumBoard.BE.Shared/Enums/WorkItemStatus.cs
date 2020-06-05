using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Enums
{
    public enum WorkItemStatus
    {
        Unspecified = 0,
        ToDo = 10,
        InProgress = 20,
        InCodeReview = 30,
        Testing = 40,
        Done = 50
    }
}
