﻿using System.Text.Json.Serialization;
using ExtraIsland.Shared;

namespace ExtraIsland.Components;

// ReSharper disable once ClassNeverInstantiated.Global
public class RhesisConfig {
    public RhesisDataSource DataSource { get; set; } = RhesisDataSource.All;
    
    public string HitokotoProp  { get; set; } = string.Empty;
    
    public DateTime LastUpdate { get; set; } = DateTime.Today;

    public int LengthLimitation { get; set; }
    
    [JsonIgnore]
    public string HitokotoLengthArgs {
        get {
            return LengthLimitation switch {
                0 => string.Empty,
                _ => $"max_length={LengthLimitation}&"
            };
        }
    }

    public TimeSpan UpdateTimeGap { get; set; } = TimeSpan.FromSeconds(30);

    [JsonIgnore]
    public double UpdateTimeGapSeconds {
        get => UpdateTimeGap.TotalSeconds;
        set => UpdateTimeGap = TimeSpan.FromSeconds(value);
    }
    
    public string SainticProp  { get; set; } = string.Empty;
}