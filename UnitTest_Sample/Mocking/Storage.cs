namespace UnitTest_Sample.Mocking
{
    public interface IStorage
    {
        int Store(object obj);
    }
    public class Storage : IStorage
    {
        public int Store(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
