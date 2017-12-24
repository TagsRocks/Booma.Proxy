﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	/// <summary>
	/// Command sent by players to the server when the character is entering an operation
	/// that requires it to freeze or has a start and end part of the operation.
	/// Such as dropping an item, dying or chatting with an NPC.
	/// </summary>
	[WireDataContract]
	[SubCommand60(SubCommand60OperationCode.FreezePlayer)]
	public sealed class Sub60PlayerFreezeCommand : BaseSubCommand60, IMessageContextIdentifiable
	{
		/// <summary>
		/// Enumeration of operation types.
		/// According to Sylverant documentation of 0x60 subcommand packets.
		/// </summary>
		public enum FreezeReason : uint //TODO: Is this uint? There are 2 0 bytes afterwards for the field here but not sure
		{
			/// <summary>
			/// Indicates the operation involves dropping an item.
			/// </summary>
			ItemDrop = 0x0384,

			/// <summary>
			/// 
			/// </summary>
			NPCChat = 0xFFFF,
		}

		//Client ID/Lobbyslot
		/// <inheritdoc />
		[WireMember(1)]
		public byte Identifier { get; }

		//TODO: What is this?
		[WireMember(2)]
		public byte Unknown1 { get; }

		/// <summary>
		/// Indicates reason for the reason for the freeze event.
		/// </summary>
		[WireMember(3)]
		public FreezeReason Reason { get; } //4 bytes, last 2 usually 0x0000 but might not be apart of the enum

		//TODO: Is this really a vector4?

		/// <summary>
		/// The position the player with <see cref="Identifier"/> id is at.
		/// Contains the X and Z component of the position.
		/// </summary>
		[WireMember(4)]
		public Vector2<float> Position { get; }

		//TODO: Do we need this? Is it ever not 0?
		//TODO: Sylverant has some additional bytes here. Says they're padding. Do we need them?
		[WireMember(5)]
		public int Unknown2 { get; }

		//Serializer ctor
		private Sub60PlayerFreezeCommand()
		{
			
		}
	}
}
