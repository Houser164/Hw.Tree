class Program
{
    public static Tree<string> headache = new Tree<string>();
    public static Stack<string> so_much = new Stack<string>();



    public static void GetPeople(string previous_person){
        int people = int.Parse(Console.ReadLine());
        if(people != 0){

            string Please = Console.ReadLine();
            headache.AddChild(previous_person , Please);
            GetPeople(Please);
            so_much.Push(Please);

            if(people >= 1){
                for(int i = 1 ; i < people ; i++){
                    string Sleep = Console.ReadLine();
                    headache.AddSibling(so_much.Pop() , Sleep);
                    GetPeople(Sleep);
                    so_much.Push(Sleep);
                }
            }
        }
    }
    static void Main(string[] args){
        string manager = Console.ReadLine();
        headache.AddChild(null , manager);
        GetPeople(manager);
        Queue<string> HW = headache.Showancestor(Console.ReadLine());
        for (int i = 0; i <= HW.GetLength(); i++ ){
            Console.WriteLine(HW.Pop());
        }
    }
}