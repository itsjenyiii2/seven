using UnityEngine;

public class interactive : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public interface IInteractable
{
void Interact();
bool CanInteract();
}
}
