using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    //private Animator _animator;
    private CanvasGroup _canvasGroup;
    private bool isOpen;

    public bool IsOpen
    {
        get { return this.isOpen; }
        set { this.isOpen = value; }
    }

    public void Awake()
    {
        //_animator = GetComponent<Animator>();
        _canvasGroup = GetComponent<CanvasGroup>();

        //var rect = GetComponent<RectTransform>();
        //rect.offsetMax = rect.offsetMin = new Vector2(0, 0);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isOpen)
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
        }
        else
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
        }
	}
}
