using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingSound : MonoBehaviour
{
    [SerializeField] AudioClip restingSFX;

    public void RestSFX()
    {
        AudioSource.PlayClipAtPoint(restingSFX, Camera.main.transform.position, 10f);
    }
}
