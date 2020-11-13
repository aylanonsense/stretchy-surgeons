using UnityEngine.InputSystem;

namespace StretchySurgeons.Input {
	public class ArrowKeyControls : DeviceControls {
		protected override string controlScheme => "RightHalfOfDevice";

		public ArrowKeyControls(Keyboard keyboard) : base(keyboard) {}
	}
}
