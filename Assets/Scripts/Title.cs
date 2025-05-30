using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] SpriteRenderer _logo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _logo = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogoDisp(bool isvisible)
    {
        _logo.enabled = isvisible;

    }


}
