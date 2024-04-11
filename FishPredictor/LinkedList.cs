using System;
using System.Collections;
using System.Collections.Generic;

namespace FishPredictor
{
    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T>? head;
        Node<T>? tail;
        int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail!.Next = node;
            }

            tail = node;

            count++;
        }

        // удаление элемента
        public bool Remove(T data)
        {
            Node<T>? current = head;
            Node<T>? previous = null;

            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head?.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}