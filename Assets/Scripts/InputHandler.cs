using UnityEngine;

public class InputHandler
{
    public static bool CheckAnyInput()
    {
        return (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(1));
    }
}