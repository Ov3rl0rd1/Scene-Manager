using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class BottleNeckSceneLoader : MonoBehaviour
{
    [SerializeField] private BaseSceneTrigger _startTrigger;
    [SerializeField] private int _targetSceneIndex;

    [SerializeField] private UnityEvent onStart;
    [SerializeField] private UnityEvent onSceneLoaded;

    [Inject] private LevelLoader _levelLoader;

    private void OnEnable()
    {
        _startTrigger.onInteract.AddListener(StartLevelLoading);
    }

    private void OnDisable()
    {
        _startTrigger.onInteract.RemoveListener(StartLevelLoading);
    }

    private void StartLevelLoading()
    { 
        onStart.Invoke();

        _levelLoader.LoadSceneAdditive(_targetSceneIndex);

        _levelLoader.OnLoadFinised.AddListener(OnSceneLoaded);
    }

    private void OnSceneLoaded()
    { 
        onSceneLoaded.Invoke();
        _levelLoader.OnLoadFinised.RemoveListener(OnSceneLoaded);
    }
}
