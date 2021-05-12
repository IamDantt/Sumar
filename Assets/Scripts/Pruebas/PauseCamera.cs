using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PauseCamera : MonoBehaviour
{
    //public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        CameraDevice.Instance.Stop();
        offCamera();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void offCamera()
    {
        CameraDevice.Instance.Stop();
        //Panel.SetActive(true);
    } 

    public void OnCamera()
    {
        CameraDevice.Instance.Start();
        //Panel.SetActive(false);
    } 

}
