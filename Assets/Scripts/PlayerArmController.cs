using UnityEngine;
using StretchySurgeons.Input;

namespace StretchySurgeons {
	[RequireComponent(typeof(Arm))]
	public class PlayerArmController : MonoBehaviour
	{
		private Arm arm;
		public PlayerNum player;
		private PlayerControls controls;

		void Awake() {
			arm = GetComponent<Arm>();
			controls = GameManager.I.inputManager.GetPlayerControls(player);
		}

		void OnEnable() {
			if (controls != null) {
				controls.OnPressedDirection += Move;
				controls.OnPressedCancel += Retract;
			}
		}

		void OnDisable() {
			if (controls != null) {
				controls.OnPressedDirection -= Move;
				controls.OnPressedCancel += Retract;
			}
		}

		private void Move(Direction direction) {
			arm.Move(direction);
		}

		private void Retract() {
			arm.Retract();
		}
	}
}
