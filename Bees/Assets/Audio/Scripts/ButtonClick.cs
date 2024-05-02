using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
   public AudioSource OptionSelectedSound;

   public void PlaySelectSound()
    {
        OptionSelectedSound.Play();
    }

}
