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

        public static void Part2() {
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
            string[,] inputPatternsSorted = new string[inputPatterns.GetLength(0),10];
            for(int i = 0; i < inputPatterns.GetLength(0); i++){
                //get all the unique values
                for(int j = 0; j < 10; j++){
                    switch(inputPatterns[i,j].Length){
                        case 2: //1
                            inputPatternsSorted[i,1] = inputPatterns[i,j];
                            break;
                        case 4: //4
                            inputPatternsSorted[i,4] = inputPatterns[i,j];
                            break;
                        case 3: //7
                            inputPatternsSorted[i,7] = inputPatterns[i,j];
                            break;
                        case 7: //8
                            inputPatternsSorted[i,8] = inputPatterns[i,j];
                            break;
                    }
                }
                //figure out the 6 long values
                for(int j = 0; j < 10; j++){ //9,0,6
                    if(inputPatterns[i,j].Length==6){
                        if(AmountOfMatchingChars(inputPatternsSorted[i,1], inputPatterns[i,j]) == 2){ // 0, 9
                            if(AmountOfMatchingChars(inputPatternsSorted[i,4], inputPatterns[i,j]) == 4){ //9
                                inputPatternsSorted[i,9] = inputPatterns[i,j];
                            } else inputPatternsSorted[i,0] = inputPatterns[i,j];//0
                            
                        } else { //6
                            inputPatternsSorted[i,6] = inputPatterns[i,j];
                        }
                    }
                }

                //figure out the remaining values
                for(int j = 0; j < 10; j++){ // 2, 3, 5
                    if(inputPatterns[i,j].Length==5){
                        if(AmountOfMatchingChars(inputPatternsSorted[i,4], inputPatterns[i,j]) == 3){//5,3
                            if(AmountOfMatchingChars(inputPatternsSorted[i,6], inputPatterns[i,j]) == 5){
                                inputPatternsSorted[i,5] = inputPatterns[i,j];
                            } else inputPatternsSorted[i,3] = inputPatterns[i,j];//2
                        } else inputPatternsSorted[i,2] = inputPatterns[i,j];//2
                    }
                }
            }

            int total = 0;

            for(int i = 0; i < inputPatterns.GetLength(0); i++){
                System.Text.StringBuilder sb = new System.Text.StringBuilder(4);
                for(int j =0; j < 4; j++){
                    //get the correct char
                    for(int k = 0; k < 10; k++){
                        if(outputValues[i,j].Length == inputPatternsSorted[i,k].Length &&
                           AmountOfMatchingChars(inputPatternsSorted[i,k], outputValues[i,j]) == outputValues[i,j].Length){
                               sb.Append(k.ToString());
                               break;
                           }
                    }
                }
                total += Convert.ToInt32(sb.ToString());
            }

            Console.WriteLine(total);
        }

        static int AmountOfMatchingChars(string a, string b){
            int amount = 0;
            char[] ca = a.ToArray();
            for(int i =0; i < ca.Length; i++){
                for(int j = 0; j < b.Length; j++){
                    if(b[j] == ca[i]) amount++;
                }
            }

            return amount;
        }
        
    }
}