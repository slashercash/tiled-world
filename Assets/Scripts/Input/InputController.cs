using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject player;
    private InputActions inputactions;
    private Vector2 inputMove;

    private void Awake()
    {
        inputactions = new InputActions();
        inputactions.Play.Move.performed += ctx => inputMove = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        float speed = 3.0f * Time.deltaTime;
        player.transform.Translate(inputMove.x * speed, inputMove.y * speed, 0f);
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
