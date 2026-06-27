using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [Header("Настройки кат-сцены")]
    [Tooltip("Сколько секунд длится полет камеры")]
    public float cutsceneDuration = 7.3f;

    [Tooltip("Номер сцены (Build Index), на которую нужно перейти")]
    public int nextSceneIndex = 2;

    void Start()
    {
        
        Invoke("LoadGame", cutsceneDuration);
    }

    void LoadGame()
    {
        
        SceneManager.LoadScene(2);
    }
}