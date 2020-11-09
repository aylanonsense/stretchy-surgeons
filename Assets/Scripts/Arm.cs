using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeon {
	public class Arm : MonoBehaviour
	{
		[Header("Children")]
		public Transform handSprite;

		[Header("Sprites")]
		public Sprite straightArmSprite;
		public Sprite curvedArmSprite;
		public Sprite handThumbUpSprite;
		public Sprite handThumbDownSprite;

		private Vector2Int handTile;
		private Direction handDirection;

		void Start() {
			handTile = new Vector2Int(0, 0);
			handDirection = Direction.East;
			UpdateHandSprite();
		}

		public void Move(Direction direction) {
			handTile += DirectionUtils.DirectionToVector(direction);
			handDirection = direction;
			UpdateHandSprite();
		}

		private void UpdateHandSprite() {
			handSprite.position = new Vector3(handTile.x * Constants.TILE_SIZE, handTile.y * Constants.TILE_SIZE, handSprite.position.z);
			handSprite.eulerAngles = new Vector3(0, 0, DirectionUtils.DirectionToDegreesRotation(handDirection));
		}
	}
}
