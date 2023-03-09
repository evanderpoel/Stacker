using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOffScreen : MonoBehaviour
{
    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
