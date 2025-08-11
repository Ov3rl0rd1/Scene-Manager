using UnityEngine;

public class PlayerTrigger : BaseSceneTrigger
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            onInteract.Invoke();
        }
    }
}
