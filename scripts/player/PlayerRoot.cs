using Godot;

namespace Scripts;

public partial class PlayerRoot : Node {
    [Export]
    private CharacterBody3D body;

    [Export]
    private Camera3D camera;

    public CharacterBody3D Body => body;
    public Camera3D Camera => camera;
}
