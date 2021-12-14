namespace AoC{
    class Day12 {
        public static void Part1() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day12");
            string[][] input = new string[lines.Length][];
            for(int i = 0; i < lines.Length; i++) input[i] = lines[i].Trim().Split('-');

            Dictionary<string, Node> nodes = new Dictionary<string, Node>();
            for(int i = 0; i < lines.Length; i++){
                Node? result;
                if(nodes.TryGetValue(input[i][0], out result)){
                    result.connections.Add(input[i][1]);
                } else {
                    nodes.Add(input[i][0],new Node(input[i][1], input[i][0]));
                }

                if(nodes.TryGetValue(input[i][1], out result)){
                    result.connections.Add(input[i][0]);
                } else {
                    nodes.Add(input[i][1],new Node(input[i][0], input[i][1]));
                }
            }

            //process the input
            Console.WriteLine(findPaths(new List<string>(), nodes["start"], nodes, true));
        }

        static int findPaths(List<string> _visited, Node n, Dictionary<string, Node> d, bool hasVisitedTwice){
            int total = 0;
            List<string> visited = new List<string>(_visited);
            if(n.name[0] >= 'a') visited.Add(n.name);
            if(n.name == "end") return 1;
            else {
                for(int i = 0; i < n.connections.Count(); i++){
                    if(!hasVisitedTwice && n.connections[i] != "start"){
                        if(visited.Contains(n.connections[i])){
                            total += findPaths(visited, d[n.connections[i]], d, true);
                        } else total += findPaths(visited, d[n.connections[i]], d, false);
                    } else if (!visited.Contains(n.connections[i])){
                        total += findPaths(visited, d[n.connections[i]], d, hasVisitedTwice);
                    }
                }
            }
            return total;
        }

        public static void Part2() {
            //read the file
            string[] lines = System.IO.File.ReadAllLines("./input/day12");
            string[][] input = new string[lines.Length][];
            for(int i = 0; i < lines.Length; i++) input[i] = lines[i].Trim().Split('-');

            Dictionary<string, Node> nodes = new Dictionary<string, Node>();
            for(int i = 0; i < lines.Length; i++){
                Node? result;
                if(nodes.TryGetValue(input[i][0], out result)){
                    result.connections.Add(input[i][1]);
                } else {
                    nodes.Add(input[i][0],new Node(input[i][1], input[i][0]));
                }

                if(nodes.TryGetValue(input[i][1], out result)){
                    result.connections.Add(input[i][0]);
                } else {
                    nodes.Add(input[i][1],new Node(input[i][0], input[i][1]));
                }
            }

            //process the input
            Console.WriteLine(findPaths(new List<string>(), nodes["start"], nodes, false));
        }

        class Node {
            public string name;
            public List<string> connections;

            public Node (string connection, string _name){
                name = _name;
                connections = new List<string>();
                connections.Add(connection);
            }

            bool isLarge() { return (int)name[0] < 'a'; }
        }
    }
}