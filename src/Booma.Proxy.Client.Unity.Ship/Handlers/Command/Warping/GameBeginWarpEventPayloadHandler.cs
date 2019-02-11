﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using GladNet;
using SceneJect.Common;

namespace Booma.Proxy
{
	/// <summary>
	/// The handler for <see cref="Sub62ClientBurstBeginEventCommand"/> which handles this payload
	/// alerting 
	/// </summary>
	[AdditionalRegisterationAs(typeof(IWarpBeginEventSubscribable))]
	[SceneTypeCreate(GameSceneType.Pioneer2)] //only needed on pioneer2
	public sealed class GameBeginWarpEventPayloadHandler : Command62Handler<Sub62ClientBurstBeginEventCommand>, IWarpBeginEventSubscribable
	{
		/// <inheritdoc />
		public event EventHandler OnBurstBeginning;

		/// <inheritdoc />
		public GameBeginWarpEventPayloadHandler(ILog logger)
			: base(logger)
		{

		}

		/// <inheritdoc />
		protected override Task HandleSubMessage(IPeerMessageContext<PSOBBGamePacketPayloadClient> context, Sub62ClientBurstBeginEventCommand payload)
		{
			if(Logger.IsInfoEnabled)
				Logger.Info($"Recieved: {this.MessageName()} Dispatching: {nameof(IWarpBeginEventSubscribable)}.");

			//TODO: We should really be initializing the quest data, or whatever it is, this packet sends.
			OnBurstBeginning?.Invoke(this, EventArgs.Empty);

			return Task.CompletedTask;
		}
	}
}
