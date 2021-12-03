namespace AoC{
    class Day3 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day3");
            short[] input = new short[lines.Length];
            for(int i = 0; i < lines.Length; i++ ) input[i] = Convert.ToInt16(lines[i].Trim(), 2);

            //process the input
            int[] numOfOnBit = new int[12];

            //count the number of zeros and ones
            for(int i = 0; i < lines.Length; i++){
                for(int j = 0; j < 12; j++){
                    numOfOnBit[11 - j] += (input[i] >> j) & 1;
                }
            }

            Console.WriteLine(numOfOnBit[11]);

            int halfWayPoint = input.Length >> 1;
            int finalGammaNum = 0;
            for(int i = 0; i < 12; i++){
                if (numOfOnBit[i] > halfWayPoint) finalGammaNum += 1;
                finalGammaNum = finalGammaNum << 1;
            }
            finalGammaNum = finalGammaNum >> 1;

            int finalEpsilonNum = (~finalGammaNum) & 4095;

            Console.WriteLine(Convert.ToString(finalGammaNum, 2));
            Console.WriteLine(Convert.ToString(finalEpsilonNum, 2));
            Console.WriteLine(finalGammaNum);
            Console.WriteLine(finalEpsilonNum);

            Console.WriteLine(finalGammaNum * finalEpsilonNum);
        }
    }
}