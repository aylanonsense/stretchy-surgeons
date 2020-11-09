﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeon {
	public class Arm : MonoBehaviour
	{
		[Header("Children")]
		public GameObject hand;

		[Header("Sprites")]
		public Sprite straightArmSprite;
		public Sprite curvedArmSprite;
		public Sprite handThumbUpSprite;
		public Sprite handThumbDownSprite;

		private Vector2Int handTile;
		private Direction handDirection;
		private List<ArmSegment> armSegments;

		void Start() {
			handTile = new Vector2Int(0, 0);
			handDirection = Direction.East;
			armSegments = new List<ArmSegment>();
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
				CreateArmSegment(handTile, handDirection, direction);
				handTile += DirectionUtils.DirectionToVector(direction);
				handDirection = direction;
				UpdateHandSprite();
			}
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
