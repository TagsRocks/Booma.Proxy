﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	/// <summary>
	/// Client file information report
	/// The server decides to patch a file based on this data
	/// </summary>
	[WireDataContract]
	[PatchClientPacketPayload(PatchNetworkOperationCode.PATCH_FILE_INFO_REPLY)]
	public sealed class PatchingFileInformationReplyPayload : PSOBBPatchPacketPayloadClient
	{
		// index
		// checksum
		// size

		/// <summary>
		/// Patch file index
		/// </summary>
		[WireMember(1)]
		public int PatchFileIndex { get; }

		/// <summary>
		/// Patch file checksum
		/// </summary>
		[WireMember(2)]
		public uint PatchFileChecksum { get; }

		/// <summary>
		/// Patch file size
		/// </summary>
		[WireMember(3)]
		public int PatchFileSize { get; }

		public PatchingFileInformationReplyPayload(int patchFileIndex, uint patchFileChecksum, int patchFileSize)
		{
			if (patchFileIndex < 0) throw new ArgumentOutOfRangeException(nameof(patchFileIndex));
			if (patchFileSize < 0) throw new ArgumentOutOfRangeException(nameof(patchFileSize));

			PatchFileIndex = patchFileIndex;
			PatchFileChecksum = patchFileChecksum;
			PatchFileSize = patchFileSize;
		}

		//Serializer ctor
		private PatchingFileInformationReplyPayload()
		{

		}
	}
}
