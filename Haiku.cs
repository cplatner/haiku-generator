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

	public static void Main()
	{
		Haiku haiku = new Haiku("words.txt");
		haiku.Pattern1();
	}

	public Haiku(string wordfile)
	{
		_articles = new List<string>();
		_nouns = new List<string>();
		_verbs = new List<string>();
		_prepositions = new List<string>();
		_adjectives = new List<string>();
		Init();
	}
	
	public void Pattern1()
	{
		Console.WriteLine(string.Format("{0} {1} {2}...",
			Article, Adjective, Noun));
	}
	
	public string Article {
		get 
		{ 
			int i = Math.Random(_articles.Length);
			return _articles[i];
		}
	}
	
	public string Adjective {
		get 
		{ 
			int i = Math.Random(_adjectives.Length);
			return _adjectives[i];
		}
	}

	public string Noun {
		get 
		{ 
			int i = Math.Random(_nouns.Length);
			return _nouns[i];
		}
	}

	public void Init()
	{
		_articles = new List<string>();
		_articles.AddRange(
			new string[] { "a", "an", "the" });

		_adjectives = new List<string>();
		_adjectives.AddRange(
			new string[] { "autumn", "hidden", "bitter", "misty", "silent", 
			"empty", "dry", "dark", "summer", "icy", "delicate", "quiet", 
			"white", "cool", "spring", "winter", "dappled", "twilight", "dawn", 
			"crimson", "wispy", "azure", "blue", "billowing", "broken", "cold", 
			"damp", "falling", "frosty", "green", "long", "late", "lingering", 
			"limpid", "still", "small", "sparkling", "throbbing", "vermilion", 
			"wandering", "withered", "wild", "black", "young" });

		_nouns = new List<string>();
		_nouns.AddRange(
			new string[] { "waterfall", "river", "breeze", "moon", "rain", 
			"wind", "sea", "morning", "snow", "lake", "sunset", "pine", 
			"shadow", "leaf", "dawn", "glitter", "forest", "hill", "cloud", 
			"meadow", "sun", "glade", "bird", "brook", "butterfly", "bush", 
			"dew", "dust", "field", "fir", "flower", "firefly", "feather",
			"grass", "haze", "mountain", "night", "pond", "shade", "snowflake", 
			"silence", "sound", "sky", "shape", "surf", "thunder", "violet", 
			"water", "wildflower", "wave" });

		_verbs = new List<string>();
		_verbs.AddRange(
			new string[] { "shakes", "drifts", "has stopped", "struggles", 
			"has fallen", "has passed", "sleeps", "creeps", "flutters", 
			"has risen", "is falling", "is trickling", "murmurs", "is floating" });

		_prepositions = new List<string>();
		_prepositions.AddRange(
			new string[] { "on", "of", "in", "under", "over", "near" });

	}
	
	public void Init_old(string wordfile)
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
