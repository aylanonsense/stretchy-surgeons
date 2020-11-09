using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeon {
	[RequireComponent(typeof(Arm))]
	public class PlayerArmController : MonoBehaviour
	{
		private Arm arm;

		void Start() {
			arm = GetComponent<Arm>();
		}

		void Update() {
			if (Input.GetKeyDown(KeyCode.W))
				arm.Move(Direction.North);

			if (Input.GetKeyDown(KeyCode.A))
				arm.Move(Direction.West);

			if (Input.GetKeyDown(KeyCode.S))
				arm.Move(Direction.South);

			if (Input.GetKeyDown(KeyCode.D))
				arm.Move(Direction.East);

			if (Input.GetKeyDown(KeyCode.Backspace))
				arm.Retract();
		}
	}
}
