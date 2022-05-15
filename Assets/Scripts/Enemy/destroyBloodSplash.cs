using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBloodSplash : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 2f);
    }
}
