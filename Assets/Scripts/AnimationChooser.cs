using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimationChooser : MonoBehaviour
{
    private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnNeitral(InputAction.CallbackContext context)
    {
        AnimationStart(context, "Neitral");
    }

    public void OnApplaud(InputAction.CallbackContext context)
    {
        AnimationStart(context, "Applaud");
    }

    public void OnYoga(InputAction.CallbackContext context)
    {
        AnimationStart(context, "Yoga");
    }


    /// <summary>
    /// Метод вызывает срабатывание триггера аниматора по задонному имени, что приводит к запуску нужной анимации, и перемещает камеру к объекту.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="triggerName"></param>
    private void AnimationStart(InputAction.CallbackContext context, string triggerName)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Camera.main.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 2), new Quaternion(0, 1, 0, 0));
            _animator.SetTrigger(triggerName);
        }
    }

}
