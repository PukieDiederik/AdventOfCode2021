namespace AoC {
    class AoCHandler{
        static void Main(string[] args) {
            //check which application to run
            switch(args[0]){
                // Day 1
                case "1-1":
                    Day1.Part1();
                    break;

                default:
                    Console.WriteLine("[ERR] Did not recognize that function");
                    break;
            }
        }
    }
}