using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    public class Node
    {
        public IssueReport Report { get; set; }
        public Node Next { get; set; }

        public Node(IssueReport report)
        {
            Report = report;
            Next = null;
        }
    }

    public class ReportQueue
    {
        private Node head;
        private Node tail;
        private int counter = 1;

        public void Enqueue(IssueReport report)
        {
            report.ReferenceNumber = "REF-" + counter++;
            Node newNode = new Node(report);

            if (tail != null) tail.Next = newNode;
            tail = newNode;
            if (head == null) head = newNode;
        }

        public IssueReport Dequeue()
        {
            if (head == null) return null;

            IssueReport report = head.Report;
            head = head.Next;
            if (head == null) tail = null;

            return report;
        }

        public bool IsEmpty() => head == null;
    }
}
