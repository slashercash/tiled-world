public class PlayerState_Idle : PlayerState
{
    public override PlayerState DoState(Player player)
    {
        bool targetPositionUpdated = UpdateTargetPosition(player);
        return targetPositionUpdated ? (PlayerState)player.walkState : player.idleState;
    }
}
