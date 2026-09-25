public class MemoryTest
{
    public void Test()
    {
        Console.WriteLine($"Before: {GC.GetTotalMemory(false)}");

        for (int i = 0; i < 100000; i++)
        {
            OrderItem item = new OrderItem();
        }

        Console.WriteLine($"After objects: {GC.GetTotalMemory(false)}");

        GC.Collect();

        Console.WriteLine($"After GC: {GC.GetTotalMemory(true)}");

        Console.WriteLine($"Allocated bytes: {GC.GetAllocatedBytesForCurrentThread()}");
    }
}