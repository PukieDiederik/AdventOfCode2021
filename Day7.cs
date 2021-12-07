namespace AoC{
    class Day7 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day7");
            lines = lines[0].Trim().Split(',');
            int[] input = new int[lines.Length];
            for(int i = 0; i < input.Length; i++) input[i] = int.Parse(lines[i]);
            //process the input
            //find highest num
            int highestNum = 0;
            for(int i = 0; i < input.Length; i++) if(input[i]>highestNum) highestNum = input[i];

            int minFuel = (int)0x0fffffff;
            for(int i = 0; i < highestNum; i++){
                //calculate fuel
                int fuel = 0;
                for(int j =0; j < input.Length; j++){
                    fuel += Math.Abs(input[j] - i);
                }
                if (fuel < minFuel) minFuel = fuel;
            }

            Console.WriteLine(minFuel);
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day7");
            lines = lines[0].Trim().Split(',');
            int[] input = new int[lines.Length];
            for(int i = 0; i < input.Length; i++) input[i] = int.Parse(lines[i]);
            //process the input
            //find highest num
            int highestNum = 0;
            for(int i = 0; i < input.Length; i++) if(input[i]>highestNum) highestNum = input[i];

            //create fuel lookup table
            int[] fuelLookupTable = new int[highestNum + 1];
            fuelLookupTable[0] = 0;
            for(int i = 1; i < highestNum; i++) fuelLookupTable[i] = i + fuelLookupTable[i-1];

            int minFuel = (int)0x0fffffff;
            for(int i = 0; i < highestNum; i++){
                //calculate fuel
                int fuel = 0;
                for(int j =0; j < input.Length; j++){
                    fuel += fuelLookupTable[Math.Abs(input[j] - i)];
                }
                if (fuel < minFuel) minFuel = fuel;
            }

            Console.WriteLine(minFuel);
        }


    }
}