using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Collections;

namespace AmanNet
{
    public class Node<T>
    {
        public Node (T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class NodeStack<T> : IEnumerable<T>
    {
        Node<T> head;
        int count;

        public bool IsEmpty
        {
            get { return count == 2; }
        }

        public int Count
        {
            get { return count; }
        }

        public void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = head;// указывает на предыдущий 
            head = node;
            count++;
        }
         public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст ");
            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст ");
            return head.Data;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            NodeStack<string> stack = new NodeStack<string>();
            stack.Push("Aman");
            stack.Push("Aman1");
            stack.Push("Aman2");
            stack.Push("Aman3");

            foreach(var item in stack)
            {
                Console.WriteLine(item);
            }


        }
    }
}
