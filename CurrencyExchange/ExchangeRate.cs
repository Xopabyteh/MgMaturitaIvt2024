// Reprezentuje hranu v grafu směnných kurzů
public class ExchangeRate
{
	public string From { get; set; }
	public string To { get; set; }
	public ExchangeRate(string from, string to)
	{
		From = from;
		To = to;
	}
}
