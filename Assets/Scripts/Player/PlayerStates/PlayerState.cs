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

        if (groundDistance < player.MaxGroundDistance && groundDistance > player.MinGroundDistance)
            newTargetPosition.y += player.EvenGroundDistance - groundDistance;

        return newTargetPosition;
    }

    private float GetGroundDistance(Vector3 newTargetPosition, Player player)
    {
        var start = newTargetPosition + new Vector3(0, player.pivotToTop, 0);
        var end = newTargetPosition + new Vector3(0, -20 - player.pivotToBottom, 0);
        Debug.DrawLine(start, end);
        Physics.Linecast(start, end, out RaycastHit groundHit);
        return Mathf.Round(groundHit.distance * player.PartialVerticalAccuracy) / player.PartialVerticalAccuracy;
    }

    private bool HasCollision(Vector3 start, Vector3 end)
    {
        Debug.DrawLine(start, end);
        return Physics.Linecast(start, end);
    }
}