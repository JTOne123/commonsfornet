﻿// Copyright CommonsForNET. Author: Gujun Yang. email: gujun.yang@gmail.com
// Licensed to the Apache Software Foundation (ASF) under one or more
// contributor license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright ownership.
// The ASF licenses this file to You under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Commons.Collections;

using NUnit;
using NUnit.Framework;

namespace Test.Commons.Collections
{
	[TestFixture]
    public class TestCollection
    {
		[SetUp]
		public void Setup()
        {

        }
		[TearDown]
		public void TearDown()
        {

        }

		[Test]
        public void TestBoundedQueueNoAbsorb()
        {
            BoundedQueue<int> queue = new BoundedQueue<int>(10);
            for (int i = 0; i < 10; i++)
            {
                Assert.IsFalse(queue.IsFull);
                queue.Enqueue(i);
            }
            Assert.AreEqual(queue.Count, 10);
            Assert.That(queue.Contains(5));
            Assert.IsTrue(queue.IsFull);
            Assert.AreEqual(queue.Peek(), 0);
            Assert.AreEqual(queue.Dequeue(), 0);
            Assert.AreEqual(queue.Count, 9);
            Assert.IsFalse(queue.IsFull);
        }

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
        public void TestBoundedQueueNoAbsorbExceedLimit()
        {
            BoundedQueue<int> queue = new BoundedQueue<int>(10);
			for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            queue.Enqueue(11);
        }

		[Test]
		[ExpectedException(typeof(ArgumentException))]
        public void TestBoundedQueueInvalidMaxSize()
        {
            BoundedQueue<int> queue = new BoundedQueue<int>(-10);
        }

		[Test]
		public void TestBoundedQueueConstructedWithEnumrable()
        {
            BoundedQueue<int> queue = new BoundedQueue<int>(Enumerable.Range(0, 10), 5);
            Assert.That(queue.Count == 5);
			int[] array = new int[10];
            queue.CopyTo(array, 1);
            Assert.That(array[0] == 0);
            for (int i = 0; i < 5; i++)
            {
                Assert.That(array[i+1] == i);
            }
        }

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestBoundedQueueCopyToNullArray()
        {
			BoundedQueue<int> queue = new BoundedQueue<int>(Enumerable.Range(0, 10), 5);
            queue.CopyTo(null, 0);
		}
		
		[Test]
		public void TestBoundedQueueAbsorb()
        {
            BoundedQueue<int> queue = new BoundedQueue<int>(Enumerable.Range(0, 10), 6, true);
            Assert.That(queue.Count == 6);
            Assert.That(queue.Peek() == 0);
            queue.Enqueue(7);
            Assert.That(queue.Count == 6);
            Assert.That(queue.Peek() == 1);
        }

		[Test]
        public void TestBoundedQueueAbsorbWithMaxsizeOne()
        {
            BoundedQueue<int> queue = new BoundedQueue<int>(1, true);
            queue.Enqueue(0);
            queue.Enqueue(10);
            Assert.That(queue.Count == 1);
            Assert.That(queue.Dequeue() == 10);
            Assert.That(queue.Count == 0);
        }

        [Test]
        public void TestCompositeCollectionEmptyConstructor()
        {
            CompositeCollection<int> comp = new CompositeCollection<int>();
            comp.Add(1);
            comp.Add(2);
            Assert.AreEqual(comp.Count, 2);
            comp.AddAll(Enumerable.Range(3, 5).ToList());
            Assert.AreEqual(comp.Count, 7);
        }

        [Test]
        public void TestCompositeCollectionMultiparamConstructor()
        {
            List<int> list1 = Enumerable.Range(0, 10).ToList();
            List<int> list2 = Enumerable.Range(8, 10).ToList();

            CompositeCollection<int> comp = new CompositeCollection<int>(list1, list2);
            Assert.AreEqual(comp.Count, 20);
            comp.Add(30);
            Assert.AreEqual(comp.Count, 21);
            Assert.IsTrue(comp.Remove(9));
            Assert.IsFalse(comp.Contains(9));
            Assert.IsTrue(comp.Contains(8));
            comp.Clear();
            Assert.AreEqual(comp.Count, 0);
        }

        [Test]
        public void TestCompositeCollectionUniqueList()
        {
            List<int> list1 = Enumerable.Range(0, 10).ToList();
            List<int> list2 = Enumerable.Range(8, 10).ToList();
            CompositeCollection<int> comp = new CompositeCollection<int>(list1, list2);

            IList<int> result = comp.ToUnique();
            Assert.AreEqual(result.Count, 18);
            for (int i = 0; i < 18; i++)
            {
                Assert.AreEqual(result[i], i);
            }
        }

        [Test]
        public void TestCompositeCollectionEnumrator()
        {
            List<int> list1 = Enumerable.Range(0, 10).ToList();
            List<int> list2 = Enumerable.Range(10, 10).ToList();
            CompositeCollection<int> comp = new CompositeCollection<int>(list1, list2);
            int i = 0;
            foreach (var item in comp)
            {
                Assert.AreEqual(item, i);
                i++;
            }
            Assert.AreEqual(i, 20);
            int[] array = new int[25];
            comp.CopyTo(array, 1);
            Assert.AreEqual(0, array[0]);
            for (int j = 1; j < 21; j++)
            {
                Assert.AreEqual(j - 1, array[j]);
            }
        }
    }
}
