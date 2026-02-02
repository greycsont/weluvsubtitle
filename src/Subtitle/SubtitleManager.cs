using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using weluvsubtitle.Subtitle.MonoBehaviorClasses;
using weluvsubtitle.Util;

namespace weluvsubtitle.Subtitle;

public static class SubtitleManager
{
    private static Canvas _canvas;
    private static GameObject _container;
    
    // 缓存：Key 是文本内容，Value 是对应的脚本组件
    private static readonly Dictionary<string, SubtitleBox> ActiveSubtitles = new();

    private static Canvas Canvas => _canvas ??= UnityPathHelper.FindCanvas();

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
        // 1. 检查是否已经存在相同的字幕
        if (ActiveSubtitles.TryGetValue(text, out var existingBox))
        {
            if (existingBox != null)
            {
                // 刷新现有的字幕（比如重置它的生命周期/计时器）
                existingBox.fadeUI.Refresh(); 
                return;
            }
        }

        // 2. 创建新字幕
        var subtitleObject = new GameObject("SubtitleItem");
        subtitleObject.transform.SetParent(Container.transform, false);
        subtitleObject.transform.SetAsLastSibling();

        var box = subtitleObject.AddComponent<SubtitleBox>();
        box.Initialize(text, () => OnSubtitleDestroyed(text));
        // 3. 记录到字典
        ActiveSubtitles.Add(text, box);
    }

    // 当 SubtitleBox 消失时调用，确保字典干净
    private static void OnSubtitleDestroyed(string text)
        => ActiveSubtitles.Remove(text);
    
    private static void SetupContainer(GameObject container)
    {
        var rect = container.GetComponent<RectTransform>() ?? container.AddComponent<RectTransform>();

        // 锚点和中心点都在右下角
        rect.anchorMin = new Vector2(1f, 0f);
        rect.anchorMax = new Vector2(1f, 0f);
        rect.pivot = new Vector2(1f, 0f);
        rect.anchoredPosition = new Vector2(-20, 20);
        
        // 宽度决定了字幕的最大伸展范围
        rect.sizeDelta = new Vector2(600, 0);

        // 垂直布局：控制子物体堆叠
        var layout = container.AddComponent<VerticalLayoutGroup>();
        layout.childAlignment = TextAnchor.LowerRight; // 靠右下对齐
        layout.childControlHeight = true;  // 必须勾选，由容器控制子物体高度
        layout.childControlWidth = false;  // 不强制宽度，让 SubtitleBox 自适应
        layout.childForceExpandHeight = false;
        layout.childForceExpandWidth = false;
        layout.spacing = 0; // 字幕条之间的间距

        // 自动增长高度：容器高度随子物体数量变化
        var fitter = container.AddComponent<ContentSizeFitter>();
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
    }
}