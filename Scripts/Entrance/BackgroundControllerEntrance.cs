using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundControllerEntrance : MonoBehaviour
{
    [SerializeField] Image backgroundImage;
    [SerializeField] Sprite[] backgrounds;

    private void Start()
    {
        RandomBackground();
    }

    public void RandomBackground()
    {
        int indis = Random.Range(0, 3);

        backgroundImage.sprite = backgrounds[indis];
    }
}
