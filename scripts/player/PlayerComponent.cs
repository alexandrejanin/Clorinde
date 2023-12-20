using Godot;

namespace Scripts;

public abstract partial class PlayerComponent : Node {
    protected PlayerRoot Player { get; private set; }

    public override void _EnterTree() {
        Player = GetParent<PlayerRoot>();
    }
}
