using UnityEngine;
using System.Collections;

public class FireFlicker : MonoBehaviour
{
    public float MinMax = 10f;
    public float RateDamping = 0.05f;
    public float Speed = 1f;
    public bool StopFlickering;

    private Light _lightSource;
    private float _baseIntensity;
    private bool _flickering;
    private float _randomSeed;

    public void Start()
    {
        _lightSource = GetComponent<Light>();
        _baseIntensity = _lightSource.intensity;
        _randomSeed = Random.Range(2.3f, 2.7f);
        StartCoroutine(DoFlicker());
    }

    private IEnumerator DoFlicker()
    {
        while (true)
        {
            //_lightSource.intensity = Mathf.Lerp(_lightSource.intensity, Random.Range(_baseIntensity - MinMax, _baseIntensity + MinMax), Strength * Time.deltaTime);

            _lightSource.intensity = _baseIntensity + ((Mathf.Sin(Time.time * Speed) * Mathf.Sin(Time.time * Speed * _randomSeed)) * MinMax);
            //_lightSource.intensity = _baseIntensity + (Mathf.PerlinNoise(0, Time.time * Speed) * MinMax);

            yield return new WaitForSeconds(RateDamping);
        }
    }
}