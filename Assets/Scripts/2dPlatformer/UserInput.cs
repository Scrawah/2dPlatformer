using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private Player _target;

    private void Update()
    {
        var userInput = Input.GetAxis("Horizontal");

        _target.Movement(userInput);

        if (Input.GetKey(KeyCode.Space))
        {
            _target.Jump();
        }
    }
}
