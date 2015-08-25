using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace zmw.dev.Workflow
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new Flowchart());
        }
    }
}
