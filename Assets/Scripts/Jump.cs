using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public ParticleSystem jumpEffect;

    void playParticleEffects()
    {
        jumpEffect.Play();
        Debug.Log("Particle");
        StartCoroutine(playParticle());
    }

    IEnumerator playParticle()
    {
        yield return new WaitForSeconds(1);
        jumpEffect.Stop();
    }
}
