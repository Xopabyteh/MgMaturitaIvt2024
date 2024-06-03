string[] testEmails = [
    "jan.novak@mensagymnazium.cz",
    "jan.novak",
    "jan@.cz",
    "@a.b",
    "a@b.c",
    "a@b",
    "a@b."
];

foreach (var email in testEmails)
{
    Console.WriteLine($"{email,-32} | {IsEmailValid(email)}");
}

static bool IsEmailValid(ReadOnlySpan<char> email)
{
    State state = State.Start;

	foreach (var c in email)
	{
        switch (state)
        {
            case State.Start:
                if(char.IsLetterOrDigit(c))
                {
                    state = State.CharacterBeforeAt;
                    continue;
                }
                return false; // We must start with a char
            case State.CharacterBeforeAt:
                if(char.IsLetterOrDigit(c))
                {
                    state = State.CharacterBeforeAt;
                    continue;
                }
                else if(c == '.')
                {
                    state = State.DotBeforeAt;
                    continue;
                }
                else if(c == '@')
                {
                    state = State.At;
                    continue;
                }
                return false; // char -> char, . or @
            case State.DotBeforeAt:
                if(char.IsLetterOrDigit(c))
                {
                    state = State.CharacterBeforeAt;
                    continue;
                }
                return false; // . -> char
            case State.At:
                if(char.IsLetterOrDigit(c))
                {
                    state = State.CharacterAfterAt;
                    continue;
                }
                return false; // @ -> char
            case State.CharacterAfterAt:
                if(char.IsLetterOrDigit(c))
                {
                    state = State.CharacterAfterAt;
                    continue;
                }
                else if(c == '.')
                {
                    state = State.DotAfterAt;
                    continue;
                }
                return false; // char -> char or .
            case State.DotAfterAt:
                if(char.IsLetterOrDigit(c))
                {
                    state = State.CharacterAfterAt;
                    continue;
                }
                return false; // . -> char
        }
    }

    // We should end at a character after at
    return state == State.CharacterAfterAt;
}

enum State
{
    Start,
	CharacterBeforeAt,
	DotBeforeAt,
	At,
	CharacterAfterAt, // Also end state
	DotAfterAt
}