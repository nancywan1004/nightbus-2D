using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalInteractionUIManager : MonoBehaviour
{

    [SerializeField] private Button _secondDaySceneSwitchButton;

    private const string SECOND_DAY_SCENE_NAME = "SecondDay(InRoom)";
    private void Awake()
    {
        DontDestroyOnLoad(this);
        SetupUIBindings();
    }

    private void SetupUIBindings()
    {
        _secondDaySceneSwitchButton.onClick.AddListener(LoadSecondDayScene);
    }

    private void LoadSecondDayScene()
    {
        SceneManager.LoadSceneAsync(SECOND_DAY_SCENE_NAME, LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (string.Equals(scene.name, SECOND_DAY_SCENE_NAME))
        {
            _secondDaySceneSwitchButton.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
