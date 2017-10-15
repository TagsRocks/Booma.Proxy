﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	/// <summary>
	/// An unimplemented or unknown subcommand for the <see cref="BlockNetworkCommandEventServerPayload"/>.
	/// </summary>
	[WireDataContract]
	public sealed class UnknownSubCommand60ServerEvent : BaseSubCommand60Server, IUnknownPayloadType
	{
		/// <inheritdoc />
		public short OperationCode => (short)base.CommandOperationCode;

		/// <inheritdoc />
		[ReadToEnd]
		[WireMember(1)]
		public byte[] UnknownBytes { get; } = new byte[0]; //readtoend requires at least an empty array init

		private UnknownSubCommand60ServerEvent()
		{
			
		}

		/// <inheritdoc />
		public override string ToString()
		{
			if(Enum.IsDefined(typeof(SubCommand60OperationCode), (byte)OperationCode))
				return $"Unknown Subcommand60 OpCode: {OperationCode:X} Name: {((SubCommand60OperationCode)OperationCode).ToString()} Type: {GetType().Name} CommandSize: {CommandSize * 4} (bytes size)";
			else
				return $"Unknown Subcommand60 OpCode: {OperationCode:X} Type: {GetType().Name} CommandSize: {CommandSize * 4} (bytes size)";
		}
	}
}