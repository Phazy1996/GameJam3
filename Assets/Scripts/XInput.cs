using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class XInput : MonoBehaviour {

    [SerializeField, Tooltip("What player am I?"), Range(1, 4)]
    int playerNo;
    PlayerIndex playerIndex;

    // To have button press on frame.
    GamePadState current;
    GamePadState last;

    // Only true this frame.
    bool xButtonDown, bButtonDown, yButtonDown, aButtonDown = false;
    bool startButtonDown, backButtonDown = false;
    bool leftstickDown, rightStickDown = false;

    // True when button is down.
    bool xButton, bButton, yButton, aButton = false;
    bool startButton, backButton = false;
    bool leftstick, rightStick = false;

    Vector2 leftStick, rightStick;



    void Start() {
        switch (playerNo) {
            case 1:
                playerIndex = PlayerIndex.One;
                break;
            case 2:
                playerIndex = PlayerIndex.Two;
                break;
            case 3:
                playerIndex = PlayerIndex.Three;
                break;
            case 4:
                playerIndex = PlayerIndex.Four;
                break;
            default:
                Debug.LogError(this.name + " was not given a player number and therefore cannot continue!");
                gameObject.name = "!--" + gameObject.name + "--!";
                gameObject.SetActive(false);
                break;
        }

        current = GamePad.GetState(playerIndex);
    }

    void Update() {

    }

    void PressedThisFrame() {

    }
}
