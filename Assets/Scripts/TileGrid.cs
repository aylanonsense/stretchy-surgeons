using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StretchySurgeons {
	public class TileGrid : MonoBehaviour
	{
		public int columns = 10;
		public int rows = 10;

		public Action<TileEntity> OnEntitySpawned;
		public Action<TileEntity> OnEntityDespawned;

		private Tile[,] tiles;
		private List<TileEntity> entities;

		void Awake() {
			tiles = new Tile[columns, rows];
			for (int column = 0; column < columns; column++)
				for (int row = 0; row < rows; row++)
					tiles[column, row] = new Tile(this, column, row);
			entities = new List<TileEntity>();
		}

		void Start() {
			TileEntity[] existingEntities = GetComponentsInChildren<TileEntity>();
			foreach (var entity in existingEntities)
				SpawnEntity(entity);
		}

		public TileEntity SpawnEntity(TileEntity entity, Tile tile) {
			entities.Add(entity);
			tile.AddOccupant(entity);
			entity.Refresh();
			entity.Spawn();
			OnEntitySpawned?.Invoke(entity);
			return entity;
		}

		public TileEntity SpawnEntity(TileEntity entity) {
			int column = (int) Mathf.Clamp(((entity.transform.position.x - transform.position.x) / Constants.TILE_SIZE), 0, columns - 1);
			int row = (int) Mathf.Clamp(((entity.transform.position.y - transform.position.y) / Constants.TILE_SIZE), 0, rows - 1);
			return SpawnEntity(entity, column, row);
		}

		public TileEntity SpawnEntity(TileEntity entity, TileCoords coords) {
			return SpawnEntity(entity, coords.column, coords.row);
		}

		public TileEntity SpawnEntity(TileEntity entity, int column, int row) {
			return SpawnEntity(entity, GetTile(column, row));
		}

		public void DespawnEntity(TileEntity entity) {
			entities.Remove(entity);
			if (entity.tile != null)
				entity.tile.RemoveOccupant(entity);
			entity.Despawn();
			OnEntityDespawned?.Invoke(entity);
			Destroy(entity.gameObject);
		}

		public bool IsInBounds(int column, int row) {
			return 0 <= column && column < columns && 0 <= row && row < rows;
		}

		public bool IsInBounds(TileCoords coords) {
			return IsInBounds(coords.column, coords.row);
		}

		public Tile GetTile(int column, int row) {
			return IsInBounds(column, row) ? tiles[column, row] : null;
		}

		public Tile GetTile(TileCoords coords) {
			return GetTile(coords.column, coords.row);
		}

		public Tile GetTileInDirection(int column, int row, Direction direction) {
			Vector2Int vector = DirectionUtils.DirectionToVector(direction);
			return GetTile(column + vector.x, row + vector.y);
		}

		public Tile GetTileInDirection(TileCoords coords, Direction direction) {
			return GetTileInDirection(coords.column, coords.row, direction);
		}

		public Tile GetTileInDirection(Tile tile, Direction direction) {
			return GetTileInDirection(tile.column, tile.row, direction);
		}
	}
}
