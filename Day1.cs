namespace AoC{
    class Day1 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day1");
            int[] input = new int[lines.Length];
            for(int i = 0; i < lines.Length; i++ ) input[i] = Int32.Parse(lines[i].Trim());
            //process the input
            int increaseCounter = 0;
            int prev = input[0];

            for (int i = 1; i < input.Length; i++){
                if(input[i] > prev) increaseCounter++;
                prev = input[i];
            }

            Console.WriteLine("amount of increases: " + increaseCounter);
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day1");
            int[] input = new int[lines.Length];
            for(int i = 0; i < lines.Length; i++ ) input[i] = Int32.Parse(lines[i].Trim());
            //process the input
            int increaseCounter = 0;
            int prev = input[0] + input[1] + input[2];

            for (int i = 1; i < input.Length - 2; i++){
                int sum = input[i] + input[i + 1] + input[i+2];
                if(sum > prev) increaseCounter++;
                prev = sum;
            }

            Console.WriteLine("amount of increases: " + increaseCounter);
        }
    }
}