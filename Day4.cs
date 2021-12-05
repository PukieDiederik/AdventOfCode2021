namespace AoC{
    class Day4 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day4");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            //parse input...
            //split the first numbers
            string[] splitNum = lines[0].Split(',');
            int[] callingNumbers = new int[splitNum.Length];
            for(int i =0; i < splitNum.Length; i++) callingNumbers[i] = Int32.Parse(splitNum[i]);

            BingoCard[] cards = new BingoCard[(lines.Length -2)/6];
            //parsing the sudokus
            for(int i = 0; i < (lines.Length -2)/6; i++){
                int[,] res = new int[5,5];
                for(int j = 0; j < 5; j++){
                    string[] s = lines[i*6 + j + 2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for(int k = 0; k < 5; k++){
                        res[j,k] = Int32.Parse(s[k]);
                    }
                }
                cards[i] = new BingoCard(res);
            }

            for (int callNum = 0; callNum < callingNumbers.Length; callNum++){
                for (int i = 0; i < cards.Length; i++){
                    int? bingo = cards[i].setNum(callingNumbers[callNum]);
                    if(bingo != null) {
                        Console.WriteLine(i);
                        Console.WriteLine(bingo * callingNumbers[callNum]);
                        return;
                    }
                }    
            }
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day4");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            //parse input...
            //split the first numbers
            string[] splitNum = lines[0].Split(',');
            int[] callingNumbers = new int[splitNum.Length];
            for(int i =0; i < splitNum.Length; i++) callingNumbers[i] = Int32.Parse(splitNum[i]);

            BingoCard[] cards = new BingoCard[(lines.Length -2)/6];
            //parsing the sudokus
            for(int i = 0; i < (lines.Length -2)/6; i++){
                int[,] res = new int[5,5];
                for(int j = 0; j < 5; j++){
                    string[] s = lines[i*6 + j + 2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for(int k = 0; k < 5; k++){
                        res[j,k] = Int32.Parse(s[k]);
                    }
                }
                cards[i] = new BingoCard(res);
            }

            bool[] isCardCompleted= new bool[cards.Length];
            int cardsCompleted = 0;

            for (int callNum = 0; callNum < callingNumbers.Length; callNum++){
                for (int i = 0; i < cards.Length; i++){
                    if(!isCardCompleted[i]){
                        int? bingo = cards[i].setNum(callingNumbers[callNum]);
                        if(bingo != null) {
                            isCardCompleted[i] = true;
                            cardsCompleted++;
                            Console.WriteLine(bingo * callingNumbers[callNum]);
                        }
                    }
                }    
            }
        }

        class BingoCard {
            int[,] numbers;
            bool[,] isChecked;
            public BingoCard(int[,] nums){
                numbers = nums;
                isChecked = new bool[5,5];
            }

            //sets the num and returns true if bingo
            public int? setNum(int num){
                for(int x = 0; x < 5; x++) {
                    for (int y = 0; y < 5; y++){
                        if (numbers[x, y] == num) { 
                            isChecked[x, y] = true;
                            return checkBingo(x,y);
                        }
                    }
                }
                return null;
            }

            int? checkBingo(int _x, int _y){
                int counter = 0;
                for (int x = 0; x < 5; x++){
                    if(isChecked[x,_y]) counter++;
                }
                if(counter == 5){
                    int totalSum = 0;
                    for (int x = 0; x < 5; x++){
                        for (int y = 0; y < 5; y++){
                            if(!isChecked[x,y]) totalSum += numbers[x,y];
                        }
                    }
                    return totalSum;
                }
                counter = 0;
                for (int y = 0; y < 5; y++){
                    if(isChecked[_x, y]) counter++;
                }
                if(counter == 5){
                    int totalSum = 0;
                    for (int x = 0; x < 5; x++){
                        for (int y = 0; y < 5; y++){
                            if(!isChecked[x,y]) totalSum += numbers[x,y];
                        }
                    }
                    return totalSum;
                }
                return null;
            }
        }
    }
}
