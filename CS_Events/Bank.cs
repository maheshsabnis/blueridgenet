using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Events
{
    // 1. Declare a delegate, since this is used for defining events it MUST be void
    public delegate void TransactionHandler(decimal amt);

    public class Bank
    {

        // 2. Declare events
        public event TransactionHandler OverBalance;
        public event TransactionHandler UnderBalance;

        decimal OpeningBalance = 0;
        public Bank( decimal openingBalance)
        {
            OpeningBalance = openingBalance;
        }

        public void Deposit(decimal amount)
        {
            OpeningBalance += amount;
            if (OpeningBalance > 100000)
            {
                // 3. Raise Event
                OverBalance(OpeningBalance);
            }
        }

        public void Withdrawal(decimal amt)
        {
            OpeningBalance -= amt;
            if (OpeningBalance < 5000) 
            { 
               // 3. Raise Event
               UnderBalance(OpeningBalance);
            }
        }

        public decimal GetNetBalance()
        {
            return OpeningBalance;
        }
    }

    /// <summary>
    /// 4. The Listener class that will listen to the event and will read data for the event
    /// </summary>
    public class EventListener
    {
        Bank bank;
        /// <summary>
        /// Let the EVentListener know from whome the event data is to be received
        /// Here in this case its a bank object
        /// </summary>
        /// <param name="b"></param>
        public EventListener(Bank b)
        {
            bank = b;
            // 5. Subscribe to event, this will execute a method
            // using he delegate and generate notification 
            bank.OverBalance += new TransactionHandler(Notifify_OverBalance);
            bank.UnderBalance += Bank_UnderBalance;
        }

        private void Bank_UnderBalance(decimal amt)
        {
            Console.WriteLine($"Your Netc balance is Rs. {amt}/- whih is less than Rs 5000/- please maintain mim balance");
        }

        public void Notifify_OverBalance(decimal amt)
        {
            decimal taxableAmount = amt - 100000;
            decimal tax = taxableAmount * Convert.ToDecimal(0.1);
            Console.WriteLine($"Dear Accoutn Holder, you net balance is Rs {amt}/- whih is Rs. {taxableAmount}/- more tha Rs.100000/-, please pay tax od Rs.{tax}/- immediately otherwise Mr. Modi will catch you.");
        }
    }
}
