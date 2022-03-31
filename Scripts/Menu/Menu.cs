
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.color = Color.white;
    }
    void OnMouseEnter()
    {
        text.color = Color.blue;
    }

    void OnMouseExit()
    {
        text.color = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        this.OnMouseEnter();
        this.OnMouseExit();
    }
}

