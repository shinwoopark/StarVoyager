using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _moveInput;

    public float MoveSpeed;

    private bool _bhitFront, _bhitBack, _bhitLeft, _bhitRight;

    private void Update()
    {
        UpdateInput();
    }

    private void FixedUpdate()
    {
        UpdateMove();
    }

    private void UpdateInput()
    {
        if (Input.GetKey(KeyCode.UpArrow)
            && !Input.GetKey(KeyCode.DownArrow)
            && !_bhitFront)
        {
            _moveInput.y = 1;

        }
        else if (!Input.GetKey(KeyCode.UpArrow)
            && Input.GetKey(KeyCode.DownArrow)
            && !_bhitBack)
        {
            _moveInput.y = -1;
        }
        else
        {
            _moveInput.y = 0;
        }

        if (!Input.GetKey(KeyCode.RightArrow)
            && Input.GetKey(KeyCode.LeftArrow)
            && !_bhitLeft)
        {
            _moveInput.x = -1;
        }
        else if (!Input.GetKey(KeyCode.LeftArrow)
            && Input.GetKey(KeyCode.RightArrow)
            && !_bhitRight)
        {
            _moveInput.x = 1;
        }
        else
        {
            _moveInput.x = 0;
        }
    }

    private void UpdateMove()
    {
        transform.position += new Vector3(_moveInput.x, _moveInput.y, 0) * GameInstance.instance.PlayerMoveSpeed * Time.deltaTime;

        Quaternion dir = Quaternion.identity;
        float rotationSpeed = 0;

        if (_moveInput.x > 0)
        {            
            dir = Quaternion.Euler(0, -30, 0);
            rotationSpeed = 2;
        }
        else if (_moveInput.x < 0)
        {
            dir = Quaternion.Euler(0, 30, 0);
            rotationSpeed = 2;
        }
        else if (_moveInput.x == 0)
        {
            dir = Quaternion.Euler(0, 0, 0);
            rotationSpeed = 3;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, dir, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            switch (other.gameObject.name)
            {
                case "Front":
                    _bhitFront = true;
                    break;
                case "Back":
                    _bhitBack = true;
                    break;
                case "Left":
                    _bhitLeft = true;
                    break;
                case "Right":
                    _bhitRight = true;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            switch (other.gameObject.name)
            {
                case "Front":
                    _bhitFront = false;
                    break;
                case "Back":
                    _bhitBack = false;
                    break;
                case "Left":
                    _bhitLeft = false;
                    break;
                case "Right":
                    _bhitRight = false;
                    break;
            }
        }
    }
}
