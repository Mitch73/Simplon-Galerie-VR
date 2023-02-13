using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{

    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    public void OnTriggerEnter(Collider other)
    {
        TriggerExit.instance.currentCollider = GetComponent<UserInput>();
        OnEnter.Invoke();
    }
}
