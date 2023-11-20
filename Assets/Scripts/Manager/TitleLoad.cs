using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoad : MonoBehaviour
{
    public string titleGameSceneName = "Title"; // ���� ���� �� �̸�
    public string uiSceneName = "UIScene"; // UI �� �̸�

    void Start()
    {
        LoadScenes();
    }

    void LoadScenes()
    {
        // ���� ���� ���� Single ���� �ε��մϴ�.
        SceneManager.LoadScene(titleGameSceneName, LoadSceneMode.Single);

        // UI ���� Additive ���� �ε��մϴ�.
        SceneManager.LoadSceneAsync(uiSceneName, LoadSceneMode.Additive);
    }
}
