public class Potions {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions);
        int[] res = new int[spells.Length];
        for(int i = 0;i<spells.Length;i++){
            int left=0;
            int right = potions.Length-1;
            int tem = -1;
            while(left<=right){
                int mid = left + (right-left)/2;
                if((long)potions[mid]*spells[i] >= success){
                    right = mid-1;
                    tem = mid;
                }
                else{
                    left = mid+1;
                }
            }
            if(tem != -1){
               res[i] = potions.Length - tem; 
            }else{res[i] = 0;}
            
        }
        return res;
    }

    public static void Main(string[] args)
    {
        // Example 1
        int[] spells1 = { 5, 1, 3 };
        int[] potions1 = { 1, 2, 3, 4, 5 };
        long success1 = 7;
        Potions potionsClass1 = new Potions();
        int[] result1 = potionsClass1.SuccessfulPairs(spells1, potions1, success1);
        Console.WriteLine("Example 1 - Successful Pairs: [" + string.Join(", ", result1) + "]");

        // Example 2
        int[] spells2 = { 3, 1, 2 };
        int[] potions2 = { 8, 5, 8 };
        long success2 = 16;
        Potions potionsClass2 = new Potions();
        int[] result2 = potionsClass2.SuccessfulPairs(spells2, potions2, success2);
        Console.WriteLine("Example 2 - Successful Pairs: [" + string.Join(", ", result2) + "]");
    }
    
}