namespace AoC{
    class Day10 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day10");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            //process the input


            List<char> errors = new List<char>();
            for(int i = 0; i < lines.Length; i++){
                Stack<char> charStack = new Stack<char>();
                for(int j = 0; j < lines[i].Length; j++){
                    if(lines[i][j] == '<' || lines[i][j] == '{' || lines[i][j] == '[' || lines[i][j] == '('){
                        charStack.Push(lines[i][j]);
                    } else {
                        char c = charStack.Peek();
                        if(c == '{' && lines[i][j] == '}') charStack.Pop();
                        else if(c == '(' && lines[i][j] == ')') charStack.Pop();
                        else if(c == '[' && lines[i][j] == ']') charStack.Pop();
                        else if(c == '<' && lines[i][j] == '>') charStack.Pop();
                        else {
                            errors.Add(lines[i][j]);
                            break;
                        }
                        
                    }
                }
            }

            int points = 0;
            for(int i = 0; i < errors.Count(); i++){
                switch(errors[i]){
                    case ')': points +=3; break;
                    case ']': points +=57; break;
                    case '}': points +=1197; break;
                    case '>': points +=25137; break;
                }
            }
            Console.WriteLine(points);
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day10");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            List<string> input = new List<string>();
            //process the input


            List<char> errors = new List<char>();
            bool hasError = false;
            for(int i = 0; i < lines.Length; i++){
                Stack<char> charStack = new Stack<char>();
                for(int j = 0; j < lines[i].Length; j++){
                    if(lines[i][j] == '<' || lines[i][j] == '{' || lines[i][j] == '[' || lines[i][j] == '('){
                        charStack.Push(lines[i][j]);
                    } else {
                        char c = charStack.Peek();
                        if(c == '{' && lines[i][j] == '}') charStack.Pop();
                        else if(c == '(' && lines[i][j] == ')') charStack.Pop();
                        else if(c == '[' && lines[i][j] == ']') charStack.Pop();
                        else if(c == '<' && lines[i][j] == '>') charStack.Pop();
                        else {
                            errors.Add(lines[i][j]);
                            hasError = true;
                            break;
                        }
                    }
                }
                if(!hasError) {
                    input.Add(new string(charStack.ToArray()));
                }
                hasError = false;
            }

            //calculate the score
            long[] scores = new long[input.Count()];
            for(int i = 0; i < input.Count(); i++){
                for(int j = 0; j < input[i].Length; j++){
                    if (input[i][j] == '(') scores[i] = (scores[i] * 5) + 1;
                    else if (input[i][j] == '[') scores[i] = (scores[i] * 5) + 2;
                    else if (input[i][j] == '{') scores[i] = (scores[i] * 5) + 3;
                    else if (input[i][j] == '<') scores[i] = (scores[i] * 5) + 4;
                }
            }

            Array.Sort(scores);
            Console.WriteLine(scores[scores.Length >> 1]);
        }
    }
}