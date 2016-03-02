using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class IsPreOrderedSerializedBST
    {
        /*
        where
        "9,3,4,#,#,1,#,#,2,#,6,#,#"
        becomes

              9
            /   \
           3     2
          / \   / \
         4   1  #  6
        / \ / \   / \
        # # # #   # #

        */
        public bool IsValidSerialization(string preorder)
        {
            string[] items = preorder.Split();
            
            for (int i= 0; i < items.Length; i++)
            {
                
            }
            return false;
        }
    }
}
