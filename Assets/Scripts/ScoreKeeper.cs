using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public float score = 0;
    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject win;


    // Start is called before the first frame update
    public void Score()
    {
        score = score + 0.5f;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void Win()
    {
        if (score >= 50)
        {
            win.gameObject.SetActive(true);
        }
        
    }

}
