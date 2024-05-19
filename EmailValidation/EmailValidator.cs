public class EmailValidator
{
	private enum State
	{
		Start,
		LocalPart,
		AtSymbol,
		DomainPart,
		DotInDomain,
		TldPart
	}

	public bool IsValidEmail(string email)
	{
		State state = State.Start;

		foreach (char ch in email)
		{
			switch (state)
			{
				case State.Start:
					if (char.IsLetterOrDigit(ch) || ch == '.' || ch == '_' || ch == '-')
					{
						state = State.LocalPart;
					}
					else
					{
						return false;
					}
					break;

				case State.LocalPart:
					if (char.IsLetterOrDigit(ch) || ch == '.' || ch == '_' || ch == '-')
					{
						state = State.LocalPart;
					}
					else if (ch == '@')
					{
						state = State.AtSymbol;
					}
					else
					{
						return false;
					}
					break;

				case State.AtSymbol:
					if (char.IsLetterOrDigit(ch))
					{
						state = State.DomainPart;
					}
					else
					{
						return false;
					}
					break;

				case State.DomainPart:
					if (char.IsLetterOrDigit(ch))
					{
						state = State.DomainPart;
					}
					else if (ch == '.')
					{
						state = State.DotInDomain;
					}
					else
					{
						return false;
					}
					break;

				case State.DotInDomain:
					if (char.IsLetterOrDigit(ch))
					{
						state = State.TldPart;
					}
					else
					{
						return false;
					}
					break;

				case State.TldPart:
					if (char.IsLetterOrDigit(ch))
					{
						state = State.TldPart;
					}
					else if (ch == '.')
					{
						state = State.DotInDomain;
					}
					else
					{
						return false;
					}
					break;

				default:
					return false;
			}
		}

		// Konečný stav
		return state == State.TldPart;
	}
}
