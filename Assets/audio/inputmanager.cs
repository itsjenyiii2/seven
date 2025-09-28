using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class inputmanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioManager.Instance.Play(AudioManager.SoundType.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.Instance.Play(AudioManager.SoundType.Walk);
        }
    }


    
}
