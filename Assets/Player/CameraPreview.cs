using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPreview : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject previewCam;

    void Start()
    {
        StartCoroutine(Preview());
    }

    IEnumerator Preview() 
    {
        yield return new WaitForSeconds(5);
        mainCam.SetActive(true);
        previewCam.SetActive(false);
    }
}
