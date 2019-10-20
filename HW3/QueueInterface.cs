using System;
namespace lab3{

interface QueueInterface<T>     //an interface for a queue!
{
        T Push(T element);      //enqueues an element to the end of the queue
        T Pop();                //removes and returns the next item in the queue
        T Peek();               //returns next elements in queue
        Boolean IsEmpty();      //returns true is items are enqueued
}
}