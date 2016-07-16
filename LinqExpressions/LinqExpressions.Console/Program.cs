using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqExpressions.Console
{
    using System;

    public struct PointS
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void DoSomething(int z)
        {
            this.X = z;
        }
    }


    class Program
    {

        public static void PlayWithStruct()
        {
            var list = new List<PointS>();

            var point = new PointS();
            PointS point2;

            point.X = 10;

            list.Add(point);

            var x1 = list[0].X;

            list[0].DoSomething(20);
            //list[0].X = 20;

            var x2 = list[0].X;

            point.DoSomething(20);

            var x3 = point.X;

            Console.WriteLine(); 
        }


        public static void PlayWithEnumerables()
        {
            var scores = new List<int> { 1, 2, 5, 7, 3, 9, 3, 4 };


            IEnumerable<int> query =
                from score in scores
                where score < 100
                select score;



            IEnumerator<int> a;
            IEnumerable<int> aa;

            var s = scores.Where(x => x > 12).OrderBy(x => x);
            
            foreach (var i in query)
            {
                Console.Write(i + " ");
            }


            scores.Add(1);
            scores.Add(2);

            Console.WriteLine();
            foreach (var i in query)
            {
                Console.Write(i + " ");
            }

        }

        public static void PlayWithQuerables()
        {
            var scores = new List<int> {1, 2, 5, 7, 3, 9, 3, 4};

            IQueryable<int> a;

            //IQueryable aa = a;

            //IQueryProvider queryProvider;


            //var x = a.Where(y => y > 123);
            
        }


        public static void PlayWithExpressions()
        {

            Expression expression;

            var param1 = Expression.Parameter(typeof (int), "param1");
            var param11 = Expression.Parameter(typeof(int), "param1");
            var param2 = Expression.Parameter(typeof(int), "param2");
            var const1 = Expression.Constant(10);

            var sumExpr = Expression.Add(param1, const1);
            var multiplyExpr = Expression.Multiply(sumExpr, param2);

            Expression<Func<int, int, int>> lambda1 = Expression.Lambda<Func<int, int, int>>(multiplyExpr, param1, param2);

            Expression<Func<int, int, int>> lambda2 = (para1, para2) => +(+((new int[] {1, 2, 3, 4}.Length + 10) * para2));

            Func<int, int, int> lambda22 = (para1, para2) => ((new int[] { 1, 2, 3, 4 }.Length + 10) * para2);

            var compiled = lambda1.Compile();



            var a2 = new List<int> {1, 2, 3, 4, 10, 11, 12};

            var a2Result = from i in a2
                      where i > 10
                      select i;


            IQueryable<int> intt = (a2).AsQueryable();


            var a22esult = from i in intt
                where i > 10
                select i;


            var provider = a22esult.Provider;


            var a = compiled(1, 2);


            if (param1 == param11)
            {
                a = compiled(1, 3);
            }

            //ExpressionType exprType = expression.NodeType;


        }

        static void Main(string[] args)
        {

            //PlayWithStruct();
            //PlayWithEnumerables();
            PlayWithExpressions();

            Console.ReadKey();
        }
    }
}
