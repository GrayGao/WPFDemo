using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.Event
{
    public class MessageEvent : PubSubEvent<string>
    {
    }

    public class TestEvent : PubSubEvent<Test>
    {
    }

    public class Test
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
