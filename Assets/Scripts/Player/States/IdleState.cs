using UnityEngine;

public class IdleState : IPlayerState
{
    public IPlayerState DoState(Player player)
    {
        return player.inputMove == Vector2.zero ? (IPlayerState)player.idleState : player.walkState;
    }
}
