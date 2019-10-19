using System;

namespace lab3{
public class Node<T>
{
private Node<T> next;
private T data;

public Node(T val, Node<T> nextNode)
{
  data= val;

  next=nextNode;
}//end Node constructor

}//end class
}
