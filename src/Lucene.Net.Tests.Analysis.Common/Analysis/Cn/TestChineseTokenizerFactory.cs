// Lucene version compatibility level 4.8.1
using System;
using System.IO;
using NUnit.Framework;
using Lucene.Net.Analysis.Util;

namespace Lucene.Net.Analysis.Cn
{
    /*
     * Licensed to the Apache Software Foundation (ASF) under one or more
     * contributor license agreements.  See the NOTICE file distributed with
     * this work for additional information regarding copyright ownership.
     * The ASF licenses this file to You under the Apache License, Version 2.0
     * (the "License"); you may not use this file except in compliance with
     * the License.  You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */

    /// <summary>
    /// Simple tests to ensure the Chinese tokenizer factory is working.
    /// </summary>
    public class TestChineseTokenizerFactory : BaseTokenStreamFactoryTestCase
    {
        /// <summary>
        /// Ensure the tokenizer actually tokenizes chinese text correctly
        /// </summary>
        [Test]
        public virtual void TestTokenizer()
        {
            TextReader reader = new StringReader("我是中国人");
            TokenStream stream = TokenizerFactory("Chinese").Create(reader);
            AssertTokenStreamContents(stream, new string[] { "我", "是", "中", "国", "人" });
        }

        /// <summary>
        /// Test that bogus arguments result in exception </summary>
        [Test]
        public virtual void TestBogusArguments()
        {
            try
            {
                TokenizerFactory("Chinese", "bogusArg", "bogusValue");
                fail();
            }
            catch (Exception expected) when (expected.IsIllegalArgumentException())
            {
                assertTrue(expected.Message.Contains("Unknown parameters"));
            }
        }
    }
}