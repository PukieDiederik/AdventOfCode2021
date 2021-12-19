namespace AoC{
    class Day17 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day17");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            lines = lines[0].Split('=');
            lines = new string[] {lines[1].Split("..")[0], lines[1].Split("..")[1], lines[2].Split("..")[0], lines[2].Split("..")[1]};
            int[] input = new int[4];
            input[0] = int.Parse(lines[0]);
            input[1] = int.Parse(lines[1].Remove(lines[1].Length-3));
            input[2] = int.Parse(lines[2]);
            input[3] = int.Parse(lines[3]);

            Console.WriteLine($"{input[0]} {input[1]} {input[2]} {input[3]}");
            //process the input
            int lowestY = input[2] > input[3] ? input[3] : input[2];
            Console.WriteLine(((-lowestY - 1) / 2f) * -lowestY);
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day17");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            lines = lines[0].Split('=');
            lines = new string[] {lines[1].Split("..")[0], lines[1].Split("..")[1], lines[2].Split("..")[0], lines[2].Split("..")[1]};
            int[] input = new int[4];
            input[0] = int.Parse(lines[0]);
            input[1] = int.Parse(lines[1].Remove(lines[1].Length-3));
            input[2] = int.Parse(lines[2]);
            input[3] = int.Parse(lines[3]);

            Console.WriteLine($"{input[0]} {input[1]} {input[2]} {input[3]}");
            //process the input
            int lowestY  = input[2] > input[3] ? input[3] : input[2];
            int highestY = input[2] < input[3] ? input[3] : input[2];
            int lowestX  = input[0] < input[1] ? input[0] : input[1];
            int highestX = input[0] > input[1] ? input[0] : input[1];
            int totalUnique = 0;

            for(int x = 1; x <= highestX; x++){
                for(int y = lowestY; y < -lowestY; y++){
                    int yVel = y, xVel = x;
                    int yPos = 0, xPos = 0;
                    while(xPos <= highestX && yPos >= lowestY){
                        xPos += xVel;
                        yPos += yVel;
                        if(xPos >= lowestX && xPos <= highestX
                        && yPos >= lowestY && yPos <= highestY) {
                            totalUnique++;
                            break;
                        }
                        yVel--;
                        xVel--;
                        xVel = Math.Clamp(xVel, 0, int.MaxValue);
                    }
                }
            }

            Console.WriteLine(totalUnique);
        }
    }
}