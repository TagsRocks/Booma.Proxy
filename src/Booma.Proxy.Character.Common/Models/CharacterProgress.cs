﻿using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	/// <summary>
	/// The model for progress of a character.
	/// </summary>
	[WireDataContract]
	public sealed class CharacterProgress
	{
		/// <summary>
		/// Experience earned by the character.
		/// </summary>
		[WireMember(1)]
		public uint Experience { get; }

		/// <summary>
		/// Level of the character.
		/// </summary>
		[WireMember(2)]
		public uint Level { get; }

		//Serializer ctor
		private CharacterProgress()
		{
			
		}
	}
}