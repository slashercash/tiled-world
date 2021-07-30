using UnityEngine;

public class CubeController : MonoBehaviour
{
    private InputController inputController;
    private Vector2 inputMove;

    private void Awake()
    {
        inputController = new InputController();
        inputController.Play.Move.performed += ctx => inputMove = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        float speed = 3.0f * Time.deltaTime;
        transform.Translate(inputMove.x * speed, inputMove.y * speed, 0f);
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }
}
