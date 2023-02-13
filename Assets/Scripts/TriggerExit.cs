using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    public static TriggerExit instance;

    [HideInInspector]
    public UserInput currentCollider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        currentCollider.OnExit.Invoke();
    }
}
