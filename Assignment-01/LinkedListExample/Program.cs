using System;

namespace LinkedListExample
{
    class Program
    {
        static Node Dummy = new Node();

        static void Main(string[] args)
        {
            InsertAtTail(1);
            InsertAtHead(2);
            InsertAtTail(100);
            DeleteAtHead();
            DeleteAtTail();
            InsertAtAny(0, 65);
            InsertAtAny(0, 144);
            InsertAtAny(1, -87);
            InsertAtTail(15);
            PrintLinkedList();

            Console.WriteLine($"[3: {GetElementAt(3)}]\n[4: {GetElementAt(4)}]");
        } 

        static void InsertAtTail(int value)
        {
            var CurrentNode = Dummy;

            while(CurrentNode.Next != null) CurrentNode = CurrentNode.Next;

            CurrentNode.Next = new Node(value);
        }

        static void InsertAtHead(int value)
        {
            var NextNode = Dummy.Next;
            Dummy.Next = new Node(value, NextNode);
        }

        static void InsertAtAny(int index, int value)
        {
            var CurrentNode = Dummy;

            for (int i = 0; i < index; i++)
            {
                CurrentNode = CurrentNode.Next;
            }

            var NextNode = CurrentNode.Next;
            CurrentNode.Next = new Node(value, NextNode);
        }

        static void DeleteAtTail()
        {
            var CurrentNode = Dummy.Next;

            int step = 0;

            while (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
                step++;
            }

            DeleteAtAny(step);
        }

        static void DeleteAtHead()
        {
            var CurrentNode = Dummy;

            CurrentNode.Next = CurrentNode.Next.Next;
        }

        static void DeleteAtAny(int index)
        {
            var CurrentNode = Dummy;

            for (int i = 0; i < index; i++)
            {
                CurrentNode = CurrentNode.Next;
            }

            CurrentNode.Next = CurrentNode.Next.Next;
        }

        static int GetElementAt(int index)
        {
            var CurrentNode = Dummy.Next;

            for (int i = 0; i < index; i++)
            {
                CurrentNode = CurrentNode.Next;
            }

            return CurrentNode.Value;
        }

        static void PrintLinkedList()
        {
            var CurrentNode = Dummy.Next;

            while(CurrentNode != null)
            {
                Console.Write($"[{CurrentNode.Value}] ");
                CurrentNode = CurrentNode.Next;
            }

            Console.WriteLine();
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node()
        {
            Value = 0;
            Next = null;
        }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public Node(int value, Node node)
        {
            Value = value;
            Next = node;
        }
    }
}