public class Merge {
    public string MergeAlternately(string word1, string word2) {
        int i1 = 0;
        int i2 = 0;
        string result = "";
        int min_length = Math.Min(word1.Length,word2.Length);
        while(i1 != min_length && i2 != min_length){
            result += word1[i1];
            i1++;
            result += word2[i2];
            i2++;
        }
        while(i1 != word1.Length){
            result += word1[i1];
            i1++;
        }
        while(i2 != word2.Length){
            result += word2[i2];
            i2++;
        }
        return result;
    }
}