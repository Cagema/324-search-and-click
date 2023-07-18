using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector2 _borders;
    Vector2 _startPos;

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startPos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 dir = (Vector2)GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition) - _startPos;
                dir *= -1;
                Vector3 newPos = transform.position + dir;
                newPos = new Vector3(Mathf.Clamp(newPos.x, -_borders.x, _borders.x), Mathf.Clamp(newPos.y, -_borders.y, _borders.y), transform.position.z);
                transform.position = newPos;
            }
        }
    }
}
