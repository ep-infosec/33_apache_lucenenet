using System;

namespace org.apache.lucene.store
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

	ignore

	/// <summary>
	/// Provides JNI access to native methods such as madvise() for
	/// <seealso cref="NativeUnixDirectory"/>
	/// </summary>
	public final class NativePosixUtil
	{
	  public final static int NORMAL = 0;
	  public final static int SEQUENTIAL = 1;
	  public final static int RANDOM = 2;
	  public final static int WILLNEED = 3;
	  public final static int DONTNEED = 4;
	  public final static int NOREUSE = 5;

//JAVA TO C# CONVERTER NOTE: This static initializer block is converted to a static constructor, but there is no current class:
	  static ImpliedClass()
	  {
//JAVA TO C# CONVERTER TODO TASK: The library is specified in the 'DllImport' attribute for .NET:
//		System.loadLibrary("NativePosixUtil");
	  }

	  private static native int posix_fadvise(FileDescriptor fd, long offset, long len, int advise) throws IOException;
	  public static native int posix_madvise(ByteBuffer buf, int advise) throws IOException;
	  public static native int madvise(ByteBuffer buf, int advise) throws IOException;
	  public static native FileDescriptor open_direct(string filename, bool read) throws IOException;
	  public static native long pread(FileDescriptor fd, long pos, ByteBuffer byteBuf) throws IOException;

	  public static void advise(FileDescriptor fd, long offset, long len, int advise) throws IOException
	  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int code = posix_fadvise(fd, offset, len, advise);
		int code = posix_fadvise(fd, offset, len, advise);
		if (code != 0)
		{
		  throw new Exception("posix_fadvise failed code=" + code);
		}
	  }
	}


}