using UnityEngine;
/// <summary>
/// DestroyFinishedParticle destroys objects to conserve memory
/// </summary>
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
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
