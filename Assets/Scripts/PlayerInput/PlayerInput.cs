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
    private ButtonInput up;
    private ButtonInput down;

    private Vector2 directionalInput;
    public Vector2 DirectionalInput { get { return directionalInput; } }

    private void Start() {
        left = gameObject.AddComponent<ButtonInput>();
        right = gameObject.AddComponent<ButtonInput>();
        up = gameObject.AddComponent<ButtonInput>();
        down = gameObject.AddComponent<ButtonInput>();

        left.Key = "left";
        right.Key = "right";
        up.Key = "up";
        down.Key = "down";
    }

    private void Update() {
        setDirectionalInput();
    }

    private void setDirectionalInput() {
        // Horizontal
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

        // Vertical
        if (up.isPressedThisFrame()) {
            directionalInput.y = 1;
        } else if (down.isPressedThisFrame()) {
            directionalInput.y = -1;
        } else if (up.isPressed() && !down.isPressed()) {
            directionalInput.y = 1;
        } else if (!up.isPressed() && down.isPressed()) {
            directionalInput.y = -1;
        } else {
            directionalInput.y = 0;
        }
    }
}
