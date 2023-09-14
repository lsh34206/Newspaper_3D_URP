using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 turn;
    [SerializeField] private float sensitivity = .5f;

    enum CameraPosition
    {
        Couch,
        Table,
        Bookshelf
    }

    private CameraPosition _state = CameraPosition.Couch;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        switch (_state)
        {
            case CameraPosition.Couch:
                RotateCamera();
                break;
            
            case CameraPosition.Table:
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case CameraPosition.Bookshelf:
                Cursor.lockState = CursorLockMode.Confined;
                break;
        }
    }

    private void RotateCamera()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
