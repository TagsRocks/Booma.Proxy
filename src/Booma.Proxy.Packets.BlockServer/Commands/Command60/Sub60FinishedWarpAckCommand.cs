﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace Booma.Proxy
{
	//TODO: What is this?
	/// <summary>
	/// Command sent to set position and alert other clients
	/// when they finish warping.
	/// </summary>
	[WireDataContract]
	[SubCommand60(SubCommand60OperationCode.AlertFreshlyWarpedClients)]
	public sealed class Sub60FinishedWarpAckCommand : BaseSubCommand60, ICommandClientIdentifiable
	{
		/// <inheritdoc />
		[WireMember(1)]
		public byte ClientId { get; }

		[WireMember(2)]
		private byte unusued { get; }

		/// <summary>
		/// The client that is moving.
		/// </summary>
		[WireMember(3)]
		public int ZoneId { get; }

		/// <summary>
		/// The position the client has moved to.
		/// </summary>
		[WireMember(4)]
		public Vector3<float> Position { get; } //server should set X and Z, ignoring y.

		//TODO: Soly said this is rotation so we should handle it 65536f / 360f
		[WireMember(5)]
		public int Rotation { get; }
		
		public Sub60FinishedWarpAckCommand(byte clientId, int zoneId, [NotNull] Vector3<float> position)
			: this()
		{
			if(position == null) throw new ArgumentNullException(nameof(position));
			if(zoneId < 0) throw new ArgumentOutOfRangeException(nameof(zoneId));

			ClientId = clientId;
			ZoneId = zoneId;
			Position = position;
		}

		public Sub60FinishedWarpAckCommand(int clientId, int zoneId, [NotNull] Vector3<float> position)
			: this((byte)clientId, zoneId, position)
		{

		}

		//Serializer ctor
		public Sub60FinishedWarpAckCommand()
		{
			//Calc static 32bit size
			CommandSize = 24 / 4;
		}
	}
}
