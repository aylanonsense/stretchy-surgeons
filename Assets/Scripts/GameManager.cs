using UnityEngine;
using StretchySurgeons.Input;

namespace StretchySurgeons {
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance {
			get {
				if (_instance == null) {
					GameObject gameObject = new GameObject("Game Manager");
					_instance = gameObject.AddComponent<GameManager>();
					DontDestroyOnLoad(gameObject);
				}
				return _instance;
			}
		}
		private static GameManager _instance;

		public InputManager inputManager;

		public GameManager() {
			if (_instance != null && _instance != this)
				Destroy(_instance);
			_instance = this;
			inputManager = new InputManager();
		}

		void LateUpdate() {
			inputManager.Update();
		}
	}
}
