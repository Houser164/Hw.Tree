class BinaryTree<T> where T : IComparable<T>
{
    protected TreeNode<T> root = null;
    protected int length = 0;

    public void Add(T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(this.root == null)
        {
            this.root = node;
        }
        else
        {
            Queue<TreeNode<T>> nodeQueue = new Queue<TreeNode<T>>();
            nodeQueue.Push(this.root);

            TreeNode<T> ptr;
            while(nodeQueue.GetLength() > 0)
            {
                ptr = nodeQueue.Pop();
                if(ptr.Child() == null)
                {
                    ptr.SetChild(node);
                    break;
                }
                else if(ptr.Next() == null)
                {
                    ptr.SetNext(node);
                    break;
                }
                else
                {
                    nodeQueue.Push(ptr.Child());
                    nodeQueue.Push(ptr.Next());
                }
            }
        }
        this.length++;
    }

    public void AddLeft(int index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(index == -1)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetChild(ptr.Child());
            ptr.SetChild(node);
        }
        this.length++;
    }

    public void AddRight(int index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(index == -1)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetNext(ptr.Next());
            ptr.SetNext(node);
        }
        this.length++;
    }

    public void Remove(int index)
    {
        if(index == 0)
        {
            TreeNode<T> ptr = this.root;
            this.root = ptr.Child();
            if(this.root.Next() != null)
            {
                this.root.SetChild(this.root.Next());
                this.root.SetNext(null);
            }
        }
        else
        {
            TreeNode<T> previousPtr = this.GetTreeNode(index-1);
            if(previousPtr.Child() != null)
            {
                TreeNode<T> ptr = previousPtr.Child();

                if(ptr.Child() != null)
                {
                    previousPtr.SetChild(ptr.Child());
                    ptr.Next().SetNext(ptr.Next());
                }
                else
                {
                    previousPtr.SetChild(ptr.Next());
                }
            }
            else
            {
                TreeNode<T> ptr = previousPtr.Next();

                if(ptr.Child() != null)
                {
                    previousPtr.SetNext(ptr.Child());
                    ptr.Child().SetNext(ptr.Next());
                }
                else
                {
                    previousPtr.SetNext(ptr.Next());
                }
            }
        }
        this.length--;
    }

    public int GetLength()
    {
        return this.length;
    }

    public T Get(int index)
    {
        TreeNode<T> ptr = this.GetTreeNode(index);
        return ptr.GetValue();
    }

    private TreeNode<T> GetTreeNode(int index)
    {
        int traverseStep = index;
        return this.Traverse(this.root, ref traverseStep);
    }

    private TreeNode<T> Traverse(TreeNode<T> currentTreeNode, ref int traverseStep)
    {
        TreeNode<T> ptr = currentTreeNode;

        if(traverseStep > 0 && currentTreeNode.Child() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Child(), ref traverseStep);
        }

        if(traverseStep > 0 && currentTreeNode.Child() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Child(), ref traverseStep);
        }

        return ptr;
    }

    private TreeNode<T> Search(T value)
    {
        Queue<TreeNode<T>> nodeQueue = new Queue<TreeNode<T>>();
        nodeQueue.Push(this.root);

        TreeNode<T> ptr;
        while(nodeQueue.GetLength() > 0)
        {
            ptr = nodeQueue.Pop();
            if(ptr.GetValue().CompareTo(value) == 0)
            {
                return ptr;
            }
            else
            {
                if(ptr.Child() != null)
                {
                    nodeQueue.Push(ptr.Child());
                }
                if(ptr.Child() != null)
                {
                    nodeQueue.Push(ptr.Next());
                }
            }
        }

        return null;
    }

    public void GetAllOpponents(T value)
    {
        TreeNode<T> ptr = this.Search(value);
        while(ptr != null)
        {
            if(ptr.Child() != null && ptr.Next() != null)
            {
                if(ptr.Child().GetValue().CompareTo(value) == 0)
                {
                    Console.WriteLine(ptr.Next().GetValue());
                    ptr = ptr.Child();
                }
                else
                {
                    Console.WriteLine(ptr.Child().GetValue());
                    ptr = ptr.Next();
                }
            }
            else
            {
                break;
            }
        }
    }
}