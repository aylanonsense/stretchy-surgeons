using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StretchySurgeons {
	public class Arm : MonoBehaviour
	{
		[Header("Children")]
		[SerializeField] private Hand hand;
		[SerializeField] private List<ArmSegment> armSegments;
		[SerializeField] private TileGrid interiorGrid;

		[Header("Assets")]
		[SerializeField] private ArmSegment armSegmentPrefab;

		private TileGrid exteriorGrid => hand.grid;
		[SerializeField] private TileGrid grid;

		public void Move(Direction direction) {
			if (direction == DirectionUtils.GetOppositeDirection(hand.direction)) {
				if (armSegments.Count > 0) {
					ArmSegment armSegment = armSegments[armSegments.Count - 1];
					armSegments.RemoveAt(armSegments.Count - 1);
					hand.direction = DirectionUtils.GetOppositeDirection(armSegment.directionIn);
					hand.MoveToTile(armSegment.tile);
					grid.DespawnEntity(armSegment);
				}
			}
			else if (hand.CanMoveInDirection(direction)) {
				Direction prevDirection = hand.direction;
				Tile tile = hand.tile;
				hand.direction = direction;
				hand.MoveInDirection(direction);
				ArmSegment armSegment = Instantiate(armSegmentPrefab, new Vector3(), Quaternion.identity);
				armSegment.grid = grid;
				armSegment.transform.parent = transform;
				armSegment.directionIn = DirectionUtils.GetOppositeDirection(prevDirection);
				armSegment.directionOut = direction;
				armSegment.material = hand.material;
				armSegments.Add(armSegment);
				grid.SpawnEntity(armSegment, tile);
			}
		}

		public void Retract() {
			Move(DirectionUtils.GetOppositeDirection(hand.direction));
		}

		public void EnterBody() {
			Direction prevDirection = hand.direction;
			Tile tile = hand.tile;
			hand.direction = Direction.East;

			Tile interiorTile = interiorGrid.GetTile(0,0);
			hand.MoveToTile(interiorTile);
			hand.grid = interiorGrid;

			ArmSegment armSegment = Instantiate(armSegmentPrefab, new Vector3(), Quaternion.identity);
			armSegment.grid = exteriorGrid;
			armSegment.transform.parent = transform;
			armSegment.directionIn = DirectionUtils.GetOppositeDirection(prevDirection);
			armSegment.directionOut = prevDirection;
			armSegment.material = hand.material;
			armSegments.Add(armSegment);
			grid.SpawnEntity(armSegment, tile);
			grid = interiorGrid;
		}
	}
}
