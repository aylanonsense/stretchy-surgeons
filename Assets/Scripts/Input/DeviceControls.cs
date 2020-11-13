using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using StretchySurgeons.Input.Actions;

namespace StretchySurgeons.Input {
	public abstract class DeviceControls : Controls {
		private InputDevice device;
		private InputUser user;
		private PlayerInputActions actions;
		protected virtual string controlScheme { get; }
		private Dictionary<Direction, bool> justPressedDirection;
		private Dictionary<Direction, bool> justReleasedDirection;
		private Dictionary<Direction, float> isHoldingDirection;
		private bool justPressedActivate;
		private bool justReleasedActivate;
		private bool isHoldingActivate;
		private bool justPressedCancel;
		private bool justReleasedCancel;
		private bool isHoldingCancel;

		public DeviceControls(InputDevice device) {
			justPressedDirection = new Dictionary<Direction, bool>();
			justReleasedDirection = new Dictionary<Direction, bool>();
			isHoldingDirection = new Dictionary<Direction, float>();
			justPressedActivate = false;
			justReleasedActivate = false;
			isHoldingActivate = false;
			justPressedCancel = false;
			justReleasedCancel = false;
			isHoldingCancel = false;
			foreach (var direction in DirectionUtils.allDirections) {
				justPressedDirection[direction] = false;
				justReleasedDirection[direction] = false;
				isHoldingDirection[direction] = -1f;
			}
			this.device = device;
			InputUser user = InputUser.PerformPairingWithDevice(device);
			actions = new PlayerInputActions();
			actions.Enable();
			user.AssociateActionsWithUser(actions);
			if (controlScheme != null)
				user.ActivateControlScheme(controlScheme);
			BindListeners();
		}

		public override void Update() {
			foreach (var direction in DirectionUtils.allDirections) {
				justPressedDirection[direction] = false;
				justReleasedDirection[direction] = false;
				if (isHoldingDirection[direction] > 0f)
					isHoldingDirection[direction] += Time.deltaTime;
			}
			justPressedActivate = false;
			justReleasedActivate = false;
			justPressedCancel = false;
			justReleasedCancel = false;
		}

		public override void Destroy() {
			UnbindListeners();
		}

		private void BindListeners() {
			actions.Default.North.started += HandlePressedNorth;
			actions.Default.East.started += HandlePressedEast;
			actions.Default.South.started += HandlePressedSouth;
			actions.Default.West.started += HandlePressedWest;
			actions.Default.Activate.started += HandlePressedActivate;
			actions.Default.Cancel.started += HandlePressedCancel;
			actions.Default.North.canceled += HandleReleasedNorth;
			actions.Default.East.canceled += HandleReleasedEast;
			actions.Default.South.canceled += HandleReleasedSouth;
			actions.Default.West.canceled += HandleReleasedWest;
			actions.Default.Activate.canceled += HandleReleasedActivate;
			actions.Default.Cancel.canceled += HandleReleasedCancel;
		}

		private void UnbindListeners() {
			actions.Default.North.started -= HandlePressedNorth;
			actions.Default.East.started -= HandlePressedEast;
			actions.Default.South.started -= HandlePressedSouth;
			actions.Default.West.started -= HandlePressedWest;
			actions.Default.Activate.started -= HandlePressedActivate;
			actions.Default.Cancel.started -= HandlePressedCancel;
			actions.Default.North.canceled -= HandleReleasedNorth;
			actions.Default.East.canceled -= HandleReleasedEast;
			actions.Default.South.canceled -= HandleReleasedSouth;
			actions.Default.West.canceled -= HandleReleasedWest;
			actions.Default.Activate.canceled -= HandleReleasedActivate;
			actions.Default.Cancel.canceled -= HandleReleasedCancel;
		}

		private void HandlePressedNorth(InputAction.CallbackContext ctx) {
			HandlePressedDirection(Direction.North);
		}

		private void HandlePressedEast(InputAction.CallbackContext ctx) {
			HandlePressedDirection(Direction.East);
		}

		private void HandlePressedSouth(InputAction.CallbackContext ctx) {
			HandlePressedDirection(Direction.South);
		}

		private void HandlePressedWest(InputAction.CallbackContext ctx) {
			HandlePressedDirection(Direction.West);
		}

		private void HandleReleasedNorth(InputAction.CallbackContext ctx) {
			HandleReleasedDirection(Direction.North);
		}

		private void HandleReleasedEast(InputAction.CallbackContext ctx) {
			HandleReleasedDirection(Direction.East);
		}

		private void HandleReleasedSouth(InputAction.CallbackContext ctx) {
			HandleReleasedDirection(Direction.South);
		}

		private void HandleReleasedWest(InputAction.CallbackContext ctx) {
			HandleReleasedDirection(Direction.West);
		}

		private void HandlePressedDirection(Direction direction) {
			justPressedDirection[direction] = true;
			isHoldingDirection[direction] = 0.05f;
			OnPressedDirection?.Invoke(direction);
		}

		private void HandleReleasedDirection(Direction direction) {
			justReleasedDirection[direction] = true;
			isHoldingDirection[direction] = -1f;
			OnReleasedDirection?.Invoke(direction);
		}

		private void HandlePressedActivate(InputAction.CallbackContext ctx) {
			justPressedActivate = true;
			isHoldingActivate = true;
			OnPressedActivate?.Invoke();
		}

		private void HandleReleasedActivate(InputAction.CallbackContext ctx) {
			justReleasedActivate = true;
			isHoldingActivate = false;
			OnReleasedActivate?.Invoke();
		}

		private void HandlePressedCancel(InputAction.CallbackContext ctx) {
			justPressedCancel = true;
			isHoldingCancel = true;
			OnPressedCancel?.Invoke();
		}

		private void HandleReleasedCancel(InputAction.CallbackContext ctx) {
			justReleasedCancel = true;
			isHoldingCancel = false;
			OnReleasedCancel?.Invoke();
		}

		public override bool JustPressedDirection(Direction direction) {
			return direction != Direction.None && justPressedDirection[direction];
		}

		public override bool JustReleasedDirection(Direction direction) {
			return direction != Direction.None && justReleasedDirection[direction];
		}

		public override bool IsHoldingDirection(Direction direction) {
			return direction != Direction.None && isHoldingDirection[direction] > 0f;
		}

		public override Direction GetHeldDirection() {
			Direction heldDirection = Direction.None;
			float duration = -1f;
			foreach (var direction in DirectionUtils.allDirections) {
				if (isHoldingDirection[direction] > 0f && (duration < 0f || isHoldingDirection[direction] < duration)) {
					heldDirection = direction;
					duration = isHoldingDirection[direction];
				}
			}
			return heldDirection;
		}

		public override float GetHeldDirectionDuration(Direction direction) {
			return (direction != Direction.None && isHoldingDirection[direction] > 0f) ? isHoldingDirection[direction] : 0f;
		}

		public override bool JustPressedActivate() {
			return justPressedActivate;
		}

		public override bool JustReleasedActivate() {
			return justReleasedActivate;
		}

		public override bool IsHoldingActivate() {
			return isHoldingActivate;
		}

		public override bool JustPressedCancel() {
			return justPressedCancel;
		}

		public override bool JustReleasedCancel() {
			return justReleasedCancel;
		}

		public override bool IsHoldingCancel() {
			return isHoldingCancel;
		}

		public bool IsUsingInputDevice(InputDevice device) {
			return this.device == device;
		}
	}
}
