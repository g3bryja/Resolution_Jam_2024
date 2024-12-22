using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Singleton
    public static PlayerInput instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Player Input values
    private ButtonInput left;
    private ButtonInput right;

    private Vector2 directionalInput;
    public Vector2 DirectionalInput { get { return directionalInput; } }

    private void Start() {
        left = gameObject.AddComponent<ButtonInput>();
        right = gameObject.AddComponent<ButtonInput>();

        left.Key = "left";
        right.Key = "right";
    }

    private void Update() {
        setDirectionalInput();
    }

    private void setDirectionalInput() {
        if (left.isPressedThisFrame()) {
            directionalInput.x = -1;
        } else if (right.isPressedThisFrame()) {
            directionalInput.x = 1;
        } else if (left.isPressed() && !right.isPressed()) {
            directionalInput.x = -1;
        } else if (!left.isPressed() && right.isPressed()) {
            directionalInput.x = 1;
        } else {
            directionalInput.x = 0;
        }
    }
}
