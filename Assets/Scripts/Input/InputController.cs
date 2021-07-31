using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject player;

    private InputActions inputactions;
    private Vector2 inputMove;

    private void Awake()
    {
        Player playerClass = player.GetComponent<Player>();
        inputactions = new InputActions();
        inputactions.Play.Move.performed += ctx => playerClass.inputMove = ctx.ReadValue<Vector2>();
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
