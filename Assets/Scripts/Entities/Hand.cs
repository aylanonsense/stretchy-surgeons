using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeons {
	public class Hand : TileEntity {
		[Header("Params")]
		public Direction direction = Direction.East;
		public bool isRightHand = true;
		public Material material {
			get { return sprite.material; }
			set { sprite.material = value; }
		}
		public Direction thumbDirection => isRightHand ? DirectionUtils.GetCounterClockwiseDirection(direction) : DirectionUtils.GetClockwiseDirection(direction);

		[Header("Children")]
		[SerializeField] private SpriteRenderer sprite;

		[Header("Assets")]
		[SerializeField] private Sprite thumbUpHandSprite;
		[SerializeField] private Sprite thumbDownHandSprite;

		public override void Spawn() {
			base.Spawn();
			grid.OnAnyChange += () => CheckForThumbChange();
		}

		public override void Despawn() {
			base.Despawn();
			grid.OnAnyChange -= () => CheckForThumbChange();
		}

		private void CheckForThumbChange() {
			Tile thumbTile = grid.GetTileInDirection(tile, thumbDirection);
			bool shouldHaveThumbDown = thumbTile != null && thumbTile.HasOccupants();
			sprite.sprite = shouldHaveThumbDown ? thumbDownHandSprite : thumbUpHandSprite;
		}

		public override void RefreshGraphics()
		{
			base.RefreshGraphics();
			CheckForThumbChange();
			transform.eulerAngles = new Vector3(0, isRightHand ? 0 : 180, DirectionUtils.DirectionToDegreesRotation(isRightHand ? direction : DirectionUtils.FlipDirectionHorizontally(direction)));
		}
	}
}
