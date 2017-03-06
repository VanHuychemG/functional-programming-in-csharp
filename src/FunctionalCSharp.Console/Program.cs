using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using FunctionalCSharp.DaveFancher;

namespace FunctionalCSharp.Console
{
    public class Program
    {
        public static Func<IDictionary<int, string>, string> BuildSelectBox(string id, bool includeUnknown) =>
            options =>
                new StringBuilder()
                    .AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)
                    .When(
                        () => includeUnknown,
                        sb => sb.AppendFormattedLine("\t<option>{0}</option>", "unknown"))
                    .AppendSequence(
                        options,
                        (sb, opt) => sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
                    .AppendLine("</option>")
                    .ToString();

        public static void Main(string[] args)
        {
            // Transformation Pipeline
            Disposable
                .Using(
                    StreamFactory.GetStream,
                    stream => new byte[stream.Length].Tee(b => stream.Read(b, 0, (int)stream.Length)))
                .Map(Encoding.UTF8.GetString)
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select((s, ix) => Tuple.Create(ix, s))
                .ToDictionary(k => k.Item1, v => v.Item2)
                .Map(BuildSelectBox("theDoctors", true))
                .Tee(System.Console.WriteLine);
            System.Console.WriteLine();

            // String Validation Pipeline
            "Doctor Who"
                .Map(StringValidations.IsNotNull)
                .Bind(StringValidations.IsNotEmpty)
                .Bind(StringValidations.MinLength(8))
                .Map(result => result.IsSuccess
                    ? result.SuccessValue
                    : result.FailureValue)
                .Tee(System.Console.WriteLine);
            System.Console.WriteLine();

            "Who?"
                .Map(StringValidations.IsNotNull)
                .Bind(StringValidations.IsNotEmpty)
                .Bind(StringValidations.MinLength(8))
                .Map(result => result.IsSuccess
                    ? result.SuccessValue
                    : result.FailureValue)
                .Tee(System.Console.WriteLine);
            System.Console.WriteLine();

            var time =
                Disposable
                    .Using(
                        () => new System.Net.Http.HttpClient(),
                        client => XDocument.Parse(client.GetStringAsync("http://time.gov/actualtime.cgi").Result))
                    .Root
                    .Attribute("time")
                    .Value;

            var ms = Convert.ToInt64(time) / 1000;
            var currentTime = new DateTime(1970, 1, 1).AddMilliseconds(ms).ToLocalTime();

            System.Console.WriteLine(currentTime);
            System.Console.WriteLine();
        }
    }
}
