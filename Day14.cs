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
    }
}