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
    }
}