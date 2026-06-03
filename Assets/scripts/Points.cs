using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private static int scoreValue = 0;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            scoreValue += 1;
            scoreText.text = "Score: " + scoreValue.ToString();
            Destroy(gameObject);
        }
    }

}
