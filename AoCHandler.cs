namespace AoC {
    class AoCHandler{
        static void Main(string[] args) {
            //check which application to run
            switch(args[0]){
                // Day 1
                case "1-1":
                    Day1.Part1();
                    break;
                case "1-2":
                    Day1.Part2();
                    break;
                case "2-1":
                    Day2.Part1();
                    break;
                case "2-2":
                    Day2.Part2();
                    break;
                case "3-1":
                    Day3.Part1();
                    break;
                case "3-2":
                    Day3.Part2();
                    break;
                case "4-1":
                    Day4.Part1();
                    break;
                case "4-2":
                    Day4.Part2();
                    break;
                case "5-1":
                    Day5.Part1();
                    break;
                // case "5-2":
                //     Day5.Part2();
                //     break;

                default:
                    Console.WriteLine("[ERR] Did not recognize that function");
                    break;
            }
        }
    }
}