class TreeNode<T>
{
    private T value;
    private TreeNode<T> next = null;
    private TreeNode<T> child = null;
    private TreeNode<T> ancestor = null;

    public TreeNode(T value)
    {
        this.SetValue(value);
    }

    public void SetNext(TreeNode<T> next)
    {
        this.next = next;
    }

    public void SetChild(TreeNode<T> child)
    {
        this.child = child;
    }

    public void Setancestor(TreeNode<T> ancestor)
    {
        this.ancestor = ancestor;
    }

    public TreeNode<T> Next()
    {
        return this.next;
    }

    public TreeNode<T> Child()
    {
        return this.child;
    }

    public TreeNode<T> Ancestor()
    {
        return this.ancestor;
    }

    public T GetValue()
    {
        return this.value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }
}