namespace Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
        }

    }
}


















































#region sample
#if false
    class Program
    {
        static void Main(string[] args)
        {
            MyFooAsync().Wait();
            Console.ReadLine();
        }

        public static async Task<int> FooAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            return 42;
        }

        public static Task<int> MyFooAsync()
        {
            var statemachine = new MyFooAsyncStateMachine();
            statemachine.methodBuilder = new AsyncTaskMethodBuilder<int>();
            statemachine.methodBuilder.Start(ref statemachine);
            return statemachine.methodBuilder.Task;
        }
    }

    public struct MyFooAsyncStateMachine : IAsyncStateMachine
    {
        public AsyncTaskMethodBuilder<int> methodBuilder;
        private TaskAwaiter awaiter;
        private int state;

        public void MoveNext()
        {
            if (state == 0)
            {
                awaiter = Task.Delay(TimeSpan.FromSeconds(10)).GetAwaiter();

                if (awaiter.IsCompleted)
                {
                    goto state1;
                }
                else
                {
                    state = 1;
                    methodBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                }

            }

            state1:
            if (state == 1)
            {
                awaiter.GetResult();
                methodBuilder.SetResult(42);
                return;
            }
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            stateMachine.SetStateMachine(this);
        }
    }
#endif
#endregion