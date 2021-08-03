using UnityEngine;

public abstract class PlayerState
{
    public abstract PlayerState DoState(Player player);

    public bool UpdateTargetPosition(Player player)
    {
        if (player.DirectionInput == Vector2Int.zero)
            return false;

        var newTargetPosition = GetNewTargetPosition(player);

        if (HasCollision(player.TargetPosition, newTargetPosition))
            return false;

        player.TargetPosition = newTargetPosition;
        return true;
    }

    private Vector3 GetNewTargetPosition(Player player)
    {
        var newTargetPosition = player.TargetPosition + new Vector3(player.DirectionInput.x, 0, player.DirectionInput.y);
        var groundDistance = GetGroundDistance(newTargetPosition, player);

        if (player.maxInclineGradient + player.maxDeclineGradient > groundDistance && 0 < groundDistance)
            newTargetPosition.y += player.maxInclineGradient - groundDistance;

        return newTargetPosition;
    }

    private float GetGroundDistance(Vector3 newTargetPosition, Player player)
    {
        var start = newTargetPosition + new Vector3(0, player.maxInclineGradient - player.pivotToBottom, 0);
        var end = newTargetPosition + new Vector3(0, -20 - player.pivotToBottom, 0);
        Debug.DrawLine(start, end);
        Physics.Linecast(start, end, out RaycastHit groundHit);
        return Mathf.Round(groundHit.distance * 1000) / 1000;
    }

    private bool HasCollision(Vector3 start, Vector3 end)
    {
        Debug.DrawLine(start, end);
        return Physics.Linecast(start, end);
    }
}