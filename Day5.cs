namespace AoC{
    class Day5 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day5");
            Line[] input = new Line[lines.Length];
            for(int i = 0; i < lines.Length; i++ ) {
                string[] splitSpace = lines[i].Trim().Split(' ');
                string[] set1 = splitSpace[0].Split(',');
                string[] set2 = splitSpace[2].Split(',');
                
                input[i] = new Line(int.Parse(set1[0]), int.Parse(set1[1]), int.Parse(set2[0]), int.Parse(set2[1]));
            }
            //process the input

            //figure out what the size of this map is
            int biggestPosx = 0;
            int biggestPosy = 0;

            for(int i = 0; i < input.Length; i++){
                if(input[i].x1 > biggestPosx) biggestPosx = input[i].x1;
                if(input[i].x2 > biggestPosx) biggestPosx = input[i].x2;
                if(input[i].y1 > biggestPosy) biggestPosy = input[i].y1;
                if(input[i].y2 > biggestPosy) biggestPosy = input[i].y2;
            }

            int[,] map = new int[biggestPosx + 1, biggestPosy + 1];

            //map all the straight coords
            for(int i = 0; i < input.Length; i++){
                if(input[i].x1 == input[i].x2){
                    int biggestNum  = input[i].y1 >= input[i].y2 ? input[i].y1 : input[i].y2;
                    int smallestNum = input[i].y1 >= input[i].y2 ? input[i].y2 : input[i].y1;
                    for(int j = smallestNum; j <= biggestNum; j++){
                        map[input[i].x1, j]++;
                    }
                }
                else if (input[i].y1 == input[i].y2){
                    int biggestNum  = input[i].x1 >= input[i].x2 ? input[i].x1 : input[i].x2;
                    int smallestNum = input[i].x1 >= input[i].x2 ? input[i].x2 : input[i].x1;
                    for(int j = smallestNum; j <= biggestNum; j++){
                        map[j, input[i].y1]++;
                    }
                }
            }
            int amountOfDanger = 0;
            for (int x = 0; x < map.GetLength(0); x++){
                for (int y = 0; y < map.GetLength(1); y++){
                    if (map[x,y] > 1) amountOfDanger++;
                }
            }
            Console.WriteLine(amountOfDanger);
        }

        class Line {
            public int x1,x2,y1,y2;
            public Line(int _x1, int _y1, int _x2, int _y2){
                x1 = _x1;
                x2 = _x2;
                y1 = _y1;
                y2 = _y2;
            }
        }
    }
}

