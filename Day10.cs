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
    }
}