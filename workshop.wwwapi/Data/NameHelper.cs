namespace workshop.wwwapi.Data
{
    public static class NameHelper
    {
        private static List<string> _firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate",
            "Ozzy",
            "Tony",
            "Geezer",
            "Bill",
            "Ronnie",
            "Keith",
            "Charlie",
            "Brian",
            "Roger",
            "Ginger"
        };
        private static List<string> _lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton",
            "Osbourne",
            "Iommi",
            "Butler",
            "Ward",
            "Dio",
            "Moon",
            "Watts",
            "May",
            "Daltrey",
            "Baker"
        };

        public static string GetRandomName()
        {
            Random rnd = new Random();
            int firstIndex = rnd.Next(_firstnames.Count);
            int lastIndex = rnd.Next(_lastnames.Count);
            return $"{_firstnames[firstIndex]} {_lastnames[lastIndex]}";
        }

        public static bool NameCheck(string name)
        {
            if (string.IsNullOrEmpty(name) || name == "string")
            {
                return false;
            }
            return true;
        }
    }
}
