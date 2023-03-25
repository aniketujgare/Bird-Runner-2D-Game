using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScalar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var height = Camera.main.orthographicSize * 2;
        var width = height * Screen.width/ Screen.height;

        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector3(width, height, 0);
            transform.localPosition = new Vector2(0,1.95f);
        }
        else
        {
            transform.localScale = new Vector3(width + 8f, 5, 0);
            transform.localPosition = new Vector3(0, -5.43f, -2);
        }
    }
}
