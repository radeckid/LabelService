namespace LabelServiceTests.Driver
{
    public abstract class DriverTypeRegister<T>
    {
        public T Driver { get; }

        public DriverTypeRegister(T instance)
        {
            Driver = instance;
        }
    }
}
