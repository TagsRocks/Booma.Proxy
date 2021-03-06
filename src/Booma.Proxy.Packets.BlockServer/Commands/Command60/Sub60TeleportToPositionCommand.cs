﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace Booma.Proxy
{
	/*  uint8_t client_id;
		uint8_t unused;
		uint32_t unk;
		float w;
		float x;
		float y;
		float z;
	*/

	//Syl: https://github.com/Sylverant/ship_server/blob/b3bffc84b558821ca2002775ab2c3af5c6dde528/src/subcmd.h#L439
	//Tethella: https://github.com/justnoxx/psobb-tethealla/blob/master/ship_server/ship_server.c#L8356
	/// <summary>
	/// Subcommand payload that will teleport a client to the specified location.
	/// </summary>
	[WireDataContract]
	[SubCommand60(SubCommand60OperationCode.TeleportToPosition)]
	public sealed class Sub60TeleportToPositionCommand : BaseSubCommand60, IMessageContextIdentifiable
	{
		//TODO: Refactor this into an interface or something
		//This is a short to absorb the unused byte
		[WireMember(1)]
		public byte Identifier { get; }

		[WireMember(2)]
		private byte unused { get; }

		//TODO: Handle/document animation states
		[WireMember(3)]
		private int AnimationState { get; } = 0;

		//TODO: Implement this, I think it's ZoneId + RoomId. Though PSOBB doesn't seem to need it
		[WireMember(4)]
		private float w { get; }

		//TODO: The Vector3 may be misordered. Is xyzw but we may need wxyz
		/// <summary>
		/// The position to teleport to.
		/// </summary>
		[WireMember(5)]
		public Vector3<float> Position { get; }

		/// <inheritdoc />
		public Sub60TeleportToPositionCommand(byte clientId, [NotNull] Vector3<float> position)
			: this()
		{
			if(position == null) throw new ArgumentNullException(nameof(position));

			Identifier = clientId;
			Position = position;
		}

		/// <inheritdoc />
		public Sub60TeleportToPositionCommand(int clientId, [NotNull] Vector3<float> position)
			: this((byte)clientId, position)
		{

		}

		public Sub60TeleportToPositionCommand()
		{
			//Calc static 32bit size
			CommandSize = 24 / 4;
		}
	}
}
