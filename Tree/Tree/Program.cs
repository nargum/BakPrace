using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Znak pro epsilon: ε");
            Console.WriteLine("Znak pro empty set: #");
            Console.WriteLine();


            ExpressionValidator v = new ExpressionValidator("a*b+abc**");
            TreeNode<string> root = v.parse();

            try
            {
                Console.WriteLine("Entered expression: " + v.getExpression());
                Console.WriteLine("Short expression: " + root.BuildShortExpression());
                Console.WriteLine("Long expression: " + root.BuildFullExpression());
            }
            catch (NullReferenceException)
            {

            }
            
            
            Console.ReadKey();
 
        }
    }
}
