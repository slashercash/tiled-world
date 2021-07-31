using UnityEngine;

public class WalkState : IPlayerState
{
    public IPlayerState DoState(Player player)
    {
        float speed = 3.0f * Time.deltaTime;
        player.transform.Translate(player.inputMove.x * speed, player.inputMove.y * speed, 0f);

        return player.inputMove == Vector2.zero ? (IPlayerState)player.idleState : player.walkState;
    }
}