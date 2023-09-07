using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    float delay = 0f;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ruby"))
        {
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
