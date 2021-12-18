using System.Text;
namespace AoC{
    class Day16 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day16");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            StringBuilder sb = new StringBuilder(lines[0].Length*4);
            for(int i = 0; i < lines[0].Length; i++){
                switch(lines[0][i]){
                    case '0': sb.Append("0000"); break;
                    case '1': sb.Append("0001"); break;
                    case '2': sb.Append("0010"); break;
                    case '3': sb.Append("0011"); break;
                    case '4': sb.Append("0100"); break;
                    case '5': sb.Append("0101"); break;
                    case '6': sb.Append("0110"); break;
                    case '7': sb.Append("0111"); break;
                    case '8': sb.Append("1000"); break;
                    case '9': sb.Append("1001"); break;
                    case 'A': sb.Append("1010"); break;
                    case 'B': sb.Append("1011"); break;
                    case 'C': sb.Append("1100"); break;
                    case 'D': sb.Append("1101"); break;
                    case 'E': sb.Append("1110"); break;
                    case 'F': sb.Append("1111"); break;
                }
            }
            string binString = sb.ToString();
            //process the input
            Console.WriteLine(getVersionNums(binString)[0]);
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day16");
            for(int i = 0; i < lines.Length; i++ ) lines[i] = lines[i].Trim();
            StringBuilder sb = new StringBuilder(lines[0].Length*4);
            for(int i = 0; i < lines[0].Length; i++){
                switch(lines[0][i]){
                    case '0': sb.Append("0000"); break;
                    case '1': sb.Append("0001"); break;
                    case '2': sb.Append("0010"); break;
                    case '3': sb.Append("0011"); break;
                    case '4': sb.Append("0100"); break;
                    case '5': sb.Append("0101"); break;
                    case '6': sb.Append("0110"); break;
                    case '7': sb.Append("0111"); break;
                    case '8': sb.Append("1000"); break;
                    case '9': sb.Append("1001"); break;
                    case 'A': sb.Append("1010"); break;
                    case 'B': sb.Append("1011"); break;
                    case 'C': sb.Append("1100"); break;
                    case 'D': sb.Append("1101"); break;
                    case 'E': sb.Append("1110"); break;
                    case 'F': sb.Append("1111"); break;
                }
            }
            string binString = sb.ToString();
            //process the input
            Console.WriteLine(getSum(binString)[0]);
        }

        //[0] = sum [1] = length
        static ulong[] getSum(string s){
            int id = Convert.ToInt32(s.Substring(3,3), 2);
            if(id == 4){
                StringBuilder sb = new StringBuilder();
                int size = 6;
                int curPos = 0;
                while(s[6 + (curPos * 5)] == '1') {
                    sb.Append(s.Substring(7 + 5 * curPos, 4));
                    size += 5;
                    curPos++;
                }
                sb.Append(s.Substring(7 + 5 * curPos, 4));
                size += 5;
                return new ulong[]{Convert.ToUInt64(sb.ToString(), 2), (ulong)size};
            } else {
                if(s[6] == '0'){
                    ulong total = 0;
                    int startingPos = 22;
                    int length = Convert.ToInt32(s.Substring(7,15),2);
                    bool isFirst = true;
                    while(startingPos - 22 < length){
                        ulong[] j = getSum(s.Substring(startingPos));
                        startingPos += (int)j[1];
                        switch(id){
                            case 0: //add
                                total += j[0];
                                break;
                            case 1: //multiply
                                if(isFirst) total = j[0];
                                else total *= j[0];
                                break;
                            case 2: //min
                                if(isFirst) total = j[0];
                                if(j[0] < total) total = j[0];
                                break;
                            case 3: //max
                                if(j[0] > total) total = j[0];
                                break;
                            case 5:
                                if(isFirst) total = j[0];
                                else total = total > j[0] ? (ulong)1 : (ulong)0;
                                break;
                            case 6:
                                if(isFirst) total = j[0];
                                else total = total < j[0] ? (ulong)1 : (ulong)0;
                                break;
                            case 7:
                                if(isFirst) total = j[0];
                                else total = total == j[0] ? (ulong)1 : (ulong)0;
                                break;
                        }
                        isFirst = false;
                    }
                    return new ulong[] {total, (ulong)length + 22};
                } else {
                    ulong total = 0;
                    int totalLength = 18;
                    int numOfPackets = Convert.ToInt32(s.Substring(7,11),2);
                    bool isFirst = true;
                    for(int i = 0; i < numOfPackets; i++){
                        ulong[] j = getSum(s.Substring(totalLength));
                        switch(id){
                            case 0: //add
                                total += j[0];
                                break;
                            case 1: //multiply
                                if(isFirst) total = j[0];
                                else total *= j[0];
                                break;
                            case 2: //min
                                if(isFirst) total = j[0];
                                if(j[0] < total) total = j[0];
                                break;
                            case 3: //max
                                if(j[0] > total) total = j[0];
                                break;
                            case 5:
                                if(isFirst) total = j[0];
                                else total = total > j[0] ? (ulong)1 : (ulong)0;
                                break;
                            case 6:
                                if(isFirst) total = j[0];
                                else total = total < j[0] ? (ulong)1 : (ulong)0;
                                break;
                            case 7:
                                if(isFirst) total = j[0];
                                else total = total == j[0] ? (ulong)1 : (ulong)0;
                                break;
                        }
                        totalLength += (int)j[1];
                        isFirst = false;
                    }

                    return new ulong[] {total,(ulong)totalLength};
                }
            }
        }
        
        //[0] = version sum [1] = length
        static int[] getVersionNums(string s){
            int version = Convert.ToInt32(s.Substring(0,3),2);
            int id = Convert.ToInt32(s.Substring(3,3), 2);

            if(id == 4){
                int size = 6;
                int curPos = 0;
                while(s[6 + (curPos * 5)] == '1') {
                    size += 5;
                    curPos++;
                }

                size += 5;
                return new int[]{version, size};
            } else {
                if(s[6] == '0'){
                    int total = version;
                    int startingPos = 22;
                    int length = Convert.ToInt32(s.Substring(7,15),2);
                    while(startingPos - 22 < length){
                        int[] j = getVersionNums(s.Substring(startingPos));
                        total += j[0];
                        startingPos += j[1];
                    }
                    return new int[] {total, length + 22};

                } else {
                    int total = version;
                    int totalLength = 18;
                    int numOfPackets = Convert.ToInt32(s.Substring(7,11),2);
                    for(int i = 0; i < numOfPackets; i++){
                        int[] j = getVersionNums(s.Substring(totalLength));
                        total += j[0];
                        totalLength += j[1];
                    }

                    return new int[] {total,totalLength};
                }
            }
        }
    }
}