using UnityEngine;

public class EffectView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void Play(Vector3 position)
    {
        if (_effect == null)
            return;

        ParticleSystem effect = Instantiate(_effect, position, Quaternion.identity);

        effect.Play();

        Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
    }
}
