using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LastMile.Web.Automation.BRUtilities
{
    public class CustomTestCaseOrderer : ITestCaseOrderer, IMessageSink
    {
        public const string TypeName = "LastMile.Web.Automation.BRUtilities.CustomTestCaseOrderer";
        public const string AssembyName = "LastMile.Web.Automation";
        //public const string AssembyName = "MarketPlace.Automation.TransportNew.Automation.Platform";
        public static readonly ConcurrentDictionary<string, ConcurrentQueue<string>>
            QueuedTests = new ConcurrentDictionary<string, ConcurrentQueue<string>>();


        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
            IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            return testCases.OrderBy(GetOrder);
        }

        private static int GetOrder<TTestCase>(
            TTestCase testCase)
            where TTestCase : ITestCase
        {
            // Enqueue the test name.
            QueuedTests
                .GetOrAdd(
                    testCase.TestMethod.TestClass.Class.Name,
                    key => new ConcurrentQueue<string>())
                .Enqueue(testCase.TestMethod.Method.Name);
            // Order the test based on the attribute.
            var attr = testCase.TestMethod.Method
               .ToRuntimeMethod()
           .GetCustomAttribute<OrderAttribute>();
            return attr?.I ?? 0;
        }
        private readonly IMessageSink diagnosticMessageSink;

        public CustomTestCaseOrderer(IMessageSink diagnosticMessageSink)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;
        }

        public bool OnMessage(IMessageSinkMessage message)

        {
            return true;
        }
    }
    public class OrderAttribute : Attribute
    {
        public int I { get; }

        public OrderAttribute(int i)
        {
            Console.WriteLine("sdsdsd");
            I = i;
        }
    }
}
