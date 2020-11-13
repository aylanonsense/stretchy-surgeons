using UnityEngine.InputSystem;

namespace StretchySurgeons.Input {
	public class WASDControls : DeviceControls {
		protected override string controlScheme => "LeftHalfOfDevice";

		public WASDControls(Keyboard keyboard) : base(keyboard) {}
	}
}
