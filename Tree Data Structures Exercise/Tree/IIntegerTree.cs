using System;
using System.Collections.Generic;

namespace Tree
{
    public interface IIntegerTree: IAbstractTree<int>
    {
        IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum);

        IEnumerable<Tree<int>> SubTreesWithGivenSum(int sum);
    }
}
