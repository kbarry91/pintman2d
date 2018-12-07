using UnityEngine;

// DestroyFinishedParticle destroys unused objects to conserve memory.
public class DestroyFinishedParticle : MonoBehaviour
{
    private ParticleSystem thisParticleSystem;

    // Use this for initialization
    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisParticleSystem.isPlaying)
        {
            return;
        }
        // Destroy the game object.
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
