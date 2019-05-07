using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SoundsPlayer : MonoBehaviour
{
    [Header("Clips Audio")]
    [Space]
    public AudioClip jump;
    public AudioClip takePiece;
    public AudioClip lossPiece;
    public AudioClip goodInspiration;
    public AudioClip badInspiration;
    public List<AudioClip> footSteps = new List<AudioClip>();

    [Header("Audio Sources")]
    [Space]
    public AudioSource AudoiSource_jump;
    public AudioSource AudioSource_takePiece;
    public AudioSource AudioSource_lossPiece;
    public AudioSource AudioSource_goodInspiration;
    public AudioSource AudioSource_badInspiration;
    public AudioSource AudioSource_footSteps;
    //public AudioSource AudioSource_;

    private bool canPlayGoodInspiration = false;


    public void PLayOneShotJump()
    {
        if (!AudoiSource_jump.isPlaying)
        {
            AudoiSource_jump.PlayOneShot(jump);
            AudioSource_footSteps.Stop();
            //Debug.Log("Jump");
        }
    }

    public void PLayOneShotTakePiece()
    {
        AudioSource_takePiece.PlayOneShot(takePiece);
    }

    public void PlayOneShotLossPiece()
    {
        AudioSource_lossPiece.PlayOneShot(lossPiece);
    }

    public void PlayOneShotGoodInspiration()
    {
        if (!AudioSource_goodInspiration.isPlaying && canPlayGoodInspiration)
        {
            AudioSource_goodInspiration.PlayOneShot(goodInspiration);
            canPlayGoodInspiration = false;
        }
    }

    public void PLayOneShotBadInspiration()
    {
        if (!AudioSource_badInspiration.isPlaying)
        {
            AudioSource_badInspiration.PlayOneShot(badInspiration);
        }
    }

    public void PlayFootStep()
    {
        if(!AudioSource_footSteps.isPlaying)
        {
            AudioSource_footSteps.PlayOneShot(NextFootStepSound());
        }
    }

    public void StopFootStep()
    {
        AudioSource_footSteps.Stop();
    }

    private AudioClip NextFootStepSound()
    {
        int numSound = Aleatoire.AleatoireBetween(1, footSteps.Count - 1); //On selectionne un index aleatoire (sauf le premier élèment)
        AudioClip tempSound = footSteps[numSound]; //On stock le clip audio
        footSteps.RemoveAt(numSound); //On l'efface de la list
        footSteps.Insert(0, tempSound); //on l'insert au debut pour ne pas le réutiliser la prochaine fois
        return footSteps[0];
    }

    public bool CanPlayGoodInspiration { get => canPlayGoodInspiration; set => canPlayGoodInspiration = value; }
}
