using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class XInput : MonoBehaviour {

    [SerializeField, Tooltip("What player am I?"), Range(1, 4)]
    int playerNo = 1;
    PlayerIndex playerIndex;

    // To have button press on frame.
    GamePadState currentState;
    GamePadState lastState;

    // Only true this frame.
    bool xButtonDown, bButtonDown, yButtonDown, aButtonDown = false;
    bool startButtonDown, backButtonDown = false;
    bool leftstickDown, rightStickDown = false;

    // True when button is down.
    bool xButton, bButton, yButton, aButton = false;
    bool startButton, backButton = false;
    bool leftstick, rightStick = false;

    // Their horizontal and vertical.
    // Value between -1 and 1.
    Vector2 leftStickPos, rightStickPos;

    [SerializeField, Range(0,1)]
    float Vibration = 0;

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

        currentState = GamePad.GetState(playerIndex);
    }

    void Update() {
        PressedThisFrame();
    }

    void PressedThisFrame() {
        xButtonDown = lastState.Buttons.X == ButtonState.Released && currentState.Buttons.X == ButtonState.Pressed;
        bButtonDown = lastState.Buttons.B == ButtonState.Released && currentState.Buttons.B == ButtonState.Pressed;
        yButtonDown = lastState.Buttons.Y == ButtonState.Released && currentState.Buttons.Y == ButtonState.Pressed;
        aButtonDown = lastState.Buttons.A == ButtonState.Released && currentState.Buttons.A == ButtonState.Pressed;
        startButtonDown = lastState.Buttons.Start == ButtonState.Released && currentState.Buttons.Start == ButtonState.Pressed;
        backButtonDown = lastState.Buttons.Back == ButtonState.Released && currentState.Buttons.Back == ButtonState.Pressed;
        leftstickDown = lastState.Buttons.LeftStick == ButtonState.Released && currentState.Buttons.LeftStick == ButtonState.Pressed;
        rightStickDown = lastState.Buttons.RightStick == ButtonState.Released && currentState.Buttons.RightStick == ButtonState.Pressed;

        xButtonDown = !(lastState.Buttons.X == ButtonState.Pressed && currentState.Buttons.X == ButtonState.Released);
        bButtonDown = !(lastState.Buttons.B == ButtonState.Pressed && currentState.Buttons.B == ButtonState.Released);
        yButtonDown = !(lastState.Buttons.Y == ButtonState.Pressed && currentState.Buttons.Y == ButtonState.Released);
        aButtonDown = !(lastState.Buttons.A == ButtonState.Pressed && currentState.Buttons.A == ButtonState.Released);
        startButtonDown = !(lastState.Buttons.Start == ButtonState.Pressed && currentState.Buttons.Start == ButtonState.Released);
        backButtonDown = !(lastState.Buttons.Back == ButtonState.Pressed && currentState.Buttons.Back == ButtonState.Released);
        leftstickDown = !(lastState.Buttons.LeftStick == ButtonState.Pressed && currentState.Buttons.LeftStick == ButtonState.Released);
        rightStickDown = !(lastState.Buttons.RightStick == ButtonState.Pressed && currentState.Buttons.RightStick == ButtonState.Released);
    }

    public void SetVib(float leftMotor, float rightMotor = -2) {
        if(rightMotor >= 0)
            GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        else
            GamePad.SetVibration(playerIndex, leftMotor, leftMotor);
    }

    public void BurstVib(float time, float leftMotor, float rightMotor = -2) {
        if (rightMotor >= 0)
            GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        else
            GamePad.SetVibration(playerIndex, leftMotor, leftMotor);

        StartCoroutine(resetVib(time));
    }

    IEnumerator resetVib(float time) {
        yield return new WaitForSeconds(time);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
