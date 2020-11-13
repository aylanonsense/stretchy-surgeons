using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeons {
	public abstract class TileEntity : MonoBehaviour
	{
		public Tile tile;
		public TileGrid grid => tile.grid;
		public virtual void Spawn() {}

		public virtual void Despawn() {}

		public virtual void RefreshGraphics() {
			transform.position = new Vector3(grid.transform.position.x + tile.column * Constants.TILE_SIZE, grid.transform.position.y + tile.row * Constants.TILE_SIZE, grid.transform.position.z + transform.position.z);
		}

		public void MoveToTile(Tile tile) {
			Tile prevTile = tile;
			this.tile.RemoveOccupant(this);
			tile.AddOccupant(this);
			grid.OnEntityMove?.Invoke(this, prevTile, tile);
			grid.OnAnyChange?.Invoke();
			RefreshGraphics();
		}

		public void MoveToTile(TileCoords coords) {
			MoveToTile(grid.GetTile(coords));
		}

		public void MoveToTile(int column, int row) {
			MoveToTile(grid.GetTile(column, row));
		}

		public void MoveInDirection(Direction direction) {
			MoveToTile(grid.GetTileInDirection(tile, direction));
		}

		public bool CanMoveToTile(Tile tile) {
			return CanEnterTile(tile) && CanExitCurrentTile();
		}

		public bool CanMoveToTile(TileCoords coords) {
			return CanMoveToTile(grid.GetTile(coords));
		}

		public bool CanMoveToTile(int column, int row) {
			return CanMoveToTile(grid.GetTile(column, row));
		}

		public bool CanMoveInDirection(Direction direction) {
			return CanMoveToTile(grid.GetTileInDirection(tile, direction));
		}

		public bool CanEnterTile(Tile tile) {
			return tile != null && !tile.HasOccupants();
		}

		public bool CanEnterTile(TileCoords coords) {
			return CanEnterTile(grid.GetTile(coords));
		}

		public bool CanEnterTile(int column, int row) {
			return CanEnterTile(grid.GetTile(column, row));
		}

		public bool CanExitCurrentTile() {
			return true;
		}
	}
}
