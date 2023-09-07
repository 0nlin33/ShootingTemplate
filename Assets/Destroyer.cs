using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    float delay = .5f;


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Base"))
        {
            StartCoroutine(WaitAndDestroy());
        }
    }

    public IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
