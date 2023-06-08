using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    public float timeToDestroy;
    private bool _isDestroying;
    private float _timeToDestroy;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    
    public void OnHoverEnter()
    {
        _timeToDestroy = timeToDestroy;
        _isDestroying = true;
    }
    
    public void OnHoverExit()
    {
        _isDestroying = false;
    }

    private void Update()
    {
        if (!_isDestroying)
        {
            _renderer.material.color = Color.grey;
            return;
        }
        if (_timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
        var t = (timeToDestroy - _timeToDestroy) / timeToDestroy;
        _renderer.material.color = Color.Lerp(Color.grey, Color.red, t);
        _timeToDestroy--;
    }
}
