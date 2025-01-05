﻿using System.ComponentModel;

namespace ExtraIsland.Components;

// ReSharper disable once ClassNeverInstantiated.Global
public class BetterCountdownConfig {
    public string TargetDate { get; set; } = DateTime.Now.ToString("s");
    public string Prefix { get; set; } = "现在";
    public string Suffix { get; set; } = "过去了";
    public bool IsSystemTime { get; set; }
    public bool IsCorrectorEnabled { get; set; } = true;
    public CountdownSeparatorConfigs Separators { get; set; } = new CountdownSeparatorConfigs();

    bool _isNoGapDisplay;
    public bool IsNoGapDisplay {
        get => _isNoGapDisplay;
        set {
            if (_isNoGapDisplay == value) return;
            _isNoGapDisplay = value;
            OnNoGapDisplayChanged?.Invoke();
        }
    }
    public event Action? OnNoGapDisplayChanged;
    
    CountdownAccuracy _accuracy = CountdownAccuracy.Minute;
    public CountdownAccuracy Accuracy {
        get => _accuracy;
        set {
            if (_accuracy == value) return;
            _accuracy = value;
            OnAccuracyChanged?.Invoke();
        }
    }
    public event Action? OnAccuracyChanged;
}

public class CountdownSeparatorConfigs {
    public string Day { get; set; } = "天";
    public string Hour { get; set; } = "时";
    public string Minute { get; set; } = "分";
    public string Second { get; set; } = "秒";
}

public enum CountdownAccuracy {
    [Description("天")]
    Day,
    [Description("时")]
    Hour,
    [Description("分")]
    Minute,
    [Description("秒")]
    Second
}