﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Booma.Proxy
{
	public sealed class TestingRoomSystem : SerializedMonoBehaviour, IRoomQueryable, IRoomCollection
	{
		[OdinSerialize]
		private IRoom _defaultRoom;

		/// <inheritdoc />
		public IRoom DefaultRoom => _defaultRoom;

		private IDictionary<int, IRoom> PlayerRoomTracker { get; set; } = new Dictionary<int, IRoom>();

		/// <inheritdoc />
		public short RoomIdForPlayerById(int playerId)
		{
			if(PlayerRoomTracker.ContainsKey(playerId))
				return PlayerRoomTracker[playerId].RoomId;
			else
				return 0;
		}

		/// <inheritdoc />
		public IEnumerator<IRoom> GetEnumerator()
		{
			//TODO: Implement multiple rooms.
			return null;
		}

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
		{
			//TODO: Implement multiple rooms.
			return null;
		}
	}
}
