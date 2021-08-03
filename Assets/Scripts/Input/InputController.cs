using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject player;

    private InputActions inputactions;

    private void Awake()
    {
        Player playerClass = player.GetComponent<Player>();
        inputactions = new InputActions();
        inputactions.Play.Direction.performed += ctx =>
        {
            var input = Vector2Int.RoundToInt(ctx.ReadValue<Vector2>());
            if (input.x != 0)
                input.y = 0;
            playerClass.DirectionInput = input;
        };
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
