public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        int[] result = new int[spells.Length];
        Array.Sort(potions);
        for(int i=0;i<spells.Length;i++)
        {
            var idx = GetIndex(potions,success,spells[i]) ;
            result[i] = idx != -1 ? potions.Length - idx : 0;
        }
        return result;
    }
    public int GetIndex(int[] potions, long success,int spell)
    {
        int l=0;int r= potions.Length-1; int result = -1;
        while(l<=r)
        {
            int mid= l+(r-l)/2;
            if((long)potions[mid] * (long)spell >= success)
            {
                result = mid;
                r = mid-1;
                
            }
            else
            {
                l = mid+1;
            }
        }
        return result;
    }
}