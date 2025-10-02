public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int total = numBottles;
        while (numBottles - numExchange >= 0){
            numBottles -= numExchange -1;
            numExchange++;
            total++;
        }
        return total;
    }
}