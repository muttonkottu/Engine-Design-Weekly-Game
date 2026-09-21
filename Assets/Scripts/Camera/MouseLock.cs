using UnityEngine;

public class MouseLock : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Unlock()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Lock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
