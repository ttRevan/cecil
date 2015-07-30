//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2015 Jb Evain
// Copyright (c) 2008 - 2011 Novell, Inc.
//
// Licensed under the MIT/X11 license.
//

using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata {

	sealed class PdbHeap : Heap {

		public PdbHeap (Section section, uint offset, uint size)
			: base (section, offset, size)
		{
		}
	}
}
