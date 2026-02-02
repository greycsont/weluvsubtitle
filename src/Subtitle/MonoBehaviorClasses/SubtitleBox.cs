using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace weluvsubtitle.Subtitle.MonoBehaviorClasses;

public class SubtitleBox : MonoBehaviour
{
    private TextMeshProUGUI _textComponent;
    
    private RectTransform _rectTransform;
    
    private Action _onDispose;
    
    public FadeUI fadeUI;
    

    void Awake()
    { 
        _rectTransform = GetComponent<RectTransform>() ?? gameObject.AddComponent<RectTransform>();
        
        _rectTransform.pivot = new Vector2(1f, 0f);
        
        SetupAutoResizingLayout();

        CreateTextChild();
        
        this.fadeUI = gameObject.AddComponent<FadeUI>();
    }
    

    private void SetupAutoResizingLayout()
    {
        var bg = gameObject.GetComponent<Image>() ?? gameObject.AddComponent<Image>();
        bg.color = new Color(0, 0, 0, 1f);

        var layout = gameObject.GetComponent<HorizontalLayoutGroup>() ?? gameObject.AddComponent<HorizontalLayoutGroup>();
        layout.childAlignment = TextAnchor.MiddleCenter;
        layout.padding = new RectOffset(10, 10, 5, 5);
        layout.childControlWidth = true;  
        layout.childControlHeight = true; 
        layout.childForceExpandWidth = true;
        layout.childForceExpandHeight = true;

        var fitter = gameObject.GetComponent<ContentSizeFitter>() ?? gameObject.AddComponent<ContentSizeFitter>();
        fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
    }

    private void CreateTextChild()
    {
        Transform existingText = transform.Find("TextContent");
        // 有这个东西是因为Image和TextMeshProUGUI不能放到同一GameObject下
        GameObject textObj = existingText ? existingText.gameObject : new GameObject("TextContent");
        
        textObj.transform.SetParent(this.transform, false);

        _textComponent = textObj.GetComponent<TextMeshProUGUI>() ?? textObj.AddComponent<TextMeshProUGUI>();
        _textComponent.fontSize = 18;
        _textComponent.color = Color.white;
        _textComponent.alignment = TextAlignmentOptions.Center;
        _textComponent.enableWordWrapping = false;
        _textComponent.overflowMode = TextOverflowModes.Overflow;

        if (TMP_Settings.defaultFontAsset != null)
            _textComponent.font = TMP_Settings.defaultFontAsset;
    }
    
    public void Initialize(string content, Action onDispose)
    {
        this._textComponent.text = content;
        this._onDispose =  onDispose;
    }
    
    private void OnDestroy()
        => _onDispose?.Invoke();
        
}