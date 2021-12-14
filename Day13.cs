namespace AoC{
    class Day13 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day13");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            int splitLine = 0;
            for(int i = 0; i < lines.Length; i++){ if(lines[i] == "") { splitLine = i; break; } }
            int[][] input = new int[splitLine][];
            for(int i = 0; i < splitLine; i++) {
                string[] split = lines[i].Split(',');
                input[i] = new int[] {int.Parse(split[0]),int.Parse(split[1])};
            }

            int[] instructions = new int[lines.Length - (splitLine + 1)];
            bool[] isInstructionHor = new bool[lines.Length - (splitLine + 1)];
            for(int i = 0; i < lines.Length - (splitLine + 1); i++){
                string[] split = lines[splitLine + 1 + i].Split('=');
                instructions[i] = int.Parse(split[1]);
                isInstructionHor[i] = split[0]["split along".Length] == 'x';
            }
            //process the input

            //process instructions
            for(int i = 0; i < 1; i++){
                 if(isInstructionHor[i]){
                     for(int j = 0; j < input.Length; j++){
                        if(input[j][0] >= instructions[i]){
                            input[j][0] = instructions[i] - (input[j][0] - (instructions[i]));
                        }
                     }
                 } else{
                     for(int j = 0; j < input.Length; j++){
                        if(input[j][1] >= instructions[i]){
                            input[j][1] = instructions[i] - (input[j][1] - (instructions[i]));
                        }
                     }
                 }
            }
            //remove duplicates
            List<int[]> nonDuplicate = new List<int[]>();
            for(int i = 0; i < input.Length; i++){
                bool foundDuplicate = false;
                for(int j = 0; j < nonDuplicate.Count(); j++){
                    if(nonDuplicate[j][0] == input[i][0]
                    && nonDuplicate[j][1] == input[i][1]){
                        foundDuplicate = true;
                        break;
                    }
                }
                if(!foundDuplicate) nonDuplicate.Add(input[i]);
            }
            Console.WriteLine(nonDuplicate.Count());
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day13");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            int splitLine = 0;
            for(int i = 0; i < lines.Length; i++){ if(lines[i] == "") { splitLine = i; break; } }
            int[][] input = new int[splitLine][];
            for(int i = 0; i < splitLine; i++) {
                string[] split = lines[i].Split(',');
                input[i] = new int[] {int.Parse(split[0]),int.Parse(split[1])};
            }

            int[] instructions = new int[lines.Length - (splitLine + 1)];
            bool[] isInstructionHor = new bool[lines.Length - (splitLine + 1)];
            for(int i = 0; i < lines.Length - (splitLine + 1); i++){
                string[] split = lines[splitLine + 1 + i].Split('=');
                instructions[i] = int.Parse(split[1]);
                isInstructionHor[i] = split[0]["split along".Length] == 'x';
            }
            //process the input

            //process instructions
            for(int i = 0; i < instructions.Length; i++){
                 if(isInstructionHor[i]){
                     for(int j = 0; j < input.Length; j++){
                        if(input[j][0] >= instructions[i]){
                            input[j][0] = instructions[i] - (input[j][0] - (instructions[i]));
                        }
                     }
                 } else{
                     for(int j = 0; j < input.Length; j++){
                        if(input[j][1] >= instructions[i]){
                            input[j][1] = instructions[i] - (input[j][1] - (instructions[i]));
                        }
                     }
                 }
            }
            //remove duplicates
            List<int[]> nonDuplicate = new List<int[]>();
            int biggestX = 0, biggestY = 0;
            for(int i = 0; i < input.Length; i++){
                bool foundDuplicate = false;
                for(int j = 0; j < nonDuplicate.Count(); j++){
                    if(nonDuplicate[j][0] == input[i][0]
                    && nonDuplicate[j][1] == input[i][1]){
                        foundDuplicate = true;
                        break;
                    }
                }
                if(!foundDuplicate) {
                    nonDuplicate.Add(input[i]);
                    if(input[i][0] > biggestX) biggestX = input[i][0];
                    if(input[i][1] > biggestY) biggestY = input[i][1];
                }
            }

            //printing
            bool[,] map = new bool[biggestX + 1,biggestY + 1];
            for(int i = 0; i < nonDuplicate.Count(); i++){
                map[nonDuplicate[i][0], nonDuplicate[i][1]] = true;
            }

            for (int y = 0; y < map.GetLength(1); y++){
                for (int x = 0; x < map.GetLength(0); x++){
                    Console.Write(map[x,y] ? '#' : '.');
                }
                Console.WriteLine();
            }
        }
    }
}