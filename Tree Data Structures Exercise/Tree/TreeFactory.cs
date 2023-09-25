namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public TreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (string pair in input)
            {
                int[] pairTokens = pair.Split(' ').Select((x) => int.Parse(x)).ToArray();

                int parentNode = pairTokens[0];
                int childNode = pairTokens[1];

                this.AddEdge(parentNode, childNode);
            }
            return this.GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!this.nodesByKey.ContainsKey(key))
            {
                this.nodesByKey[key] = new IntegerTree(key);
            }
            return this.nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            IntegerTree parentTree = CreateNodeByKey(parent);
            IntegerTree childTree = CreateNodeByKey(child);
            parentTree.AddChild(childTree);
            childTree.AddParent(parentTree);
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in this.nodesByKey)
            {
                if (kvp.Value.Parent == null)
                {
                    //Get root element
                    return kvp.Value;
                }
            }
            return null;
        }
    }
}
