using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleCameraMovement : MonoBehaviour
{
    private InputAction _attack;
    [SerializeField, Range(0.01f, 1f)]
    private float _mouseSensitivity = 1f;


    Vector3 _moveDirection;
    [SerializeField, Range(0.01f, 10f)]
    float _moveSpeed = 1f;
    private void Start()
    {
        _attack = InputSystem.actions.FindAction("Attack");
    }

    /// <summary>
    /// Движение камеры
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();
        _moveDirection = new Vector3(temp.x, 0.0f, temp.y); 
    }

    /// <summary>
    /// Вращение камеры
    /// </summary>
    /// <param name="context"></param>
    public void OnLook(InputAction.CallbackContext context)
    {
        if (_attack.IsPressed())//Камера вращается только при нажатой кнопки "атаки" (по умолчанию: левая кнопка мыши)
        {
            Vector2 rotation = context.ReadValue<Vector2>() * _mouseSensitivity;
            transform.Rotate(new Vector3(-rotation.y, rotation.x, 0));
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * _moveSpeed);
    }
}
