public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        return (numBottles * numExchange - 1)/(numExchange - 1);
    }
}