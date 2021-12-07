namespace AoC{
    class Day6 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day6");
            lines = lines[0].Trim().Split(',');
            List<int> input = new List<int>();
            for(int i = 0; i < lines.Length; i++) input.Add(int.Parse(lines[i]));
            //process the input

            for(int d = 0; d < 80; d++){
                int amountToAdd = 0;
                for(int i = 0; i < input.Count; i++) { 
                    input[i]--; 
                    if (input[i] < 0) { 
                        amountToAdd++;
                        input[i] = 6;
                    }
                }
                for(int i = 0; i < amountToAdd; i++) input.Add(8);

                // Console.Write($"Day {d + 1}: ");
                // for (int i = 0; i < input.Count; i++) Console.Write($"{input[i]},");
                // Console.WriteLine();
            }
            Console.WriteLine(input.Count);
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day6");
            lines = lines[0].Trim().Split(',');
            long[] amountOFish = new long[9];
            for (int i = 0; i < lines.Length; i++) amountOFish[int.Parse(lines[i])]++;
            //process the input
            for(int d = 0; d < 256; d++){
                long newFish = amountOFish[0];
                amountOFish[0] = amountOFish[1];
                amountOFish[1] = amountOFish[2];
                amountOFish[2] = amountOFish[3];
                amountOFish[3] = amountOFish[4];
                amountOFish[4] = amountOFish[5];
                amountOFish[5] = amountOFish[6];
                amountOFish[6] = amountOFish[7] + newFish;
                amountOFish[7] = amountOFish[8];
                amountOFish[8] = newFish;
            }
            
            Console.WriteLine(amountOFish[0] + amountOFish[1] + amountOFish[2] + amountOFish[3] + amountOFish[4] +
                              amountOFish[5] + amountOFish[6] + amountOFish[7] + amountOFish[8]);

            // for(int d = 0; d < 256; d++){
            //     int amountToAdd = 0;
            //     for(int i = 0; i < input.Count; i++) { 
            //         input[i]--; 
            //         if (input[i] < 0) { 
            //             amountToAdd++;
            //             input[i] = 6;
            //         }
            //     }
            //     for(int i = 0; i < amountToAdd; i++) input.Add(8);

            //     // Console.Write($"Day {d + 1}: ");
            //     // for (int i = 0; i < input.Count; i++) Console.Write($"{input[i]},");
            //     // Console.WriteLine();
            // }
            // Console.WriteLine(input.Count);
        }
    }
}