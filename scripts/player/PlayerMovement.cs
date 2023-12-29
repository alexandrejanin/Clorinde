using Godot;

namespace Scripts;

public partial class PlayerMovement : PlayerComponent {
    [ExportCategory("Running")] [Export] private float walkSpeed = 5f, runSpeed = 7f;

    [ExportCategory("Jumping")] [Export] private float jumpForce = 10f, gravityForce = -10f;

    public override void _PhysicsProcess(double delta) {
        var input = GetInput();

        ProcessVelocity(input, delta);
    }

    private void ProcessVelocity(Vector2 input, double delta) {
        var inputVelocity = GetSpeed() * new Vector3(input.X, 0, input.Y)
            .Rotated(Vector3.Up, Player.Body.GlobalRotation.Y);

        Player.Body.Velocity = new Vector3(inputVelocity.X, Player.Body.Velocity.Y, inputVelocity.Z);

        ProcessGravity(delta);

        ProcessJump();

        Player.Body.MoveAndSlide();
    }

    private void ProcessGravity(double delta) {
        if (!Player.Body.IsOnFloor()) {
            Player.Body.Velocity += Vector3.Up * (float)(gravityForce * delta);
        }
    }

    private void ProcessJump() {
        if (Input.IsActionPressed("Jump") && Player.Body.Velocity.Y <= 0 && Player.Body.IsOnFloor() ) {
            Player.Body.Velocity += Vector3.Up * jumpForce;
        }
    }

    private float GetSpeed() => walkSpeed + Input.GetActionStrength("Run") * (runSpeed - walkSpeed);

    private Vector2 GetInput() =>
        new Vector2(
            Input.GetActionStrength("Left")
            - Input.GetActionStrength("Right"),
            Input.GetActionStrength("Forward")
            - Input.GetActionStrength("Back")
        ).LimitLength();
}