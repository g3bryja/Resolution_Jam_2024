using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    private string key;

    public string Key {
        get { return key; }
        set { key = value; }
    }

    public bool isPressedThisFrame() {
        return Input.GetKeyDown(key);
    }

    public bool isPressed() {
        return Input.GetKey(key);
    }

    public bool isReleasedThisFrame() {
        return Input.GetKeyUp(key);
    }
}
