namespace Kenouz.Models.Repositories
{
    public class Test:ITest
    {
        static Guid test;
        public Test()
        {
            test = Guid.NewGuid();
        }
    }
}
