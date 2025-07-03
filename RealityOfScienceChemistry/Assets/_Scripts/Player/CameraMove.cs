using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("KarakterOzellik")]
    public Transform Player;
    [Header("KameraOzellik")]
    public int Sensivty=200;
    public int UpHeight=60; //Ust Sinir
    public int DownHeight=60; //Alt Sinir

    private float xRotation; //Yukari-Assagi  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Mouse Sabitle
        Cursor.visible = false; //Mouse gizle
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X")*Sensivty*Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y")*Sensivty*Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -DownHeight, UpHeight); //Rotasyonu yavasca yap
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // oraya dondur
        Player.transform.Rotate(Vector3.up * MouseX);//Karakteri dondur
    }
}
