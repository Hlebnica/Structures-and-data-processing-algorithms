using System;
using System.Collections.Generic;

namespace Binary_Tree
{
    class Program
    { 
        public class BinaryTree<T> where T : IComparable<T> 
        {
            private BinaryTree<T> _parent, _left, _right;
            private T _value;
            private List<T> _listForPrint = new List<T>();
            
            public BinaryTree(T value, BinaryTree<T> parent)
            {
              _value = value;
              _parent = parent;
            }
            
            public void Add(T val) // Добавление
            {
                  if(val.CompareTo(_value) < 0){
                      if(_left==null){
                          _left = new BinaryTree<T>(val, this);
                      }
                      else if(_left != null)
                          _left.Add(val);
                  }
                  else{
                      if(_right==null){
                          _right = new BinaryTree<T>(val, this);
                      }
                      else if(_right != null)
                          _right.Add(val);
                  }
            }

            private static BinaryTree<T> _Search(BinaryTree<T> tree, T val) // Поиск
            {
                while (true)
                {
                    if (tree == null) return null;
                    switch (val.CompareTo(tree._value))
                    {
                        case 1:
                            tree = tree._right;
                            continue;
                        case -1:
                            tree = tree._left;
                            continue;
                        case 0:
                            return tree;
                        default:
                            return null;
                    }
                }
            }

            private BinaryTree<T> Search(T val)
            {
        	        return _Search(this, val);
            }
            
            public void Remove(T val)
            {
                BinaryTree<T> tree = Search(val); //Проверка, существует ли данный узел
                if(tree == null)
                {
                    return;
                }
                BinaryTree<T> curTree;
          
                //Если удаляем корень
                if(tree == this){
                      if(tree._right!=null) {
                          curTree = tree._right;
                      }
                      else curTree = tree._left;
          
                      while (curTree._left != null) {
                          curTree = curTree._left;
                      }
                      T temp = curTree._value;
                      Remove(temp);
                      tree._value = temp;

                      return;
                }
          
                //Удаление листьев
                if(tree._left==null && tree._right==null && tree._parent != null)
                {
                    if(tree == tree._parent._left)
                        tree._parent._left = null;
                    else{
                        tree._parent._right = null;
                    }

                    return;
                }
          
                //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
                if(tree._left != null && tree._right == null){
                    //Меняем родителя
                    tree._left._parent = tree._parent;
                    if(tree == tree._parent?._left){ 
                        tree._parent._left = tree._left;
                    }
                    else if(tree == tree._parent?._right){
                          tree._parent._right = tree._left;
                    }

                    return;
                }
          
                //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
                if(tree._left == null && tree._right != null){
                    //Меняем родителя
                    tree._right._parent = tree._parent;
                    if(tree == tree._parent?._left){
                          tree._parent._left = tree._right;
                    }
                    else if(tree == tree._parent?._right){
                        tree._parent._right = tree._right;
                    }

                    return;
                }
          
                //Удаляем узел, имеющий поддеревья с обеих сторон
                if(tree._right!=null && tree._left!=null) {
                    curTree = tree._right;
          
                    while (curTree._left != null) {
                        curTree = curTree._left;
                    }
          
                    //Если самый левый элемент является первым потомком
                    if(curTree._parent == tree) {
                        curTree._left = tree._left;
                        tree._left._parent = curTree;
                        curTree._parent = tree._parent;
                        if (tree == tree._parent?._left) {
                            tree._parent._left = curTree;
                        } else if (tree == tree._parent?._right) {
                            tree._parent._right = curTree;
                        }

                        return;
                    }
                    
                    //Если самый левый элемент НЕ является первым потомком
                    if (curTree._right != null) {
                        curTree._right._parent = curTree._parent;
                    }
                    curTree._parent._left = curTree._right;
                    curTree._right = tree._right;
                    curTree._left = tree._left;
                    tree._left._parent = curTree;
                    tree._right._parent = curTree;
                    curTree._parent = tree._parent;
                    if (tree == tree._parent?._left) {
                        tree._parent._left = curTree;
                    } else if (tree == tree._parent?._right) {
                        tree._parent._right = curTree;
                    }
                }
            }

            private void _print(BinaryTree<T> node)
            {
                while (true)
                { 
                    if (node == null) return;
                    _print(node._left);
                    _listForPrint.Add(node._value);
                    Console.Write(node + " ");
                    if (node._right != null)
                    {
                        node = node._right;
                        continue;
                    }
                    break;
                }
            }

            public void Print()
            { 
                _listForPrint.Clear();
                _print(this);
                Console.WriteLine();
            }
              
            public override string ToString()
            { 
                return _value.ToString();
            }
        }
        
        public static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>(10, null);
            Console.WriteLine("Обход дерева до удаления ключа");
            
            tree.Add(2);
            tree.Add(3);
            tree.Add(8);
            tree.Add(4);
            tree.Add(6);
            tree.Add(9);
            tree.Print();
            
            Console.WriteLine("Введите ключ для удаления");
            int digitForRemove = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Обход дерева после удаления ключа");
            tree.Remove(digitForRemove);
            tree.Print();
        }
    }
}