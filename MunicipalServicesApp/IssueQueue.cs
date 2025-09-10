using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    // Node for Linked List
    public class IssueNode
    {
        public Issue Data { get; set; }
        public IssueNode Next { get; set; }

        public IssueNode(Issue data)
        {
            Data = data;
            Next = null;
        }
    }

    // Queue (FIFO) using linked list
    public class IssueQueue
    {
        private IssueNode front;
        private IssueNode rear;
        private int count;

        public IssueQueue()
        {
            front = rear = null;
            count = 0;
        }

        public void Enqueue(Issue issue)
        {
            IssueNode newNode = new IssueNode(issue);
            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
            count++;
        }

        public Issue Dequeue()
        {
            if (front == null) return null;
            Issue temp = front.Data;
            front = front.Next;
            if (front == null) rear = null;
            count--;
            return temp;
        }

        public Issue Peek()
        {
            return front != null ? front.Data : null;
        }

        public int Count()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        // ✅ Added method so ViewIssuesForm can iterate
        public IssueNode PeekNode()
        {
            return front;
        }
    }
}
