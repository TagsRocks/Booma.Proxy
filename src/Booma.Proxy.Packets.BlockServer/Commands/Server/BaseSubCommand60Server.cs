﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	/// <summary>
	/// The base type for the subcommand sent in the 0x60 packets.
	/// Sent by the server.
	/// </summary>
	[DefaultChild(typeof(UnknownSubCommand60ServerEvent))]
	[WireDataContract(WireDataContractAttribute.KeyType.Byte, InformationHandlingFlags.DontConsumeRead, true)]
	public abstract class BaseSubCommand60Server : ISubCommand60
	{
		/// <summary>
		/// The operation code for the subcommand.
		/// This is only read for logging of unknown subcommands.
		/// </summary>
		[DontWrite]
		[WireMember(1)]
		public SubCommand60OperationCode CommandOperationCode { get; }

		/// <summary>
		/// Indicates if the <see cref="CommandSize"/> property is serialized and
		/// deserialized.
		/// Child Types can override this to gain access to the single Byte size if needed.
		/// </summary>
		public virtual bool isSizeSerialized { get; } = true;

		//Since the Type byte is eaten by the polymorphic deserialization process
		//We just read t he size to discard it
		/// <summary>
		/// The size of the subcommand (subpayload).
		/// Not needed for deserialization of subcommand.
		/// </summary>
		[Optional(nameof(isSizeSerialized))]
		[WireMember(2)]
		public byte CommandSize { get; }

		//Serializer ctor
		protected BaseSubCommand60Server()
		{
			
		}
	}
}
