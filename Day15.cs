namespace AoC{
    class Day15 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day15");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();

            int[,] map = new int[lines[0].Length,lines.Length];
            for (int y = 0; y < lines.Length; y++){
                for(int x = 0; x < lines[0].Length; x++){
                    map[x,y] = int.Parse(lines[y][x].ToString());
                }
            }
            //process the input
            //x, y
            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            // F, G, H, LAST X, LAST Y
            int[,][] aStarTable = new int[map.GetLength(0),map.GetLength(1)][];
            //populate the table with default values
            for(int x = 0; x < map.GetLength(0); x++){
                for(int y = 0; y < map.GetLength(0); y++){
                    aStarTable[x,y] = new int[] {int.MaxValue, int.MaxValue, x + y, int.MaxValue, int.MaxValue};
                }
            }
            aStarTable[0,0] = new int[] {0, 0, 0, int.MaxValue, int.MaxValue};
            pq.Enqueue(new int[] {0,0}, 0);

            while(pq.Count > 0 && !(pq.Peek()[0] == map.GetLength(0) - 1 && pq.Peek()[1] == map.GetLength(1) - 1)){
                int[] e = pq.Dequeue();
                if(IsInBounds(e[0]+1,e[1], map.GetLength(0), map.GetLength(1))){
                    int h = aStarTable[e[0]+1,e[1]][2];
                    int g = aStarTable[e[0]  ,e[1]][1] + map[e[0]+1,e[1]];
                    int f = h + g;
                    if( aStarTable[e[0]+1,e[1]][1] > g){
                        aStarTable[e[0]+1,e[1]] = new int[] {f, g, h, e[0], e[1]};
                        pq.Enqueue(new int[] {e[0] + 1, e[1]}, f);
                    }
                }
                if(IsInBounds(e[0]-1,e[1], map.GetLength(0), map.GetLength(1))){
                    int h = aStarTable[e[0]-1,e[1]][2];
                    int g = aStarTable[e[0]  ,e[1]][1] + map[e[0]-1,e[1]];
                    int f = h + g;
                    if( aStarTable[e[0]-1,e[1]][1] > g){
                        aStarTable[e[0]-1,e[1]] = new int[] {f, g, h, e[0], e[1]};
                        pq.Enqueue(new int[] {e[0] - 1, e[1]}, f);
                    }
                }
                if(IsInBounds(e[0],e[1]+1, map.GetLength(0), map.GetLength(1))){
                    int h = aStarTable[e[0],e[1]+1][2];
                    int g = aStarTable[e[0],e[1]][1] + map[e[0],e[1]+1];
                    int f = h + g;
                    if( aStarTable[e[0],e[1]+1][1] > g){
                        aStarTable[e[0],e[1]+1] = new int[] {f, g, h, e[0], e[1]};
                        pq.Enqueue(new int[] {e[0], e[1] + 1}, f);
                    }
                }
                if(IsInBounds(e[0],e[1]-1, map.GetLength(0), map.GetLength(1))){
                    int h = aStarTable[e[0],e[1]-1][2];
                    int g = aStarTable[e[0],e[1]][1] + map[e[0],e[1]-1];
                    int f = h + g;
                    if( aStarTable[e[0],e[1]-1][1] > g){
                        aStarTable[e[0],e[1]-1] = new int[] {f, g, h, e[0], e[1]};
                        pq.Enqueue(new int[] {e[0], e[1] - 1}, f);
                    }
                }
            }

            int total = 0;
            int curX = pq.Peek()[0];
            int curY = pq.Peek()[1];
            while(aStarTable[curX, curY][3] != int.MaxValue){
                total += map[curX, curY];
                int tempX = curX;
                curX = aStarTable[tempX, curY][3];
                curY = aStarTable[tempX, curY][4];
            }
            Console.WriteLine(total);
        }

        public static void Part2 () {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day15");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();

            int[,] map = new int[lines[0].Length * 5,lines.Length * 5];
            int wdh = lines[0].Length;
            int hgt = lines.Length;
            for (int y = 0; y < hgt* 5; y++){
                for(int x = 0; x < wdh * 5; x++){
                    int num = int.Parse(lines[y%hgt][x%wdh].ToString());
                    num += (x / wdh) + (y/hgt);
                    if(num > 9) num %= 9;
                    map[x,y] = num;
                }
            }
            //process the input
            //x, y
            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            // F, G, H, LAST X, LAST Y
            int[,][] aStarTable = new int[map.GetLength(0),map.GetLength(1)][];
            //populate the table with default values
            for(int x = 0; x < map.GetLength(0); x++){
                for(int y = 0; y < map.GetLength(0); y++){
                    aStarTable[x,y] = new int[] {int.MaxValue, int.MaxValue, x + y, int.MaxValue, int.MaxValue};
                }
            }
            aStarTable[0,0] = new int[] {0, 0, 0, int.MaxValue, int.MaxValue};
            pq.Enqueue(new int[] {0,0}, 0);

            while(pq.Count > 0 && !(pq.Peek()[0] == map.GetLength(0) - 1 && pq.Peek()[1] == map.GetLength(1) - 1)){
                int[] e = pq.Dequeue();
                if(IsInBounds(e[0]+1,e[1], map.GetLength(0), map.GetLength(1))){
                    int h = aStarTable[e[0]+1,e[1]][2];
                    int g = aStarTable[e[0]  ,e[1]][1] + map[e[0]+1,e[1]];
                    int f = h + g;
                    if( aStarTable[e[0]+1,e[1]][1] > g){
                        aStarTable[e[0]+1,e[1]] = new int[] {f, g, h, e[0], e[1]};
                        pq.Enqueue(new int[] {e[0] + 1, e[1]}, f);
                    }
                }
                if(IsInBounds(e[0]-1,e[1], map.GetLength(0), map.GetLength(1))){
                    int h = aStarTable[e[0]-1,e[1]][2];
                    int g = aStarTable[e[0]  ,e[1]][1] + map[e[0]-1,e[1]];
                    int f = h + g;
                    if( aStarTable[e[0]-1,e[1]][1] > g){
                        aStarTable[e[0]-1,e[1]] = new int[] {f, g, h, e[0], e[1]};
                        pq.Enqueue(new int[] {e[0] - 1, e[1]}, f);
                    }
                }
                if(IsInBounds(e[0],e[1]+1, map.GetLength(0), map.GetLength(1))){
                    int h = aStarTable[e[0],e[1]+1][2];
                    int g = aStarTable[e[0],e[1]][1] + map[e[0],e[1]+1];
                    int f = h + g;
                    if( aStarTable[e[0],e[1]+1][1] > g){
                        aStarTable[e[0],e[1]+1] = new int[] {f, g, h, e[0], e[1]};
                        pq.Enqueue(new int[] {e[0], e[1] + 1}, f);
                    }
                }
                if(IsInBounds(e[0],e[1]-1, map.GetLength(0), map.GetLength(1))){
                    int h = aStarTable[e[0],e[1]-1][2];
                    int g = aStarTable[e[0],e[1]][1] + map[e[0],e[1]-1];
                    int f = h + g;
                    if( aStarTable[e[0],e[1]-1][1] > g){
                        aStarTable[e[0],e[1]-1] = new int[] {f, g, h, e[0], e[1]};
                        pq.Enqueue(new int[] {e[0], e[1] - 1}, f);
                    }
                }
            }

            int total = 0;
            int curX = pq.Peek()[0];
            int curY = pq.Peek()[1];
            while(aStarTable[curX, curY][3] != int.MaxValue){
                total += map[curX, curY];
                int tempX = curX;
                curX = aStarTable[tempX, curY][3];
                curY = aStarTable[tempX, curY][4];
            }
            Console.WriteLine(total);
        }

        static bool IsInBounds(int x, int y, int xbounds, int ybounds){
            if(x >= 0 && x < xbounds
            && y >= 0 && y < ybounds) return true;
            return false;
        }
    }
}