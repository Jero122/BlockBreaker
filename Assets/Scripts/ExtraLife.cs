using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{

    private void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
