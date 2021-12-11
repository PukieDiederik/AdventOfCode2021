namespace AoC{
    class Day11 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day11");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            int[,] squidMap = new int[lines[0].Length,lines.Length];
            for (int y = 0; y < lines.Length; y++){
                for (int x = 0; x < lines[0].Length; x++){
                    squidMap[x,y] = int.Parse(lines[y][x].ToString());
                }
            }
            //process the input
            int squidExplosionAmount = 0;
            for(int i = 0; i < 100; i++){
                Stack<int[]> posToUpdate = new Stack<int[]>();
                
                for (int x = 0; x < squidMap.GetLength(0); x++) {
                    for (int y = 0; y < squidMap.GetLength(0); y++) {
                        squidMap[x,y]++;
                        if(squidMap[x,y] > 9) { 
                            posToUpdate.Push(new int[] {x,y});
                            squidMap[x,y] = 0;
                        }
                    }
                }

                while(posToUpdate.Count() > 0){
                    int[] pos = posToUpdate.Pop();
                    squidExplosionAmount++;
                    squidMap[pos[0],pos[1]] = 0;
                        
                    //trigger each direction
                    UpdatePos(pos[0]+1,pos[1], squidMap, posToUpdate);
                    UpdatePos(pos[0]-1,pos[1], squidMap, posToUpdate);
                    UpdatePos(pos[0],pos[1]+1, squidMap, posToUpdate);
                    UpdatePos(pos[0],pos[1]-1, squidMap, posToUpdate);
                    UpdatePos(pos[0]+1,pos[1]+1, squidMap, posToUpdate);
                    UpdatePos(pos[0]+1,pos[1]-1, squidMap, posToUpdate);
                    UpdatePos(pos[0]-1,pos[1]+1, squidMap, posToUpdate);
                    UpdatePos(pos[0]-1,pos[1]-1, squidMap, posToUpdate);
                }
            }

            Console.WriteLine(squidExplosionAmount);
        }
        static bool IsInBounds(int x, int y, int xbounds, int ybounds){
            if(x >= 0 && x < xbounds
            && y >= 0 && y < ybounds) return true;
            return false;
        }

        static void UpdatePos(int x, int y, int[,] map, Stack<int[]> updateStack){
            if(IsInBounds(x, y, map.GetLength(0), map.GetLength(1))
            && map[x,y] > 0) {
                map[x,y]++;
                if(map[x,y] > 9) {
                    updateStack.Push(new int[] {x,y});
                    map[x,y]=0;
                }
            }
        }
    }
}