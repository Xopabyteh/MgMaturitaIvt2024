using System.Text.RegularExpressions;

string input = """
	{START:outer}
		text
		{START:inner}text{END:inner}
	{END:outer}
	""";

Console.WriteLine(IsValidStructure(input) ? "VALID" : "INVALID");

bool IsValidStructure(string text)
{
	var stack = new Stack<string>();
	var regex = new Regex(@"\{(START|END):([^\}]+)\}");
	var matches = regex.Matches(text);

	foreach (Match match in matches)
	{
		string tag = match.Groups[1].Value;
		string name = match.Groups[2].Value;

		if (tag == "START")
		{
			stack.Push(name);
		}
		else if (tag == "END")
		{
			if (stack.Count == 0 || stack.Pop() != name)
			{
				return false;
			}
		}
	}

	return stack.Count == 0;
}

