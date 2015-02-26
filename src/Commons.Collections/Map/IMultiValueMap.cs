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

namespace Commons.Collections.Map
{
    [CLSCompliant(true)]
    public interface IMultiValueMap<K, V> : ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable
    {
        void Add(K key, V value);

        void Add(K key, ICollection<V> values);

        bool Remove(K key);

        bool RemoveValue(K key, V value);

        bool ContainsKey(K key);

        bool ContainsValue(K key, V value);

        bool TryGetValue(K key, out List<V> values);

        int CountOf(K key);

        int KeyCount { get; }

        ICollection<V> this[K key] { get; }

        ICollection<K> Keys { get; }

        ICollection<V> Values { get; }
    }
}