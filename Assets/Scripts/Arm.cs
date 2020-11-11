using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StretchySurgeon {
	public class Arm : Entity
	{
		[Header("Children")]
		public GameObject hand;

		[Header("Sprites")]
		public Sprite straightArmSprite;
		public Sprite curvedArmSprite;
		public Sprite handThumbUpSprite;
		public Sprite handThumbDownSprite;

		[Header("Start Location")]
		public Vector2Int startLocation;

		private Vector2Int handTile;
		private Direction handDirection;
		private Material material;
		private List<ArmSegment> armSegments;

		void Start() {
			handTile = startLocation;
			handDirection = Direction.East;
			armSegments = new List<ArmSegment>();
			material = hand.GetComponent<SpriteRenderer>().material;
			UpdateHandSprite();
		}

		public void Move(Direction direction) {
			// When retracting the arm, remove the previous arm segment
			if (direction == DirectionUtils.GetOppositeDirection(handDirection)) {
				if (armSegments.Count > 0) {
					ArmSegment armSegment = armSegments[armSegments.Count - 1];
					armSegments.RemoveAt(armSegments.Count - 1);
					// Destroy the game object that's rendering the arm segment
					Destroy(armSegment.gameObject);
					// Move the hand to where the arm segment used to be
					handTile = armSegment.tile;
					handDirection = armSegment.directionIn;
					UpdateHandSprite();
				}
			}
			// Move the hand and add a new arm segment behind it
			else {
				Vector2Int nextTile = handTile + DirectionUtils.DirectionToVector(direction);
				if (!grid.IsTileOccupied(nextTile)) {
					CreateArmSegment(handTile, handDirection, direction);
					handTile = nextTile;
					handDirection = direction;
					UpdateHandSprite();
				}
			}
		}

		public void Retract() {
			Move(DirectionUtils.GetOppositeDirection(handDirection));
		}

		public override bool IsOccupyingTile(Vector2Int tile) {
			return handTile == tile || armSegments.Any(armSegment => armSegment.tile == tile);
		}

		private void UpdateHandSprite() {
			hand.transform.position = new Vector3(handTile.x * Constants.TILE_SIZE, handTile.y * Constants.TILE_SIZE, hand.transform.position.z);
			hand.transform.eulerAngles = new Vector3(0, 0, DirectionUtils.DirectionToDegreesRotation(handDirection));
		}

		private void CreateArmSegment(Vector2Int tile, Direction directionIn, Direction directionOut) {
			// Create a new game object to represent the arm
			GameObject arm = new GameObject("Arm Segment");
			SpriteRenderer renderer = arm.AddComponent<SpriteRenderer>();
			// Figure out the right sprite and rotation
			Sprite sprite;
			float rotation;
			if (directionOut == directionIn) {
				sprite = straightArmSprite;
				rotation = DirectionUtils.DirectionToDegreesRotation(directionOut);
			}
			else {
				sprite = curvedArmSprite;
				rotation = DirectionUtils.DirectionToDegreesRotation(directionOut == DirectionUtils.GetClockwiseDirection(directionIn) ? DirectionUtils.GetOppositeDirection(directionIn) : directionOut);
			}
			// Set the arm's position, rotation, and sprite
			arm.transform.position = new Vector3(tile.x * Constants.TILE_SIZE, tile.y * Constants.TILE_SIZE, arm.transform.position.z);
			arm.transform.eulerAngles = new Vector3(0, 0, rotation);
			renderer.sprite = sprite;
			renderer.material = material;
			// Add it as a child
			arm.transform.parent = transform;
			// Keep track of the arm segments in a list
			armSegments.Add(new ArmSegment {
				gameObject = arm,
				tile = tile,
				directionIn = directionIn,
				directionOut = directionOut
			});
		}

		private class ArmSegment {
			public GameObject gameObject;
			public Vector2Int tile;
			public Direction directionIn;
			public Direction directionOut;
		}
	}
}
