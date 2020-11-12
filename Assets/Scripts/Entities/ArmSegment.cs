using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeons {
	public class ArmSegment : TileEntity
	{
		[Header("Params")]
		public Direction directionIn;
		public Direction directionOut;
		public Material material {
			get { return sprite.material; }
			set { sprite.material = value; }
		}

		[Header("Children")]
		[SerializeField] private SpriteRenderer sprite;

		[Header("Assets")]
		[SerializeField] private Sprite straightArmSprite;
		[SerializeField] private Sprite cornerArmSprite;

		public override void RefreshGraphics() {
			base.RefreshGraphics();
			float rotation;
			if (directionIn == DirectionUtils.GetOppositeDirection(directionOut)) {
				sprite.sprite = straightArmSprite;
				rotation = DirectionUtils.DirectionToDegreesRotation(directionOut);
			}
			else {
				sprite.sprite = cornerArmSprite;
				rotation = DirectionUtils.DirectionToDegreesRotation((directionIn == DirectionUtils.GetClockwiseDirection(directionOut)) ? directionIn : directionOut);
			}
			transform.eulerAngles = new Vector3(0, 0, rotation);
		}
	}
}
