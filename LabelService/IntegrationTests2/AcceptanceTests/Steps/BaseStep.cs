using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public abstract class BaseStep : TechTalk.SpecFlow.Steps
    {
        protected LabelDTO Label { get; }
        protected LabellingServer Server { get; }

        protected string pathToSampleLabel = "..\\..\\..\\acceptanceTestSampleLabel.txt";

        public BaseStep(LabelDTO label, LabellingServer server)
        {
            Label = label;
            Server = server;
        }

        protected string Read(Stream stream)
        {
            int size = 1024;
            int consumed = 0;
            byte[] bytes = new byte[size];
            StringBuilder responseBuilder = new StringBuilder();

            using (stream)
            {
                while (stream.CanRead)
                {
                    stream.Read(bytes, consumed, size);
                    responseBuilder.Append(Encoding.UTF8.GetString(bytes));
                }
            }

            return responseBuilder.ToString();
        }
    }
}
