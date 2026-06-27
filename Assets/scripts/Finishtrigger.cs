using UnityEngine;

public class Finishtrigger : MonoBehaviour
{
    public GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }

        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible =
            true;

        Time.timeScale = 0f;

        Debug.Log("WIN");
    }
}