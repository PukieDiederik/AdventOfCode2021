namespace AoC{
    class Day9 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day9");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            int[,] heightMap = new int[lines[0].Length + 2, lines.Length + 2];
            for(int y = 0; y < lines.Length; y++){
                for(int x = 0; x < lines[0].Length; x++){
                    heightMap[x + 1, y + 1] = int.Parse(lines[y][x].ToString());
                }
            }
            //padding
            for(int x = 0; x < heightMap.GetLength(0); x++){
                heightMap[x,0] = 9;
                heightMap[x,heightMap.GetLength(1)-1] = 9;
            }
            for(int y = 1; y < heightMap.GetLength(1); y++){
                heightMap[0,y] = 9;
                heightMap[heightMap.GetLength(0)-1,y] = 9;
            }
            //process the input

            int total = 0;
            for(int y = 1; y < heightMap.GetLength(1) -1; y++){
                for(int x = 1; x < heightMap.GetLength(0) -1; x++){
                    if(heightMap[x,y] < heightMap[x-1,y] &&
                       heightMap[x,y] < heightMap[x+1,y] &&
                       heightMap[x,y] < heightMap[x,y-1] &&
                       heightMap[x,y] < heightMap[x,y+1]){
                        total += heightMap[x,y]+1;
                       }
                }
            }
            Console.WriteLine(total);
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day9");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            int[,] heightMap = new int[lines[0].Length + 2, lines.Length + 2];
            for(int y = 0; y < lines.Length; y++){
                for(int x = 0; x < lines[0].Length; x++){
                    heightMap[x + 1, y + 1] = int.Parse(lines[y][x].ToString());
                }
            }
            //padding
            for(int x = 0; x < heightMap.GetLength(0); x++){
                heightMap[x,0] = 9;
                heightMap[x,heightMap.GetLength(1)-1] = 9;
            }
            for(int y = 1; y < heightMap.GetLength(1); y++){
                heightMap[0,y] = 9;
                heightMap[heightMap.GetLength(0)-1,y] = 9;
            }
            //process the input

            //get all the lowest points in the basin
            List<Point> basinPoints = new List<Point>();
            for(int y = 1; y < heightMap.GetLength(1) -1; y++){
                for(int x = 1; x < heightMap.GetLength(0) -1; x++){
                    if(heightMap[x,y] < heightMap[x-1,y] &&
                       heightMap[x,y] < heightMap[x+1,y] &&
                       heightMap[x,y] < heightMap[x,y-1] &&
                       heightMap[x,y] < heightMap[x,y+1]){
                        basinPoints.Add(new Point(x,y));
                    }
                }
            }

            bool[,] mask = new bool[heightMap.GetLength(0),heightMap.GetLength(1)];
            int[] sizes = new int[basinPoints.Count()];
            for(int i = 0; i < basinPoints.Count(); i++){
                sizes[i] = FloodFill(basinPoints[i].x, basinPoints[i].y, mask);
            }
            Array.Sort(sizes, (a,b) => b-a);
            Console.WriteLine(sizes[0] * sizes[1] * sizes[2]);

            int FloodFill(int x, int y, bool[,] mask){
                int totalAmount = 0;
                if(heightMap[x,y] != 9 && !mask[x,y]){
                    totalAmount++;
                    mask[x,y] = true;
                    totalAmount += FloodFill(x+1,y, mask);
                    totalAmount += FloodFill(x-1,y, mask);
                    totalAmount += FloodFill(x,y+1, mask);
                    totalAmount += FloodFill(x,y-1, mask);
                }
                return totalAmount;
            }
        }

        class Point{
            public int x,y;
            public Point(int _x, int _y){
                x=_x;
                y=_y;
            }
        }
    }
}