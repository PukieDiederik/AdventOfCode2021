namespace AoC{
    class Day8 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day8");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            string[,] inputPatterns = new string[lines.Length, 10];
            string[,] outputValues  = new string[lines.Length, 4];
            for(int i =0; i < lines.Length; i++){
                string[] split = lines[i].Split(' ');
                for(int j = 0; j < 10; j++) inputPatterns[i,j] = split[j];
                for(int j = 0; j < 4 ; j++) outputValues [i,j] = split[j + 11];
            }
            //process the input

            int a = 0;
            for(int i = 0; i < outputValues.GetLength(0); i++){
                for(int j =0; j < 4; j++){
                    if(outputValues[i,j].Length == 2 || outputValues[i,j].Length == 4 ||
                       outputValues[i,j].Length == 3 || outputValues[i,j].Length == 7){
                           a++;
                       }
                }
            }

            Console.WriteLine(a);
        }
    }
}