using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace CS_Delegate
{
    // 1. Declare delegate
    public delegate int OperationHandler(int a,int b); 
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Demo Delegate");
            // 1. Direct call of method
            int r1 = Add(10, 20);
            Console.WriteLine($"Direct call {r1}");
            Console.WriteLine();
            // 2. Using Delegate
            // 2.a. Define delegate type instnace and pass method address (reference) to it
            OperationHandler handler1 = new OperationHandler(Add);
            // 2.b. Pass parameters to delegate type instnae
            // this will internally invoke the method
            int r2 = handler1(40, 50);
            Console.WriteLine($"Using Delegate call {r2}");
            Console.WriteLine();
            // 3. THe delegate can directly be passed with implementation
            // ANonymous Method
            OperationHandler hander2 = delegate (int x, int y) { return x + y; };
            
            Console.WriteLine($"With An Anonymous Method C# 2.0 {hander2(300,400)}");
            Console.WriteLine(  );
            // 4. Call the Bridge() method and pass an implementation to it
            double result1 = Bridge(delegate (int x,int y) {  return x * y; });
            Console.WriteLine($"Implementation to Bridge {result1}");
            // 5. C# 3.0 USe Lambda Expression instead of using the direct delegate implementation
            double result2 = Bridge((int a, int b) => { return a + b * a + 100 * b; });
            Console.WriteLine($"Using Lambda Expression {result2}");
            // 6. With an implicit Implementation
            // x and y as implemently declared variable
            // type of x and y will be set (inferred) to the signeture of delegate
            OperationHandler handler3 = (x, y) => x + y;
            Console.WriteLine($"Using IMplicit delcration {Bridge(handler3)}");
            Console.ReadLine();
        }


        static int Add(int x, int y)
        {
          return x + y;
        }
        /// <summary>
        ///  A Method having an input parameter as Delegate
        /// </summary>
        /// <param name="handler"></param>
        static double Bridge(OperationHandler handler)
        {
            double result = handler(100, 200);
            return result;
        }

    }
   
}