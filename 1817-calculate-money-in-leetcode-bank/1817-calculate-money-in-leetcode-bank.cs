public class Solution {
    public int TotalMoney(int n) {
        int week = n/7;
        int rem = (n%7);
        int sum = 0;
        int j = 28;
        for(int i=0; i<week; i++){
            sum+= j;
            j+=7;
        }
        sum += Convert.ToInt32((double)(rem)/2 * (2*(week+1)+(rem-1))); //apSeriesSum
        return sum;
    }
}