using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Four_8_Test
    {
        [TestMethod]
        public void TestMethod1() {
            var tree = new Tree<float>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(6);
            tree.Add(1);
            tree.Add(3);
            tree.Add(5);
            tree.Add(7);
            tree.Add(2.5f);
            tree.Add(3.5f);
            tree.Add(4.5f);
            tree.Add(5.5f);

            var subTree1 = new Tree<float>();
            subTree1.Add(3); 
            subTree1.Add(2.5f); 
            subTree1.Add(3.5f);
            
            Assert.IsTrue(tree.IsSubtree(subTree1));

            var subTree2 = new Tree<float>();            
            subTree2.Add(3.5f);
            subTree2.Add(3);
            subTree2.Add(2.5f);
            Assert.IsFalse(tree.IsSubtree(subTree2));
        }
    }
}
