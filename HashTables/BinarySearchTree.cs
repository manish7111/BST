using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTables
{
    class BinarySearchTree<T> where T: IComparable<T>
    {
        public T NodeData { get; set; }
        public BinarySearchTree<T> LeftTree { get; set; }
        public BinarySearchTree<T> RightTree { get; set; }
        public BinarySearchTree(T nodeData)
        {
            this.NodeData = nodeData;
            this.LeftTree = null;
            this.RightTree = null;
        }
        int leftCount = 0, rightCount = 0;
        public void Insert(T item)
        {
            T currentNodeValue = this.NodeData;
            if ((currentNodeValue.CompareTo(item)) > 0)
            {
                if (this.LeftTree == null)
                    this.LeftTree = new BinarySearchTree<T>(item);
                else
                    this.LeftTree.Insert(item);
            }
            else
            {
                if (this.RightTree == null)
                    this.RightTree = new BinarySearchTree<T>(item);
                else
                    this.RightTree.Insert(item);
            }
        }
        public void Display()
        {
            
            if (this.LeftTree != null)
            {
                this.leftCount++;
                this.LeftTree.Display();
            }
            Console.WriteLine(this.NodeData.ToString());
            if (this.RightTree != null)
            {
                this.rightCount++;
                this.RightTree.Display();
            }
        }
        public void GetSize()
        {
           Console.WriteLine("Size"+" "+(1 + this.leftCount + this.rightCount));
        }
        public bool IfNodeExists(int key)
        {
            if (this.NodeData.Equals(key))
            {
                return true;
            }
            while (this.LeftTree != null)
            {
                if (this.LeftTree.NodeData.Equals(key))
                {
                    
                    return true;
                }
                this.LeftTree.IfNodeExists(key);
            }
            while (this.RightTree != null)
            {
                if (this.RightTree.NodeData.Equals(key))
                {
                    return true;
                }
                this.RightTree.IfNodeExists(key);
            }
            return false;
        }
    }
}

