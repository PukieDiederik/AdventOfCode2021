namespace AoC{
    class Day2 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day2");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            //process the input
            int depth = 0;
            int forward = 0;

            for(int i = 0; i < lines.Length; i++){
                switch(lines[i][0]){
                    case 'u':
                        depth -= Int32.Parse(lines[i][3].ToString());
                        break;
                    case 'd':
                        depth += Int32.Parse(lines[i][5].ToString());
                        break;
                    case 'f':
                        forward += Int32.Parse(lines[i][8].ToString());
                        break;
                }
            }

            Console.WriteLine("depth: " + depth);
            Console.WriteLine("forward: " + forward);
            Console.WriteLine("Combined: " + (forward * depth));
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day2");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            //process the input
            int depth = 0;
            int forward = 0;
            int aim = 0;

            for(int i = 0; i < lines.Length; i++){
                switch(lines[i][0]){
                    case 'u':
                        aim -= Int32.Parse(lines[i][3].ToString());
                        break;
                    case 'd':
                        aim += Int32.Parse(lines[i][5].ToString());
                        break;
                    case 'f':
                        int amount = Int32.Parse(lines[i][8].ToString());
                        forward += amount;
                        depth += aim * amount;
                        break;
                }
            }

            Console.WriteLine("depth: " + depth);
            Console.WriteLine("forward: " + forward);
            Console.WriteLine("Combined: " + (forward * depth));
        }
    }
}