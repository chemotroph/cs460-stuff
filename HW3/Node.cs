using System;

namespace lab3{
public class Node<T>
{
public Node<T> Next;
public T Data;

public Node(T val, Node<T> nextNode)
{
  Data= val;

  Next=nextNode;
}//end Node constructor

}//end class
}
