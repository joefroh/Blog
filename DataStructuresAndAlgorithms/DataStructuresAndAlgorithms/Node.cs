﻿namespace DataStructuresAndAlgorithms
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public T Data { get; set; }
    }
}