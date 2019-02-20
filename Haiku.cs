using System;
using System.Collections.Generic;
using System.IO;

public class Haiku
{
	private List<string> _articles;
	private List<string> _nouns;
	private List<string> _verbs;
	private List<string> _prepositions;
	private List<string> _adjectives;

	private Random _rand;

	public static void Main()
	{
		var haiku = new Haiku(/*"words.txt"*/);
		//* Write out all 4 patterns
		haiku.Pattern1();
		Console.WriteLine();
		haiku.Pattern2();
		Console.WriteLine();
		haiku.Pattern3();
		Console.WriteLine();
		haiku.Pattern4();
	}

	public Haiku(/*string wordfile*/)
	{
		_articles = new List<string>();
		_nouns = new List<string>();
		_verbs = new List<string>();
		_prepositions = new List<string>();
		_adjectives = new List<string>();
		_rand = new Random();
		Init();
	}

	/// <summary>
	/// Print a Haiku with the following pattern:
	///
	/// Article Adjective Noun...
	/// Article Noun Verb Preposition Article Noun
	/// Adjective Adjective Noun
	/// </summary>
	public void Pattern1()
	{
		string adj = Adjective();
		Console.WriteLine($"{GetArticle(adj)} {adj} {Noun()}...");

		string noun1 = Noun();
		string noun2 = Noun();
		Console.WriteLine($" {GetArticle(noun1)} {noun1} {Verb()} {Preposition()} {GetArticle(noun2)} {noun2}");

		Console.WriteLine($"  {Adjective()} {Adjective()} {Noun()}");
	}

	/// <summary>
	/// Print a Haiku with the following pattern:
	///
	/// Noun Preposition Article Noun;
	/// Article Adjective Noun Preposition Article Noun
	/// Adjective Noun
	/// </summary>
	public void Pattern2()
	{
		string noun1 = Noun();
		Console.WriteLine($"{Noun()} {Preposition()} {GetArticle(noun1)} {noun1};");

		string adj = Adjective();
		string noun2 = Noun();
		Console.WriteLine($" {GetArticle(adj)} {adj} {Noun()} {Preposition()} {GetArticle(noun2)} {noun2}");

		Console.WriteLine($"  {Adjective()} {Noun()}");
	}

	/// <summary>
	/// Print a Haiku with the following pattern:
	///
	/// Article Adjective Noun;
	/// Preposition Article Adjective Noun
	/// Article Noun Verb
	/// </summary>
	public void Pattern3()
	{
		string adj1 = Adjective();
		Console.WriteLine($"{GetArticle(adj1)} {adj1} {Noun()};");

		string adj2 = Adjective();
		Console.WriteLine($" {Preposition()} {GetArticle(adj2)} {adj2} {Noun()}");

		string noun2 = Noun();
		Console.WriteLine($"  {GetArticle(noun2)} {noun2} {Verb()}");
	}

	/// <summary>
	/// Print a Haiku with the following pattern:
	///
	/// Article Adjective Noun Verb;
	/// Article Adjective Non
	/// Preposition Article Adjective Noun
	/// </summary>
	public void Pattern4()
	{
		string adj1 = Adjective();
		Console.WriteLine($"{GetArticle(adj1)} {adj1} {Noun()} {Verb()};");

		string adj2 = Adjective();
		Console.WriteLine($" {GetArticle(adj2)} {adj2} {Noun()}");

		string adj3 = Adjective();
		Console.WriteLine($"  {Preposition()} {GetArticle(adj3)} {adj3} {Noun()}");
	}

	private string GetArticle(string nextWord)
	{
		int i = _rand.Next(_articles.Count);

		string art = _articles[i];
		if (art != "the") {
			if (art == "a" && (nextWord.StartsWith("a")
				|| nextWord.StartsWith("e") || nextWord.StartsWith("i")
				|| nextWord.StartsWith("o") || nextWord.StartsWith("u"))) {
				art = "an";
			}
			else if (art == "an") {
				art = "a";
			}
		}
		return art;
	}

    private string Adjective()
    {
        int i = _rand.Next(_adjectives.Count);
        return _adjectives[i];
    }

    private string Noun()
    {
        int i = _rand.Next(_nouns.Count);
        return _nouns[i];
    }

    private string Verb()
    {
        int i = _rand.Next(_verbs.Count);
        return _verbs[i];
    }

    private string Preposition()
    {
        int i = _rand.Next(_prepositions.Count);
        return _prepositions[i];
    }

    private void Init()
	{
		//* Note articles include an extra 'the' to make it more likely to appear
		_articles = new List<string> { "a", "an", "the", "the" };

		_adjectives = new List<string> {
			"autumn", "hidden", "bitter", "misty", "silent",
			"empty", "dry", "dark", "summer", "icy", "delicate", "quiet",
			"white", "cool", "spring", "winter", "dappled", "twilight", "dawn",
			"crimson", "wispy", "azure", "blue", "billowing", "broken", "cold",
			"damp", "falling", "frosty", "green", "long", "late", "lingering",
			"limpid", "still", "small", "sparkling", "throbbing", "vermilion",
			"wandering", "withered", "wild", "black", "young" };

		_nouns = new List<string> {
			"waterfall", "river", "breeze", "moon", "rain",
			"wind", "sea", "morning", "snow", "lake", "sunset", "pine",
			"shadow", "leaf", "dawn", "glitter", "forest", "hill", "cloud",
			"meadow", "sun", "glade", "bird", "brook", "butterfly", "bush",
			"dew", "dust", "field", "fir", "flower", "firefly", "feather",
			"grass", "haze", "mountain", "night", "pond", "shade", "snowflake",
			"silence", "sound", "sky", "shape", "surf", "thunder", "violet",
			"water", "wildflower", "wave" };

		_verbs = new List<string> {
			"shakes", "drifts", "has stopped", "struggles",
			"has fallen", "has passed", "sleeps", "creeps", "flutters",
			"has risen", "is falling", "is trickling", "murmurs", "is floating" };

		_prepositions = new List<string> { "on", "of", "in", "under", "over", "near" };
	}

	private void Init_old(string wordfile)
	{
		bool parseArticles = false;
		string[] lines = File.ReadAllLines(wordfile);
		List<string> wordCollector = new List<string>();

		foreach (string line in lines) {
			if (string.IsNullOrEmpty(line) || line.StartsWith("#")) {
				continue;
			}

			if (line.Trim().StartsWith("articles")) {
				parseArticles = true;
			}
			string[] words = line.Split(',');
			foreach (string word in words) {
				Console.WriteLine(word.Trim());
			}
		}
	}
}
