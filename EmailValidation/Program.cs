public class Program
{
	public static void Main()
	{
		var validator = new EmailValidator();

		string[] testEmails = {
			"jan.novak@mensagymnazium.cz",
			"jan.novak",
			"jan@.cz",
			"example@example.com",
			"example@domain.co.uk",
			"invalid@domain@domain.com",
			"@missinglocalpart.com"
		};

		foreach (string email in testEmails)
		{
			bool isValid = validator.IsValidEmail(email);
			Console.WriteLine($"{email}: {isValid}");
		}
	}
}
