using System;
using UnityEngine;

namespace Booma.Proxy
{
	public static class UnitScalerStrategyExtensions
	{
		/// <summary>
		/// Fully scales the <see cref="Vector3"/> by the scaling.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector3 Scale(this IUnitScalerStrategy scaler, Vector3 vector)
		{
			return new Vector3(scaler.ScaleX(vector.x), scaler.ScaleY(vector.y), scaler.ScaleZ(vector.z));
		}

		/// <summary>
		/// Fully scales the <see cref="Vector2"/> by the scaling.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector2 Scale(this IUnitScalerStrategy scaler, Vector2 vector)
		{
			return new Vector3(scaler.ScaleX(vector.x), scaler.ScaleY(vector.y));
		}

		/// <summary>
		/// Fully scales the <see cref="Vector2"/> by the scaling.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector2 ScaleYasZ(this IUnitScalerStrategy scaler, Vector2 vector)
		{
			return new Vector3(scaler.ScaleX(vector.x), scaler.ScaleZ(vector.y));
		}

		/// <summary>
		/// Fully scales the <see cref="Vector2"/> by the scaling.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector2 ScaleYasZ(this IUnitScalerStrategy scaler, Vector2<float> vector)
		{
			return new Vector3(scaler.ScaleX(vector.X), scaler.ScaleZ(vector.Y));
		}

		/// <summary>
		/// Scales the <see cref="Vector3"/> by the scaling with the option to ignore some dimensions flags.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <param name="ignoreFlags">Which dimensions to ignore.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector3 Scale(this IUnitScalerStrategy scaler, Vector3 vector, UnitScaleFlags ignoreFlags)
		{
			float x = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.X) ? vector.x : scaler.ScaleX(vector.x);
			float y = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.Y) ? vector.y : scaler.ScaleY(vector.y); ;
			float z = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.Z) ? vector.z : scaler.ScaleZ(vector.z); ;

			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Fully scales the <see cref="Vector3"/> by the scaling.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector3 Scale(this IUnitScalerStrategy scaler, Vector3<float> vector)
		{
			return new Vector3(scaler.ScaleX(vector.X), scaler.ScaleY(vector.Y), scaler.ScaleZ(vector.Z));
		}

		/// <summary>
		/// Fully scales the <see cref="Vector2"/> by the scaling.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector2 Scale(this IUnitScalerStrategy scaler, Vector2<float> vector)
		{
			return new Vector2(scaler.ScaleX(vector.X), scaler.ScaleY(vector.Y));
		}

		/// <summary>
		/// Scales the <see cref="Vector3"/> by the scaling.
		/// Will use the vector2's Y component as the Vector3's Z component.
		/// Will use the Y component of the original vector.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector3 ScaleYtoZ(this IUnitScalerStrategy scaler, Vector3 vector)
		{
			return new Vector3(scaler.ScaleX(vector.x), vector.y, scaler.ScaleZ(vector.z));
		}

		/// <summary>
		/// Scales the <see cref="Vector3"/> by the scaling with the option to ignore some dimensions flags.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <param name="ignoreFlags">Which dimensions to ignore.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector3 Scale(this IUnitScalerStrategy scaler, Vector3<float> vector, UnitScaleFlags ignoreFlags)
		{
			float x = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.X) ? vector.X : scaler.ScaleX(vector.X);
			float y = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.Y) ? vector.Y : scaler.ScaleY(vector.Y); ;
			float z = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.Z) ? vector.Z : scaler.ScaleZ(vector.Z); ;

			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Fully unscales the <see cref="Vector3"/> using the scaling service
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector3 UnScale(this IUnitScalerStrategy scaler, Vector3 vector)
		{
			return new Vector3(scaler.UnScaleX(vector.x), scaler.UnScaleY(vector.y), scaler.UnScaleZ(vector.z));
		}

		/// <summary>
		/// Unscales the <see cref="Vector3"/> by the unscaling with the option to ignore some dimensions flags.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <param name="ignoreFlags">Which dimensions to ignore.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector3 UnScale(this IUnitScalerStrategy scaler, Vector3 vector, UnitScaleFlags ignoreFlags)
		{
			float x = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.X) ? vector.x : scaler.UnScaleX(vector.x);
			float y = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.Y) ? vector.y : scaler.UnScaleY(vector.y); ;
			float z = ignoreFlags.QuickFlagsCheck(UnitScaleFlags.Z) ? vector.z : scaler.UnScaleZ(vector.z); ;

			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Unsclaes the <see cref="Vector3"/> by the scaling.
		/// Maps the Z component of the <see cref="Vector3"/> to the Y component of the
		/// <see cref="Vector2{T}"/>.
		/// </summary>
		/// <param name="scaler">The scaling service.</param>
		/// <param name="vector">The vector to scale.</param>
		/// <returns>A new scaled vector.</returns>
		public static Vector2<float> UnScaleYtoZ(this IUnitScalerStrategy scaler, Vector3 vector)
		{
			return new Vector2<float>(scaler.UnScaleX(vector.x), scaler.UnScaleZ(vector.z));
		}

		/// <summary>
		/// Scales the Y rotation based on the unit scale.
		/// </summary>
		/// <param name="scaler">The scaler.</param>
		/// <param name="rotation">The rotation to scale.</param>
		/// <returns></returns>
		public static float ScaleYRotation(this IUnitScalerStrategy scaler, float rotation)
		{
			//TODO: IS this right?
			//This is odd but if we have both Z and X flipped then the Y will be the same.
			return (Math.Sign(scaler.ScaleZ(1)) + Math.Sign(scaler.ScaleX(1))) <= 0.0f ? -rotation + 180f : rotation;
		}

		/// <summary>
		/// Unscales the Y rotation based on the unit scale.
		/// </summary>
		/// <param name="scaler">The scaler.</param>
		/// <param name="rotation">The rotation to scale.</param>
		/// <returns></returns>
		public static float UnScaleYRotation(this IUnitScalerStrategy scaler, float rotation)
		{
			//TODO: IS this right?
			//This is odd but if we have both Z and X flipped then the Y will be the same.
			return (Math.Sign(scaler.ScaleZ(1)) + Math.Sign(scaler.ScaleX(1))) <= 0.0f ? -rotation : rotation;
		}

		public static bool QuickFlagsCheck(this UnitScaleFlags flags, UnitScaleFlags flag)
		{
			return (flags & flag) != 0;
		}
	}
}