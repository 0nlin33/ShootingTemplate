using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCrystal : MonoBehaviour
{
    float delay = 0f;

    /*[SerializeField] private ScoreKeeper scoreKeeper;*/


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Light"))
        {
            /*scoreKeeper.Score();*/
            StartCoroutine(WaitAndDestroy());
        }
    }

    public IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
        ScoreKeeper SK = FindObjectOfType<ScoreKeeper>();
        SK = SK.GetComponent<ScoreKeeper>();
        SK.Score();
    }
}
