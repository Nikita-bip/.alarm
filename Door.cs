using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool IsTriggered = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsTriggered = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTriggered = false;
    }
}
