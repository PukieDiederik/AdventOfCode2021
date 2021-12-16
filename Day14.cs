using System.Diagnostics;
namespace AoC{
    class Day14 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day14");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();

            char[] template = lines[0].ToCharArray();
            Dictionary<string, char> d = new Dictionary<string, char>(); 
            for(int i = 2; i < lines.Length; i++) d.Add(lines[i].Substring(0,2), lines[i][6]);

            //process the input
            for(int s = 0; s < 10; s++){
                char[] newTemplate = new char[(template.Length << 1) - 1];
                for(int i = 0; i < template.Length - 1; i++){
                    newTemplate[i << 1] = template[i];
                    newTemplate[(i << 1) + 1] = d[new string(new char[]{template[i], template[i+1]})];
                }
                newTemplate[(template.Length << 1) -2] = template[template.Length-1];
                template = newTemplate;
            }

            Dictionary<char, int> ocurrences = new Dictionary<char, int>();

            for(int i = 0; i < template.Length; i++){
                if(ocurrences.ContainsKey(template[i])){
                    ocurrences[template[i]]++;
                } else {
                    ocurrences.Add(template[i], 1);
                }
            }

            KeyValuePair<char,int> most = new KeyValuePair<char,int>('.', 0);
            KeyValuePair<char,int> least = new KeyValuePair<char,int>('.', 0x7fffffff);
            char[] keys = ocurrences.Keys.ToArray();
            for(int i = 0; i < ocurrences.Count; i++){
                if(ocurrences[keys[i]] > most.Value) most = new KeyValuePair<char, int>(keys[i], ocurrences[keys[i]]);
                if(ocurrences[keys[i]] < least.Value) least = new KeyValuePair<char, int>(keys[i], ocurrences[keys[i]]);
            }

            Console.WriteLine(most.Value - least.Value);

        }

        public static void Part2() {

            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day14");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();

            string template = lines[0];
            Dictionary<string, char> d = new Dictionary<string, char>();
            Dictionary<string, ulong> zeroDict = new Dictionary<string, ulong>();
            for(int i = 2; i < lines.Length; i++) {
                d.Add(lines[i].Substring(0,2), lines[i][6]);
                zeroDict.Add(lines[i].Substring(0,2), 0L);
            }

            string[] keys = d.Keys.ToArray();

            //process the input
            Dictionary<string, ulong> oldDict = new Dictionary<string, ulong>(zeroDict);
            for(int i = 0; i < template.Length - 1; i++){
                oldDict[template.Substring(i,2)]++;
            }
            for(int s = 0; s < 40; s++){
                Dictionary<string, ulong> newDict = new Dictionary<string, ulong>(zeroDict);
                for(int i = 0; i < keys.Length; i++){
                    newDict[new string(new char[] {d[keys[i]], keys[i][1]})] += oldDict[keys[i]];
                    newDict[new string(new char[] {keys[i][0], d[keys[i]]})] += oldDict[keys[i]];
                }
                oldDict = newDict;
            }

            KeyValuePair<char,ulong> most  = new KeyValuePair<char,ulong>('.', 0);
            KeyValuePair<char,ulong> least = new KeyValuePair<char,ulong>('.', 0xffffffffffffffff);

            Dictionary<char, ulong> charC = new Dictionary<char, ulong>();
            for(int i = 0; i < keys.Length; i++){
                for(int j = 0; j < 2; j++){
                    if(charC.ContainsKey(keys[i][j])){
                        charC[keys[i][j]] += oldDict[keys[i]];
                    } else {
                        charC.Add(keys[i][j], oldDict[keys[i]]);
                    }
                }
            }

            char[] cKeys = charC.Keys.ToArray();
            for(int i = 0; i < charC.Count(); i++){
                if(charC[cKeys[i]] > most.Value) most   = new KeyValuePair<char, ulong>(cKeys[i], charC[cKeys[i]]);
                if(charC[cKeys[i]] < least.Value) least = new KeyValuePair<char, ulong>(cKeys[i], charC[cKeys[i]]);
            }

            Console.WriteLine($"most: {most.Key}, {most.Value /2}");
            Console.WriteLine($"least: {least.Key}, {least.Value /2}");
            Console.WriteLine($"total: {(most.Value - least.Value) / 2}");
        }
    }
}