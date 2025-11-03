public class Solution {
    public int MinCost(string colors, int[] neededTime) {
        var cost = 0;
        
        for(var i = 0; i < colors.Length - 1; i++){
            if(colors[i] == colors[i+1]){
                var timeToRemoveFirst = neededTime[i];
                var timeToRemoveSecond = neededTime[i+1];

                if(timeToRemoveFirst <= timeToRemoveSecond){
                    cost += timeToRemoveFirst;
                    neededTime[i] = timeToRemoveSecond;
                }
                else{
                    cost += timeToRemoveSecond;
                    neededTime[i+1] = timeToRemoveFirst;
                }
            }
        }

        return cost;
    }
}