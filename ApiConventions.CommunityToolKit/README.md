# ApiConventions.CommunityToolKit�������߰�
ApiConventions.CommunityToolKit API�������߰� 
1. �������淶��дAPI;
2. ��API��������������

## ���а汾˵��

|�汾|����|
|--|--|
|1.0.0|����Node��|

## Definition
Namespace:  ApiConventions.CommunityToolKit
Assembly:  ApiConventions.CommunityToolKit.dll

## Examples

- ����

```
using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.CommunityToolKit.Models;;

namespace LeetCode
{
    /// <summary>
    /// 897. ����˳��������
    /// https://leetcode.cn/problems/increasing-order-search-tree/
    /// </summary>
    public class Solution897
    {

        List<int> list = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        public TreeNode IncreasingBST(TreeNode root)
        {
            DFS(root);
            Array.ForEach(list.ToArray(), (x) =>
            {
                if (stack.Count > 0)
                {
                    var node = stack.Peek();
                    var right = new TreeNode(x);
                    node.right = right;
                    stack.Push(right);
                }
                else
                {
                    stack.Push(new TreeNode(x));
                }
            });
            var r = stack.Last();
            return r;
        }

        public void DFS(TreeNode root)
        {
            if (root == null)
                return;

            if (root.left != null)
                DFS(root.left);
            list.Add(root.val);
            if (root.right != null)
                DFS(root.right);
        }
    }
}


```
- ��Ԫ����

``` 
    [TestMethod()]
    [DataRow(new object?[] { 5, 3, 6, 2, 4, null, 8, 1, null, null, null, 7, 9 },"", new object?[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6, null, 7, null, 8, null, 9 })]
    public void IncreasingBSTTest(object?[] array,string empty, object?[] exp)
    {
        //emptyռλ������������޷�ƥ��
        var expected = exp.CreateTree();
        var node = array.CreateTree();
        //Act
        var actual = new Solution897().IncreasingBST(node);
        //���������������չ����
        var a = actual.InorderTraversal();
        //Assert ��д������.Equals����
        Assert.IsTrue(expected.Equals(actual), "You are wrong!!!");

    }
```
## Remarks
LeetCode C#ˢ�㷨����ٹ��߰�
- �������ڱ�д�㷨�ǲ����Լ�����TreeNode�ࣻ
- ���ٵ�Ԫ���� ���ٽ�object?[]��ʼ��TreeNode����,��LeetCode�޷�Խӣ�
- ���ٵ�Ԫ���� ��д��Equals�����ж������Ƿ���ȣ�

## Constructors

```
public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
```

## Properties
```
public int val { get;  }
public TreeNode left { get; set; }
public TreeNode right { get; set; }
```
## Methods

 1. ǰ���������ת������
```
 public static TreeNode CreateTree(this object[] arr)
```

 2. ���ض�����ǰ�����

```
public IList<int> PreorderTraversal(TreeNode root)

```

 3. ���ض������������

 ```
 public IList<int> InorderTraversal(TreeNode root)
 ```
 4. ���ض������������
 ```
 public IList<int> PostorderTraversal(TreeNode root)
 ```

 5. �������Ƿ����
 ```
 public override bool Equals(object? obj)
 ```

 6. �ж����б��Ƿ����

 ```
public static void SequenceEqual(this Assert assert, IList<object> list1, IList<object> list2, string msg)
public static void SequenceEqual2(this Assert assert, IList<IList<int>> list1, IList<IList<int>> list2, string msg)

 ```

 - Examples

LeetCode103
 ```
 namespace LeetCode
{
    public  class Solution103 
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;
            bool isToRight = true;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                var level = new int[count];
                while (count > 0)
                {
                    var node = queue.Dequeue();
                    level[isToRight ? (level.Length - count) : (count - 1)] = node.val;
                    count--;
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                res.Add(level.ToList());
                isToRight = !isToRight;
            }
            return res;
        }
    }
}

 ```


  ��Ԫ����
  
 ```
using LeetCode.CommunityToolKit.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tests
{
    [TestClass()]
    public class Solution103Tests
    {
        [TestMethod()]
        [DataRow(new object[]{ 3, 9, 20, null, null, 15, 7 } )]
        public void ZigzagLevelOrderTest(object[] array)
        {
            //Arrange 
            var expected =
                new List<IList<int>> {new List<int>() {3}, new List<int>() {20, 9}, new List<int>() {15, 7}};
            //Act
            var actual = new Solution103().ZigzagLevelOrder(array.CreateTree());

            //Assert
           
            //����1����չ�������Ժ������ؽ����ݵ�Ԫ����
            Assert.That.SequenceEqual2(expected, actual, "You are wrong!!!");
            //����2�������жϷǳ����Ӷ��Ҳ�׼ȷ
             for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(expected[i].SequenceEqual(actual[i]));
            }
            Assert.AreEqual(expected.Count, expected.Count, "You are wrong!!!");
            var typ = expected.GetType();
            Assert.IsInstanceOfType(actual, typ);

        }
    }
}
 ```