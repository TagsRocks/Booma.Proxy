﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booma.Proxy
{
	public sealed class BlowfishDecryptionService : BaseBlowfishCryptoService
	{
		/// <summary>
		/// Decrypt data
		/// </summary>
		/// <param name="data">Data to decrypt</param>
		/// <param name="offset">Position where the decryption will start</param>
		/// <param name="length">Number of bytes to decrypt</param>
		public void Decrypt(byte[] data, int offset, int length)
		{
			if(!isInitialized)
				throw new InvalidOperationException($"Cannot use the {nameof(BlowfishDecryptionService)} if it has not yet been initialized.");

			uint v1, v2;
			for(int i1 = 0; i1 < (length / 8); i1++)
			{
				v1 = UInt32(data, offset + i1 * 8);
				v2 = UInt32(data, offset + i1 * 8 + 4);
				DecryptBlock(ref v1, ref v2);
				UInt32(data, offset + i1 * 8, v1);
				UInt32(data, offset + i1 * 8 + 4, v2);
			}
		}
		private void DecryptBlock(ref uint L, ref uint R)
		{
			for(int i1 = 4; i1 > 0; i1 -= 2)
			{
				L ^= this.P[i1 + 1];
				R ^= F(L);
				R ^= this.P[i1];
				L ^= F(R);
			}
			L ^= this.P[1];
			R ^= this.P[0];

			uint t = L;
			L = R;
			R = t;
		}

		/// <inheritdoc />
		public override byte[] Crypt(byte[] bytes)
		{
			if(bytes.Length % 8 != 0)
				throw new InvalidOperationException("Cannot handle blocks of length % 8 != 0.");

			Decrypt(bytes, 0, bytes.Length);
			return bytes;
		}

		/// <inheritdoc />
		public override byte[] Crypt(byte[] bytes, int offset, int count)
		{
			if(bytes.Length < count || count % 8 != 0)
				throw new InvalidOperationException("Cannot handle blocks of length % 8 != 0.");

			Decrypt(bytes, offset, count);
			return bytes;
		}
	}
}
