using Godot;

namespace Scripts;

public partial class PlayerMovement : PlayerComponent {
    [ExportCategory("Parameters")] [Export]
    private float walkSpeed = 1f;

    public override void _Process(double delta) {
        var inputDirection = GetInputDirection();

        inputDirection *= GetSpeed();

        MoveBody(inputDirection);
    }

    private Vector2 GetInputDirection() =>
        new Vector2(
            Input.GetActionStrength("Left")
            - Input.GetActionStrength("Right"),
            Input.GetActionStrength("Forward")
            - Input.GetActionStrength("Back")
        ).LimitLength();

    private float GetSpeed() => walkSpeed;

    private void MoveBody(Vector2 inputDirection) {
        Player.Body.Velocity = new Vector3(
            inputDirection.X,
            0,
            inputDirection.Y
        ).Rotated(Vector3.Up, Player.Body.GlobalRotation.Y);

        Player.Body.MoveAndSlide();
    }
}
