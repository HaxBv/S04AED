using System;
using UnityEngine;

public class DoubleLinkedList<T> : MonoBehaviour
{

    public Node<T> head = null;
    public Node<T> tail = null;
    public int Count;



    //->0(1)
    public virtual void Add(T value)
    {
        Node<T> newNode = new(value);

        //-> Cuando no hay ningun elemento en la lista
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else if(head != null)
        {
            tail.SetNext(newNode);
            newNode.SetPrev(tail);

            tail= newNode;

        }
        
        Count++;
    }

    //->O(1)
    public void RemoveLast()
    {

        //Node<T> Evaluator = head;

        if (Count == 0)
        {
            Debug.Log("La lista esta vacia");
            return;
        }
        else if (Count == 1)
        {
            head = null;
            Count--;
        }
        else if (Count == 2)
        {
            Node<T> Evaluator = tail.Prev;
            tail.SetNext(null);

            Evaluator.SetNext(null);

            tail = Evaluator;
            Count--;
        }

    }
    //-> O(1)
    public void RemoveFirst()
    {

        if (Count <= 1)
        {
            head = null;
            tail = null;
            Count--;
            return;
        }

        Node<T> Evaluator = head.Next;
        head.SetNext(null);
        head = Evaluator;
        Count--;


    }

    public void TraverseInOrder(Action<Node<T>> action)
    {
        Node<T> Evaluator = head;
        while (Evaluator != null)
        {
            //  Debug.Log(Evaluator.Value);
            action(Evaluator);

            Evaluator = Evaluator.Next;
        }
    }
    public void TraverseInReverse(Action<Node<T>> action)
    {
        Node<T> Evaluator = tail;
        while (Evaluator != null)
        {
            //  Debug.Log(Evaluator.Value);
            action(Evaluator);

            Evaluator = Evaluator.Prev;
        }
    }
}
