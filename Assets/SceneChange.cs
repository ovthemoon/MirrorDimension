using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public string sceneName;
    
    private void OnMouseDown()
    {
        LoadingSceneManager.LoadScene(sceneName);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadingSceneManager.LoadScene(sceneName);
        }
    }

}
