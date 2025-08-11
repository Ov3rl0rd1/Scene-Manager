using UnityEngine;
using UnityEngine.Events;

public abstract class BaseSceneTrigger : MonoBehaviour
{
    [HideInInspector] public UnityEvent onInteract;
}
