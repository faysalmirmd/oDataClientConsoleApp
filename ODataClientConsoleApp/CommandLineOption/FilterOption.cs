using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("filter", HelpText = "filter by oData filter query param with parameter -f \"<filterQueryValue>\" i.e -f \"FirstName eq 'Scott'\" \n" +
                                        " Operator Options:\n" +
                                        "  Equal: eq\n" +
                                        "  Not Equal: ne\n" +
                                        "  Greater Than: gt\n" +
                                        "  Greater Than or Equal: ge\n" +
                                        "  Less Than: lt\n" +
                                        "  Less Than or Equal: le\n" +
                                        " Filter phrases:\n" +
                                        "   contains(PropertyName,'Value')\n" +
                                        "   startswith(PropertyName,'Value')\n" +
                                        "   endswith(Property1,'Value1')\n" +
                                        "   indexOf(Property1,'Value1') eq 1\n" +
                                        "   length(Property1) eq 19\n" +
                                        "   substring(Property1, 1, 2) eq 'ab'\n" +
                                        "and/or can be applied i.e Property1 eq 'Value1' and Property2 eq 'Value2'\n" +
                                        "Note: Double quote(\"\") is required around parameter values containing spaces i. e the filter query")]
    public class FilterOption
    {
        [Option('f', "FilterQuery", Required = true, HelpText = "OData Filter Query Parameter", Default = "")]
        public string FilterQuery { get; set; }
    }
}
