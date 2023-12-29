using Godot;

namespace Scripts;

public partial class PlayerCamera : PlayerComponent {
    [Export] private float verticalSensitivity = 1f, horizontalSensitivity = 1f;

    public override void _Ready() {
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _Input(InputEvent inputEvent) {
        if (inputEvent is InputEventMouseMotion motion) {
            var size = GetViewport().GetVisibleRect().Size;

            Player.Body.RotateY(-motion.Relative.X * horizontalSensitivity / size.X);
            Player.Camera.RotateX(motion.Relative.Y * verticalSensitivity / size.Y);
        }
    }
}