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

            int halfWayPoint = input.Length >> 1;
            int finalGammaNum = 0;
            for(int i = 0; i < 12; i++){
                if (numOfOnBit[i] > halfWayPoint) finalGammaNum += 1;
                finalGammaNum = finalGammaNum << 1;
            }
            finalGammaNum = finalGammaNum >> 1;

            int finalEpsilonNum = (~finalGammaNum) & 4095;

            Console.WriteLine(finalGammaNum * finalEpsilonNum);
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day3");
            int[] input = new int[lines.Length];
            for(int i = 0; i < lines.Length; i++ ) input[i] = Convert.ToInt32(lines[i].Trim(), 2);
            Array.Sort(input, (a,b) => b-a);

            int botPointer = input.Length-1, topPointer = 0;
            int currentBitPos = 11;
            //oxygen generator
            while(topPointer != botPointer && topPointer < botPointer && currentBitPos >= 0){
                int mask = 1 << currentBitPos;
                bool MCBT = (input[(botPointer + topPointer) >> 1] & mask) > 0 ? true: false;
                
                // move the bot pointer
                if(MCBT){
                    while((input[botPointer] & mask) == 0){
                        botPointer--;
                    }
                }
                // move the top pointer
                if(!MCBT){
                    while((input[topPointer] & mask) != 0){
                        topPointer++;
                    }
                }

                // move on to the next bitposition
                currentBitPos--;
            }
            int oxyRating = input[botPointer];
            Console.WriteLine("oxygen rating: " + oxyRating);

            // Array.Reverse(input);
            botPointer = input.Length-1; topPointer = 0;
            currentBitPos = 11;
            //oxygen generator
            while(topPointer != botPointer && topPointer < botPointer && currentBitPos >= 0){
                int mask = 1 << currentBitPos;
                bool MCBT = (input[(botPointer + topPointer) >> 1] & mask) > 0 ? false: true;
                
                // move the bot pointer
                if(MCBT){
                    while((input[botPointer] & mask) == 0){
                        botPointer--;
                    }
                }
                // move the top pointer
                if(!MCBT){
                    while((input[topPointer] & mask) != 0){
                        topPointer++;
                    }
                }

                // move on to the next bitposition
                currentBitPos--;
            }
            int scrubRating = input[botPointer];
            Console.WriteLine("scrubber rating: " + scrubRating);

        }
    }
}