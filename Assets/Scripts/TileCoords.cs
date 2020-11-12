using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeons {
	public class TileCoords {
		public int column;
		public int row;

		public TileCoords(int column, int row) {
			this.column = column;
			this.row = row;
		}

		public TileCoords(Vector2Int vector) : this(vector.x, vector.y) {}

		public TileCoords GetCoordinatesInDirection(Direction direction) {
			Vector2Int vector = DirectionUtils.DirectionToVector(direction);
			return new TileCoords(column + vector.x, row + vector.y);
		}
	}
}
