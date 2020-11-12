using UnityEngine;

namespace StretchySurgeons {
	// Miscellaneous helper functions for working with Directions
	public static class DirectionUtils
	{
		public static Direction[] allDirections = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };

		public static Direction GetOppositeDirection(Direction direction) {
			switch (direction) {
				case Direction.North:
					return Direction.South;
				case Direction.East:
					return Direction.West;
				case Direction.South:
					return Direction.North;
				case Direction.West:
					return Direction.East;
				default:
					return Direction.None;
			}
		}

		public static Direction GetClockwiseDirection(Direction direction) {
			switch (direction) {
				case Direction.North:
					return Direction.East;
				case Direction.East:
					return Direction.South;
				case Direction.South:
					return Direction.West;
				case Direction.West:
					return Direction.North;
				default:
					return Direction.None;
			}
		}

		public static Direction GetCounterClockwiseDirection(Direction direction) {
			switch (direction) {
				case Direction.North:
					return Direction.West;
				case Direction.East:
					return Direction.North;
				case Direction.South:
					return Direction.East;
				case Direction.West:
					return Direction.South;
				default:
					return Direction.None;
			}
		}

		public static Direction FlipDirectionHorizontally(Direction direction) {
			switch (direction) {
				case Direction.East:
					return Direction.West;
				case Direction.West:
					return Direction.East;
				default:
					return direction;
			}
		}

		public static Direction FlipDirectionVertically(Direction direction) {
			switch (direction) {
				case Direction.North:
					return Direction.South;
				case Direction.South:
					return Direction.North;
				default:
					return direction;
			}
		}

		public static Vector2Int DirectionToVector(Direction direction) {
			switch (direction) {
				case Direction.North:
					return Vector2Int.up;
				case Direction.East:
					return Vector2Int.right;
				case Direction.South:
					return Vector2Int.down;
				case Direction.West:
					return Vector2Int.left;
				default:
					return Vector2Int.zero;
			}
		}

		public static float DirectionToDegreesRotation(Direction direction) {
			switch (direction) {
				case Direction.North:
					return 90;
				case Direction.East:
					return 0;
				case Direction.South:
					return -90;
				case Direction.West:
					return 180;
				default:
					return 0;
			}
		}

		public static Direction GetRandomDirection() {
			switch (Random.Range(0, 4)) {
				case 0:
					return Direction.North;
				case 1:
					return Direction.East;
				case 2:
					return Direction.South;
				default:
					return Direction.West;
			}
		}
	}
}
