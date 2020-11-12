using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeons {
	public class Hand : TileEntity {
		[Header("Params")]
		public Direction direction = Direction.East;
		public bool isRightHand = true;
		public Material material;

		[Header("Children")]
		[SerializeField] private SpriteRenderer sprite;

		[Header("Assets")]
		[SerializeField] private Sprite thumbUpHandSprite;
		[SerializeField] private Sprite thumbDownHandSprite;

		public override void Refresh()
		{
			base.Refresh();
			transform.eulerAngles = new Vector3(0, isRightHand ? 0 : 180, DirectionUtils.DirectionToDegreesRotation(isRightHand ? direction : DirectionUtils.FlipDirectionHorizontally(direction)));
			sprite.material = material;
		}
	
	}
}
