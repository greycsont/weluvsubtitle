using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using weluvsubtitle.Subtitle.MonoBehaviorClasses;
using weluvsubtitle.Util;

namespace weluvsubtitle.Subtitle;

public static class SubtitleDisplay
{
    private static Canvas _canvas;
    private static GameObject _container;

    private static readonly Dictionary<string, SubtitleBox> ActiveSubtitles = new();

    private static Canvas Canvas
    {
        get
        {
            if (_canvas == null)
                _canvas = UnityPathHelper.FindCanvas();
            return _canvas;
        }
    }

    private static GameObject Container
    {
        get
        {
            if (_container == null)
            {
                _container = new GameObject("SubtitleContainer");
                _container.transform.SetParent(Canvas.transform, false);
                SetupContainer(_container);
            }
            return _container;
        }
    }

    public static void ShowSubtitle(string text)
    {
        if (ActiveSubtitles.TryGetValue(text, out var existingBox))
        {
            existingBox.fadeUI.Refresh();
            return;
        }

        var subtitleObject = new GameObject("SubtitleItem");
        subtitleObject.transform.SetParent(Container.transform, false);
        subtitleObject.transform.SetAsLastSibling();

        var box = subtitleObject.AddComponent<SubtitleBox>();
        box.Initialize(text, () => OnSubtitleDestroyed(text));

        ActiveSubtitles.Add(text, box);
    }

    private static void OnSubtitleDestroyed(string text)
        => ActiveSubtitles.Remove(text);

    private static void SetupContainer(GameObject container)
    {
        var rect = container.GetComponent<RectTransform>() ?? container.AddComponent<RectTransform>();

        rect.anchorMin = new Vector2(1f, 0f);
        rect.anchorMax = new Vector2(1f, 0f);
        rect.pivot = new Vector2(1f, 0f);
        rect.anchoredPosition = new Vector2(-20, 20);
        rect.sizeDelta = new Vector2(600, 0);

        var layout = container.AddComponent<VerticalLayoutGroup>();
        layout.childAlignment = TextAnchor.LowerRight;
        layout.childControlHeight = true;
        layout.childControlWidth = false;
        layout.childForceExpandHeight = false;
        layout.childForceExpandWidth = false;
        layout.spacing = 0;

        var fitter = container.AddComponent<ContentSizeFitter>();
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
    }
}