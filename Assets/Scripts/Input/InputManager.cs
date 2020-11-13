using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace StretchySurgeons.Input {
	public class InputManager
	{
		public List<PlayerControls> players;
		public List<DeviceControls> devices;
		public PlayerControls player1 => players[0];
		public PlayerControls player2 => players[1];

		public InputManager() {
			players = new List<PlayerControls>() {
				new PlayerControls(),
				new PlayerControls()
			};
			devices = new List<DeviceControls>();
			InputUser.listenForUnpairedDeviceActivity++;
			InputUser.onUnpairedDeviceUsed += (control, eventPtr) => {
				AddInputDevice(control.device);
			};
			InputSystem.onDeviceChange += (device, change) => {
				switch (change) {
					case InputDeviceChange.Removed:
						RemoveInputDevice(device);
						break;
					case InputDeviceChange.Reconnected:
						AddInputDevice(device);
						break;
				}
			};
		}

		public void Update() {
			foreach (var device in devices)
				device.Update();
			foreach (var player in players)
				player.Update();
		}

		public PlayerControls GetPlayerControls(PlayerNum playerNum) {
			switch (playerNum) {
				case PlayerNum.Player1:
					return player1;
				case PlayerNum.Player2:
					return player2;
				default:
					return null;
			}
		}

		private void AddInputDevice(InputDevice device) {
			if (device is Keyboard keyboard) {
				Debug.Log($"Keyboard \"{ keyboard }\" detected, assigning WASD to player 1 and arrow keys to player 2");
				AddDevice(new WASDControls(keyboard), player1);
				AddDevice(new ArrowKeyControls(keyboard), player2);
			}
			else if (device is Gamepad gamepad) {
				Debug.Log($"Gamepad \"{ gamepad }\" detected, assigning to player { (player1.GetNumDevices() > player2.GetNumDevices()  ? "2" : "1") }");
				AddDevice(new GamepadControls(gamepad), player1.GetNumDevices() > player2.GetNumDevices() ? player2 : player1);
			}
		}

		private void AddDevice(DeviceControls device, PlayerControls player) {
			devices.Add(device);
			player.AddDevice(device);
		}

		private void RemoveInputDevice(InputDevice device) {
			if (device is Keyboard keyboard)
				Debug.Log($"Keyboard \"{ keyboard }\" removed");
			else if (device is Gamepad gamepad)
				Debug.Log($"Gamepad \"{ gamepad }\" removed");
			for (var i = devices.Count - 1; i >= 0; i--) {
				if (devices[i].IsUsingInputDevice(device)) {
					foreach (var player in players)
						player.RemoveDevice(devices[i]);
					devices[i].Destroy();
					devices.RemoveAt(i);
				}
			}
		}
	}
}
