using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    private bool _isDestroying;
    private int _timeToDestroy;
    public int timeToDestroy;

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
        if (!_isDestroying) return;
        //var color = (timeToDestroy - _timeToDestroy) * 255 / timeToDestroy;
        //gameObject.GetComponent<Renderer>().material.color = new Color(color, color, color);
        if (_timeToDestroy <= 0)
        {
            gameObject.SetActive(false);
        }
        
        _timeToDestroy--;
    }
}
