using System;
using lab3;
namespace lab3{

interface QueueInterface<T>     //an interface for a queue!
{
        T push(T element);      //enqueues an element to the end of the queue
        T pop();                //removes and returns the next item in the queue
        T peek();               //returns next elements in queue
        Boolean isEmpty();      //returns true is items are enqueued
}
}