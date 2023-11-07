using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
   public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
       public DLList() { head = null;  tail = null; } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void addToTail(DLLNode p)
        {

            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                tail.next = p;
                p.previous = tail;
                tail = p; 
            }
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                head = p;
            }
        } // end of addToHead

        public void removHead()
        {
            if (this.head == null) return;

            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }

            this.head = this.head.next;
            this.head.previous = null;
        } // removeHead

        public void removeTail()
        {
            if (this.tail == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }

            this.tail = this.tail.previous;
            this.tail.next = null;

        } // remove tail

        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/
        public DLLNode search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
                if (p.num == num) break;
                p = p.next;
            }
            return (p);
        } // end of search (return pionter to the node);

        public void removeNode(DLLNode p)
        { // removing the node p.

            DLLNode searchP = this.head;
            while (searchP != null)
            {
                if (searchP == p) break;
                searchP = searchP.next;
            }
            if (searchP == null) return;  // If p is not part of the list, exit the method

            if (p.next == null)
            {
                if (this.tail.previous != null)
                {
                    this.tail = this.tail.previous;
                    this.tail.next = null;
                }
                else
                {
                    // p is the only node in the list
                    this.head = null;
                    this.tail = null;
                }
                return;
            }
            if (p.previous == null)
            {
                this.head = this.head.next;
                this.head.previous = null;
                return;
            }

            p.next.previous = p.previous;
            p.previous.next = p.next;

            p.next = null;
            p.previous = null;

        } // end of remove a node

        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                p = p.next;
            }
            return (tot);
        } // end of total
    } // end of DLList class
}
