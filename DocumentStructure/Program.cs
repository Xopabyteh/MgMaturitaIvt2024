using System.Text.RegularExpressions;

var testInput = 
    """
    {START:outer}
        {START:inner}text
        text{END:inner}
    {END:outer}
    """;

var valid = Validate(testInput);
Console.WriteLine(valid);

static bool Validate(string input)
{
    // Regex to match {START:xyz} or {END:xyz}
    // Split into groups START/END and tag value (xyz)
    var startEndGroupsRegex = new Regex(@"\{(START|END):([^}]+)\}");
    var startEndMatches = startEndGroupsRegex.Matches(input);

    // Holds values of tags
    var structureStack = new Stack<string>();

    foreach (var match in startEndMatches.ToArray())
    {
        var tag = match.Groups[1]; // START, END
        var tagValue = match.Groups[2]; // xyz

        if(tag.Value == "START")
        {
            structureStack.Push(tagValue.Value);
        }
        else if(tag.Value == "END")
        {
            if(structureStack.Count == 0)
            {
                return false;
            }

            var lastTagValue = structureStack.Pop();
            if(lastTagValue != tagValue.Value)
            {
                return false;
            }
        }
    }

    return true;
}