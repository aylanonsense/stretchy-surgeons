using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using StretchySurgeons.Input.Actions;

namespace StretchySurgeons.Input {
	public class PlayerControls : Controls
	{
		public new Action<Direction> OnPressedDirection;
		public new Action<Direction> OnReleasedDirection;

		private List<DeviceControls> devices;

		public PlayerControls() {
			devices = new List<DeviceControls>();
		}

		public override void Update() {}

		public void AddDevice(DeviceControls device) {
			devices.Add(device);
			BindListeners(device);
		}

		public void RemoveDevice(DeviceControls device) {
			if (devices.Remove(device))
				UnbindListeners(device);
		}

		public int GetNumDevices() {
			return devices.Count;
		}

		public override void Destroy() {
			foreach (var device in devices)
				UnbindListeners(device);
		}

		private void BindListeners(DeviceControls device) {
			device.OnPressedDirection += HandlePressedDirection;
			device.OnReleasedDirection += HandleReleasedDirection;
			device.OnPressedActivate += HandlePressedActivate;
			device.OnReleasedActivate += HandleReleasedActivate;
			device.OnPressedCancel += HandlePressedCancel;
			device.OnReleasedCancel += HandleReleasedCancel;
		}

		private void UnbindListeners(DeviceControls device) {
			device.OnPressedDirection -= HandlePressedDirection;
			device.OnReleasedDirection -= HandleReleasedDirection;
			device.OnPressedActivate -= HandlePressedActivate;
			device.OnReleasedActivate -= HandleReleasedActivate;
			device.OnPressedCancel -= HandlePressedCancel;
			device.OnReleasedCancel -= HandleReleasedCancel;
		}

		private void HandlePressedDirection(Direction direction) {
			OnPressedDirection?.Invoke(direction);
		}

		private void HandleReleasedDirection(Direction direction) {
			OnReleasedDirection?.Invoke(direction);
		}

		private void HandlePressedActivate() {
			OnPressedActivate?.Invoke();
		}

		private void HandleReleasedActivate() {
			OnReleasedActivate?.Invoke();
		}

		private void HandlePressedCancel() {
			OnPressedCancel?.Invoke();
		}

		private void HandleReleasedCancel() {
			OnReleasedCancel?.Invoke();
		}

		public override bool JustPressedDirection(Direction direction) {
			foreach (var device in devices)
				if (device.JustPressedDirection(direction))
					return true;
			return false;
		}

		public override bool JustReleasedDirection(Direction direction) {
			foreach (var device in devices)
				if (device.JustReleasedDirection(direction))
					return true;
			return false;
		}

		public override bool IsHoldingDirection(Direction direction) {
			foreach (var device in devices)
				if (device.IsHoldingDirection(direction))
					return true;
			return false;
		}

		public override bool JustPressedActivate() {
			foreach (var device in devices)
				if (device.JustPressedActivate())
					return true;
			return false;
		}

		public override bool JustReleasedActivate() {
			foreach (var device in devices)
				if (device.JustReleasedActivate())
					return true;
			return false;
		}

		public override bool IsHoldingActivate() {
			foreach (var device in devices)
				if (device.IsHoldingActivate())
					return true;
			return false;
		}

		public override bool JustPressedCancel() {
			foreach (var device in devices)
				if (device.JustPressedCancel())
					return true;
			return false;
		}

		public override bool JustReleasedCancel() {
			foreach (var device in devices)
				if (device.JustReleasedCancel())
					return true;
			return false;
		}

		public override bool IsHoldingCancel() {
			foreach (var device in devices)
				if (device.IsHoldingCancel())
					return true;
			return false;
		}

		public override Direction GetHeldDirection() {
			Direction heldDirection = Direction.None;
			float heldDuration = 0f;
			foreach (var device in devices) {
				Direction direction = device.GetHeldDirection();
				float duration = device.GetHeldDirectionDuration(direction);
				if (duration > heldDuration) {
					heldDirection = direction;
					heldDuration = duration;
				}
			}
			return heldDirection;
		}

		public override float GetHeldDirectionDuration(Direction direction) {
			float duration = 0f;
			foreach (var device in devices)
				duration = Mathf.Max(duration, device.GetHeldDirectionDuration(direction));
			return duration;
		}
	}
}
