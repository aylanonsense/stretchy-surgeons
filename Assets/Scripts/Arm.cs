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

		[Header("Assets")]
		[SerializeField] private ArmSegment armSegmentPrefab;

		private TileGrid grid => hand.grid;

		public void Move(Direction direction) {
			if (direction == DirectionUtils.GetOppositeDirection(hand.direction)) {
				if (armSegments.Count > 0) {
					ArmSegment armSegment = armSegments[armSegments.Count - 1];
					armSegments.RemoveAt(armSegments.Count - 1);
					hand.direction = DirectionUtils.GetOppositeDirection(armSegment.directionIn);
					hand.MoveToTile(armSegment.tile);
					grid.DespawnEntity(armSegment);
					hand.animateSquash();
				}
			}
			else if (hand.CanMoveInDirection(direction)) {
				Direction prevDirection = hand.direction;
				Tile tile = hand.tile;
				hand.direction = direction;
				hand.MoveInDirection(direction);
				ArmSegment armSegment = Instantiate(armSegmentPrefab, new Vector3(), Quaternion.identity);
				armSegment.transform.parent = transform;
				armSegment.directionIn = DirectionUtils.GetOppositeDirection(prevDirection);
				armSegment.directionOut = direction;
				armSegment.material = hand.material;
				armSegments.Add(armSegment);
				grid.SpawnEntity(armSegment, tile);
				hand.animateStretch();
			}
			else {
				hand.animateSquash();
			}
		}

		public void Retract() {
			Move(DirectionUtils.GetOppositeDirection(hand.direction));
		}
	}
}
