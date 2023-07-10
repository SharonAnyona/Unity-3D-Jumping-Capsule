using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemCollector2 : MonoBehaviour
{
    int score = 0;
     [SerializeField] TMPro.TextMeshProUGUI coinsText;
    

    //[SerializeField] AudioSource collectionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            score+=3;
            coinsText.text = "Score: " + score;
            //collectionSound.Play();
        }
    }
}