using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    Light roomLight;

    // Start is called before the first frame update
    void Start()
    {
        roomLight = GetComponent<Light>();
        StartCoroutine(Blink());
    }

   

    IEnumerator Blink()
    {
        while(true)
        {
            roomLight.enabled = !roomLight.enabled;
            yield return new WaitForSeconds(Random.value);
        }
        

    }
}
