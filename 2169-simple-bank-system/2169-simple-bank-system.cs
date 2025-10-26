public class Bank {
    private long[] bal;

    // Constructor
    public Bank(long[] balance) {
        // defensive copy
        bal = new long[balance.Length];
        System.Array.Copy(balance, bal, balance.Length);
    }

    // Helper: check valid account (1-based)
    private bool Valid(int acc) {
        return acc >= 1 && acc <= bal.Length;
    }

    public bool Transfer(int account1, int account2, long money) {
        if (!Valid(account1) || !Valid(account2)) return false;
        if (bal[account1 - 1] < money) return false;
        bal[account1 - 1] -= money;
        bal[account2 - 1] += money;
        return true;
    }

    public bool Deposit(int account, long money) {
        if (!Valid(account)) return false;
        bal[account - 1] += money;
        return true;
    }

    public bool Withdraw(int account, long money) {
        if (!Valid(account)) return false;
        if (bal[account - 1] < money) return false;
        bal[account - 1] -= money;
        return true;
    }
}