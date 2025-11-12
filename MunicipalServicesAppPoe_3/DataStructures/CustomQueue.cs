using System.Collections.Generic;

namespace MunicipalServicesAppPoe3.DataStructures
{
    public class CustomQueue<T>
    {
        private readonly Queue<T> queue = new Queue<T>();

        public void Enqueue(T item) => queue.Enqueue(item);
        public T Dequeue() => queue.Dequeue();
        public int Count => queue.Count;
        public IEnumerable<T> GetAll() => queue;
    }
}
