using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Events;

using Scene = UnityEngine.SceneManagement.Scene;
using SceneManager = UnityEngine.SceneManagement.SceneManager;


public class LevelLoader : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnLoadFinised;
    [HideInInspector] public UnityEvent OnUnloadFinised;

    [SerializeField] private int _startSceneIndex = 1;

    private List<int> _loadedScenes = new List<int>();

    private void Awake()
    {
        LoadSceneAdditive(_startSceneIndex);
    }

    public AsyncOperation LoadSceneAdditive(int scene)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

        if (_loadedScenes.Count != 0)
        {
            loadScene.completed += (a) => UnloadScene();
        }

        loadScene.completed += (a) => Resources.UnloadUnusedAssets();

        _loadedScenes.Add(scene);

        loadScene.completed += (a) => OnLoadFinised.Invoke();

        return loadScene;
    }

    private AsyncOperation UnloadScene()
    {
        AsyncOperation unloadScene = SceneManager.UnloadSceneAsync(_loadedScenes[0]);

        unloadScene.completed += (a) => OnUnloadFinised.Invoke();

        return unloadScene;
    }
}
