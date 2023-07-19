using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector2 _borders;
    [SerializeField] float _errDist;
    Vector2 _startPos;
    Vector3 _newPos;
    Vector2 _startBorders;
    public Vector2 Borders
    {
        get { return _startBorders; }
    }
    private void Start()
    {
        _startBorders = _borders;
        _borders = new Vector2(_borders.x - GameManager.Single.RightUpperCorner.x, _borders.y - GameManager.Single.RightUpperCorner.y);
    }
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
                if (dir.sqrMagnitude > _errDist)
                {
                    dir *= -1;
                    _newPos = transform.position + dir;
                    _newPos = new Vector3(Mathf.Clamp(_newPos.x, -_borders.x, _borders.x), Mathf.Clamp(_newPos.y, -_borders.y, _borders.y), transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, _newPos, Time.deltaTime * _speed);
                }
            }
        }
    }
}
