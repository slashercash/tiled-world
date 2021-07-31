using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject player;

    private InputActions inputactions;

    private void Awake()
    {
        Player playerClass = player.GetComponent<Player>();
        inputactions = new InputActions();
        inputactions.Play.Direction.performed += ctx => playerClass.DirectionInput = Vector2Int.RoundToInt(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        inputactions.Enable();
    }

    private void OnDisable()
    {
        inputactions.Disable();
    }
}
