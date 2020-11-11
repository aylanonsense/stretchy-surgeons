using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StretchySurgeons {
	[RequireComponent(typeof(Arm))]
	public class PlayerArmController : MonoBehaviour
	{
		public enum SchemeList{WASD, Arrows};
		public SchemeList controlScheme;

		private Arm arm;

		void Start() {
			arm = GetComponent<Arm>();
		}

		void Update() {
			if(controlScheme==SchemeList.WASD) {
				if (Input.GetKeyDown(KeyCode.W))
					arm.Move(Direction.North);

				if (Input.GetKeyDown(KeyCode.A))
					arm.Move(Direction.West);

				if (Input.GetKeyDown(KeyCode.S))
					arm.Move(Direction.South);

				if (Input.GetKeyDown(KeyCode.D))
					arm.Move(Direction.East);

				if (Input.GetKeyDown(KeyCode.X))
					arm.Retract();
			}
			else {
				if (Input.GetKeyDown(KeyCode.UpArrow))
					arm.Move(Direction.North);

				if (Input.GetKeyDown(KeyCode.LeftArrow))
					arm.Move(Direction.West);

				if (Input.GetKeyDown(KeyCode.DownArrow))
					arm.Move(Direction.South);

				if (Input.GetKeyDown(KeyCode.RightArrow))
					arm.Move(Direction.East);

				if (Input.GetKeyDown(KeyCode.RightAlt))
					arm.Retract();
			}
		}
	}
}
