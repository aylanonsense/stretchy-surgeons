using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StretchySurgeon {
	public class TileGrid : MonoBehaviour
	{
		private List<Entity> entities;

		void Start() {
			entities = new List<Entity>();
			foreach (var entity in GetComponentsInChildren<Entity>())
				AddEntity(entity);
		}

		public void AddEntity(Entity entity) {
			entity.grid = this;
			entities.Add(entity);
		}

		public bool IsTileOccupied(Vector2Int tile) {
			return entities.Any(entity => entity.IsOccupyingTile(tile));
		}
	}
}
