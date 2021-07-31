using UnityEngine;

public class WalkState : IPlayerState
{
    public IPlayerState DoState(Player player)
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, player.TargetPosition, Time.deltaTime * player.speed);
        return player.transform.position == player.TargetPosition ? (IPlayerState)player.idleState : player.walkState;
    }
}