using System;
using System.Collections.Generic;

namespace MunicipalServicesAppPoe3.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data;
            public Node Left;
            public Node Right;
            public Node(T data) => Data = data;
        }

        private Node root;

        public void Insert(T data)
        {
            root = InsertRec(root, data);
        }

        private Node InsertRec(Node node, T data)
        {
            if (node == null) return new Node(data);

            if (data.CompareTo(node.Data) < 0)
                node.Left = InsertRec(node.Left, data);
            else
                node.Right = InsertRec(node.Right, data);

            return node;
        }

        public List<T> InOrderTraversal()
        {
            var result = new List<T>();
            Traverse(root, result);
            return result;
        }

        private void Traverse(Node node, List<T> list)
        {
            if (node == null) return;
            Traverse(node.Left, list);
            list.Add(node.Data);
            Traverse(node.Right, list);
        }
    }
}
