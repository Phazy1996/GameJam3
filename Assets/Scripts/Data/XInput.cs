using UnityEngine;
using System.Collections;
using XInputDotNetPure;
#pragma warning disable 0414
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
    bool leftStickDown, rightStickDown = false;
    bool leftShoulderDown, rightShoulderDown = false;
    bool dPadLeftDown, dPadRightDown, dPadUpDown, dPadDownDown = false;

    public bool XButtonDown { get { return xButtonDown; } }
    public bool BButtonDown { get { return bButtonDown; } }
    public bool YButtonDown { get { return yButtonDown; } }
    public bool AButtonDown { get { return aButtonDown; } }

    public bool StartButtonDown { get { return startButtonDown; } }
    public bool BackButtonDown { get { return backButtonDown; } }

    public bool LeftStickDown { get { return leftStickDown; } }
    public bool RightStickDown { get { return rightStickDown; } }

    public bool LeftShoulderDown { get { return leftShoulderDown; } }
    public bool RightShoulderDown { get { return rightShoulderDown; } }

    public bool DPadLeftDown { get { return dPadLeftDown; } }
    public bool DPadRightDown { get { return dPadRightDown; } }
    public bool DPadUpDown { get { return dPadUpDown; } }
    public bool DPadDownDown { get { return dPadDownDown; } }

    // True when button is down.
    bool xButton, bButton, yButton, aButton = false;
    bool startButton, backButton = false;
    bool leftStick, rightStick = false;
    bool leftShoulder, rightShoulder = false;
    bool dPadLeft, dPadRight, dPadUp, dPadDown = false;

    public bool XButton { get { return xButton; } }
    public bool BButton { get { return bButton; } }
    public bool YButton { get { return yButton; } }
    public bool AButton { get { return aButton; } }

    public bool StartButton { get { return startButton; } }
    public bool BackButton { get { return backButton; } }

    public bool LeftStick { get { return leftStick; } }
    public bool RightStick { get { return rightStick; } }

    public bool LeftShoulder { get { return leftShoulder; } }
    public bool RightShoulder { get { return rightShoulder; } }

    public bool DPadLeft { get { return dPadRight; } }
    public bool DPadRight { get { return dPadRight; } }
    public bool DPadUp { get { return dPadUp; } }
    public bool DPadDown { get { return dPadDown; } }

    // Their horizontal and vertical.
    // Value between -1 and 1.
    Vector2 leftStickPos, rightStickPos;
    float leftShoulderPos, rightShoulderPos;

    public Vector2 LeftStickPos { get { return leftStickPos; } }
    public Vector2 RightStickPos { get { return rightStickPos; } }

    public float LeftShoulderPos { get { return leftShoulderPos; } }
    public float RightShoulderPos { get { return RightShoulderPos; } }

    private float leftMotorVibration = 0;
    private float rightMotorVibration = 0;

    public float LeftMotorVibration {
        set {
            SetVib(value, rightMotorVibration);
            leftMotorVibration = value;
        }
    }

    public float RightMotorVibration {
        set {
            SetVib(leftMotorVibration, value);
            rightMotorVibration = value;
        }
    }

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
                gameObject.name = "!!!--" + gameObject.name + "--!!!"; // Can never be too careful.
                gameObject.SetActive(false);
                break;
        }

        currentState = GamePad.GetState(playerIndex);

        SetVib(0);
    }

    void OnApplicationQuit() {
        SetVib(0);
    }

    void Update() {
        lastState = currentState;
        currentState = GamePad.GetState(playerIndex);

        ButtonReleaseFrame();
        ButtonPressFrame();

        ButtonPress();

        Positions();
    }

    void ButtonPressFrame() { // Buttons pressed this frame.
        xButtonDown = lastState.Buttons.X == ButtonState.Released && currentState.Buttons.X == ButtonState.Pressed;
        bButtonDown = lastState.Buttons.B == ButtonState.Released && currentState.Buttons.B == ButtonState.Pressed;
        yButtonDown = lastState.Buttons.Y == ButtonState.Released && currentState.Buttons.Y == ButtonState.Pressed;
        aButtonDown = lastState.Buttons.A == ButtonState.Released && currentState.Buttons.A == ButtonState.Pressed;
        startButtonDown = lastState.Buttons.Start == ButtonState.Released && currentState.Buttons.Start == ButtonState.Pressed;
        backButtonDown = lastState.Buttons.Back == ButtonState.Released && currentState.Buttons.Back == ButtonState.Pressed;
        leftStickDown = lastState.Buttons.LeftStick == ButtonState.Released && currentState.Buttons.LeftStick == ButtonState.Pressed;
        rightShoulderDown = lastState.Buttons.RightShoulder == ButtonState.Released && currentState.Buttons.RightShoulder == ButtonState.Pressed;
        leftShoulderDown = lastState.Buttons.LeftShoulder == ButtonState.Released && currentState.Buttons.LeftShoulder == ButtonState.Pressed;

        dPadLeftDown = lastState.DPad.Left == ButtonState.Released && currentState.DPad.Left == ButtonState.Pressed;
        dPadRightDown = lastState.DPad.Right == ButtonState.Released && currentState.DPad.Right == ButtonState.Pressed;
        dPadUpDown = lastState.DPad.Up == ButtonState.Released && currentState.DPad.Up == ButtonState.Pressed;
        dPadDownDown = lastState.DPad.Down == ButtonState.Released && currentState.DPad.Down == ButtonState.Pressed;
    }

    void ButtonReleaseFrame() { // Buttons released this frame.
        xButtonDown = !(lastState.Buttons.X == ButtonState.Pressed && currentState.Buttons.X == ButtonState.Pressed);
        bButtonDown = !(lastState.Buttons.B == ButtonState.Pressed && currentState.Buttons.B == ButtonState.Pressed);
        yButtonDown = !(lastState.Buttons.Y == ButtonState.Pressed && currentState.Buttons.Y == ButtonState.Pressed);
        aButtonDown = !(lastState.Buttons.A == ButtonState.Pressed && currentState.Buttons.A == ButtonState.Pressed);
        startButtonDown = !(lastState.Buttons.Start == ButtonState.Pressed && currentState.Buttons.Start == ButtonState.Pressed);
        backButtonDown = !(lastState.Buttons.Back == ButtonState.Pressed && currentState.Buttons.Back == ButtonState.Pressed);
        leftStickDown = !(lastState.Buttons.LeftStick == ButtonState.Pressed && currentState.Buttons.LeftStick == ButtonState.Pressed);
        rightStickDown = !(lastState.Buttons.RightStick == ButtonState.Pressed && currentState.Buttons.RightStick == ButtonState.Pressed);
        rightShoulderDown = !(lastState.Buttons.RightShoulder == ButtonState.Pressed && currentState.Buttons.RightShoulder == ButtonState.Pressed);
        leftShoulderDown = !(lastState.Buttons.LeftShoulder == ButtonState.Pressed && currentState.Buttons.LeftShoulder == ButtonState.Pressed);

        dPadLeftDown = !(lastState.DPad.Left == ButtonState.Pressed && currentState.DPad.Left == ButtonState.Pressed);
        dPadRightDown = !(lastState.DPad.Right == ButtonState.Pressed && currentState.DPad.Right == ButtonState.Pressed);
        dPadUpDown = !(lastState.DPad.Up == ButtonState.Pressed && currentState.DPad.Up == ButtonState.Pressed);
        dPadDownDown = !(lastState.DPad.Down == ButtonState.Pressed && currentState.DPad.Down == ButtonState.Pressed);
    }

    void ButtonPress() {
        xButton = currentState.Buttons.X == ButtonState.Pressed;
        bButton = currentState.Buttons.B == ButtonState.Pressed;
        yButton = currentState.Buttons.Y == ButtonState.Pressed;
        aButton = currentState.Buttons.A == ButtonState.Pressed;
        startButton = currentState.Buttons.Start == ButtonState.Pressed;
        backButton = currentState.Buttons.Back == ButtonState.Pressed;
        leftStick = currentState.Buttons.LeftStick == ButtonState.Pressed;
        rightStick = currentState.Buttons.RightStick == ButtonState.Pressed;
        rightShoulder = currentState.Buttons.RightShoulder == ButtonState.Pressed;
        leftShoulder = currentState.Buttons.LeftShoulder == ButtonState.Pressed;

        dPadLeft = currentState.DPad.Left == ButtonState.Pressed;
        dPadRight = currentState.DPad.Right == ButtonState.Pressed;
        dPadUp = currentState.DPad.Up == ButtonState.Pressed;
        dPadDown = currentState.DPad.Down == ButtonState.Pressed;
    }

    void Positions() {
        // Just some shortcuts.
        GamePadThumbSticks currentTS = currentState.ThumbSticks;
        GamePadTriggers currentT = currentState.Triggers;

        leftStickPos.x = currentTS.Left.X; leftStickPos.y = currentTS.Left.Y;
        rightStickPos.x = currentTS.Right.X; rightStickPos.y = currentTS.Right.Y;

        leftShoulderPos = currentT.Left;
        rightShoulderPos = currentT.Right;
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
#pragma warning restore 0414