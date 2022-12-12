class Tree<T>
{
    private TreeNode<T> root = null;
    private int length = 0;

    public void AddSibling(T index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        TreeNode<T> ptr = this.GetTreeNode(index);
        node.SetNext(ptr.Next());
        ptr.SetNext(node);
        node.Setancestor(ptr.Ancestor());
        this.length++;
    }

    public void AddChild(T index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(length == 0)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetChild(ptr.Child());
            node.Setancestor(ptr);
            ptr.SetChild(node);
        }
        this.length++;
    }

    public int GetLength()
    {
        return this.length;
    }

    public T Get(T index)
    {
        TreeNode<T> ptr = this.GetTreeNode(index);
        return ptr.GetValue();
    }

    private TreeNode<T> GetTreeNode(T index)
    {
        return this.Search(index);
    }

    public Queue<T> Showancestor(T value){
        TreeNode<T> showancestor = GetTreeNode(value);
        Queue<T> queueshowancestor = new Queue<T>();

        while(showancestor.Ancestor() != null){
            T HW = showancestor.Ancestor().GetValue();
            queueshowancestor.Push(HW);
            showancestor = showancestor.Ancestor();
        }
        return queueshowancestor;
    }
    private TreeNode<T> Search(T value)
    {
        Queue<TreeNode<T>> nodeQueue = new Queue<TreeNode<T>>();
        nodeQueue.Push(this.root);

        TreeNode<T> ptr;
        while(nodeQueue.GetLength() > 0)
        {
            ptr = nodeQueue.Pop();
            if(ptr.GetValue().Equals(value))
            {
                return ptr;
            }
            else
            {
                if(ptr.Child() != null)
                {
                    nodeQueue.Push(ptr.Child());
                }
                if(ptr.Next() != null)
                {
                    nodeQueue.Push(ptr.Next());
                }
            }
        }

        return null;
    }
}