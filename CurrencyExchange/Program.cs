// Směnné kurzy
var rates = new List<Tuple<string, string, double>>
		{
			Tuple.Create("CZK", "EUR", 25.3),
			Tuple.Create("CZK", "USD", 24.1),
			Tuple.Create("EUR", "USD", 0.95),
			Tuple.Create("USD", "JPY", 17.3),
			Tuple.Create("HRK", "NOK", 0.25),
			Tuple.Create("EUR", "NOK", 7.1)
		};

// Počáteční a cílová měna
string startCurrency = "CZK";
string endCurrency = "NOK";

// Vytvoření grafu směnných kurzů
var graph = new Dictionary<string, List<ExchangeRate>>();
foreach (var rate in rates)
{
	if (!graph.ContainsKey(rate.Item1))
	{
		graph[rate.Item1] = new List<ExchangeRate>();
	}
	graph[rate.Item1].Add(new ExchangeRate(rate.Item1, rate.Item2));

	// Přidání opačné hrany pro neorientovaný graf (pokud je potřeba)
	//if (!graph.ContainsKey(rate.Item2))
	//{
	//	graph[rate.Item2] = new List<ExchangeRate>();
	//}
	//graph[rate.Item2].Add(new ExchangeRate(rate.Item2, rate.Item1));
}

// Nalezení nejkratší cesty
var path = FindShortestPath(graph, startCurrency, endCurrency);

// Výstup
if (path != null)
{
	foreach (var edge in path)
	{
		Console.WriteLine($"[{edge.From}, {edge.To}]");
	}
}
else
{
	Console.WriteLine("Žádná cesta nebyla nalezena.");
}

static List<ExchangeRate> FindShortestPath(Dictionary<string, List<ExchangeRate>> graph, string start, string end)
{
	var queue = new Queue<string>();
	var visited = new HashSet<string>();
	var parentMap = new Dictionary<string, ExchangeRate>();

	queue.Enqueue(start);
	visited.Add(start);

	while (queue.Count > 0)
	{
		var current = queue.Dequeue();

		if (current == end)
		{
			var path = new List<ExchangeRate>();
			while (parentMap.ContainsKey(current))
			{
				var edge = parentMap[current];
				path.Add(edge);
				current = edge.From;
			}
			path.Reverse();
			return path;
		}

		if (graph.ContainsKey(current))
		{
			foreach (var edge in graph[current])
			{
				if (!visited.Contains(edge.To))
				{
					queue.Enqueue(edge.To);
					visited.Add(edge.To);
					parentMap[edge.To] = edge;
				}
			}
		}
	}

	return null; // Pokud neexistuje cesta
}
