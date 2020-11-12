using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeons {
	public class Tile {
		public TileGrid grid;
		public TileCoords coords;
		private List<TileEntity> occupants;
		public int column => coords.column;
		public int row => coords.row;

		public Tile(TileGrid grid, TileCoords coords) {
			this.grid = grid;
			this.coords = coords;
			occupants = new List<TileEntity>();
		}

		public Tile(TileGrid grid, int column, int row) : this(grid, new TileCoords(column, row)) {}

		public Tile(TileGrid grid, Vector2Int vector) : this(grid, new TileCoords(vector.x, vector.y)) {}

		public void AddOccupant(TileEntity entity) {
			entity.tile = this;
			occupants.Add(entity);
		}

		public void RemoveOccupant(TileEntity entity) {
			if (entity.tile == this)
				entity.tile = null;
			occupants.Remove(entity);
		}

		public bool HasOccupants() {
			return occupants.Count > 0;
		}

		public Tile GetAdjacentTile(Direction direction) {
			return grid.GetTileInDirection(this, direction);
		}

		public List<Tile> GetAdjacentTiles() {
			List<Tile> tiles = new List<Tile>();
			foreach( var direction in DirectionUtils.allDirections) {
				Tile tile = GetAdjacentTile(direction);
				if (tile != null)
					tiles.Add(tile);
			}
			return tiles;
		}

		public bool IsAdjacentToTile(Tile tile) {
			if (grid != tile.grid)
				return false;
			else if (column == tile.column)
				return (row == tile.row - 1) || (row == tile.row + 1);
			else if (row == tile.row)
				return (column == tile.column - 1) || (column == tile.column + 1);
			else
				return false;
		}
	}
}
