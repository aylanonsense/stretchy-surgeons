using System;

namespace StretchySurgeons.Input {
	public abstract class Controls {
		public Action<Direction> OnPressedDirection;
		public Action<Direction> OnReleasedDirection;
		public Action OnPressedActivate;
		public Action OnReleasedActivate;
		public Action OnPressedCancel;
		public Action OnReleasedCancel;

		public virtual void Update() {}

		public virtual void Destroy() {}

		public abstract bool JustPressedDirection(Direction direction);

		public abstract bool JustReleasedDirection(Direction direction);

		public abstract bool IsHoldingDirection(Direction direction);

		public abstract Direction GetHeldDirection();

		public float GetHeldDirectionDuration() {
			return GetHeldDirectionDuration(GetHeldDirection());
		}

		public abstract float GetHeldDirectionDuration(Direction direction);

		public abstract bool JustPressedActivate();

		public abstract bool JustReleasedActivate();

		public abstract bool IsHoldingActivate();

		public abstract bool JustPressedCancel();

		public abstract bool JustReleasedCancel();

		public abstract bool IsHoldingCancel();
	}
}
