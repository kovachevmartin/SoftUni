﻿using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; } 
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public void Insert(T value)
    {
        
    }

    public bool Contains(T value)
    {
        throw new NotImplementedException();
    }

    public void DeleteMin()
    {
        throw new NotImplementedException();
    }

    public BinarySearchTree<T> Search(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        throw new NotImplementedException();
    }

    public void EachInOrder(Action<T> action)
    {
        
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        
    }
}
