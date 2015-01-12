﻿// Copyright CommonsForNET.
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
using System.Collections;
using System.Collections.Generic;
namespace Commons.Collections.Queue
{
    /// <summary>
    /// 
    /// </summary>
    public class MinPriorityQueue<T> : IPriorityQueue<T>, ICollection, IEnumerable<T>, IEnumerable
    {
		private readonly FibonacciHeap<T> heap;
		public MinPriorityQueue(IEnumerable<T> items, Comparison<T> comparer)
		{
			heap = new FibonacciHeap<T>(comparer);
			if (items != null)
			{
				foreach (var item in items)
				{
					Push(item);
				}
			}
		}
		public bool IsEmpty
		{
			get { throw new System.NotImplementedException(); }
		}

		public T Top
		{
			get { throw new System.NotImplementedException(); }
		}

		public void Push(T item)
		{
			throw new System.NotImplementedException();
		}

		public T Pop()
		{
			throw new System.NotImplementedException();
		}

		public void Add(T item)
		{
			throw new System.NotImplementedException();
		}

		public void Clear()
		{
			throw new System.NotImplementedException();
		}

		public bool Contains(T item)
		{
			throw new System.NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new System.NotImplementedException();
		}

		public int Count
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool IsReadOnly
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool Remove(T item)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		public void CopyTo(System.Array array, int index)
		{
			throw new System.NotImplementedException();
		}

		public bool IsSynchronized
		{
			get { throw new System.NotImplementedException(); }
		}

		public object SyncRoot
		{
			get { throw new System.NotImplementedException(); }
		}
	}
}