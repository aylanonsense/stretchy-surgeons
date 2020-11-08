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

		private float randomWalkTimer = 0;

		void Start() {
			handTile = new Vector2Int(0, 0);
			handDirection = Direction.East;
			UpdateHandSprite();
		}

		void Update() {
			// Random walk for debug purposes at first
			randomWalkTimer += Time.deltaTime;
			if (randomWalkTimer >= 0.5f) {
				randomWalkTimer = 0;
				Move(DirectionUtils.GetRandomDirection());
			}
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
