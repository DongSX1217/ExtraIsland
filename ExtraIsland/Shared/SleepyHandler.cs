﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using ClassIsland.Core.Controls.CommonDialog;

namespace ExtraIsland.Shared;

public static class SleepyHandler {
    public class SleepyApiData {
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("info")]
        public SleepyInfo Info { get; set; } = new SleepyInfo();
        [JsonPropertyName("device")]
        public Dictionary<string,SleepyDevice> Devices { get; set; } = new Dictionary<string,SleepyDevice>();
        [JsonPropertyName("device_status_slice")]
        public int DeviceStatusSlice { get; set; }
        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; } = string.Empty;
        [JsonPropertyName("refresh")]
        public int Refresh { get; set; }

        public static SleepyApiData Fetch(string url) {
            try {
                return new HttpClient()
                    .GetFromJsonAsync<SleepyApiData>(url)
                    .Result!;
            }
            catch {
                return new SleepyApiData {
                    Info = new SleepyInfo {
                        Name = "获取时发生错误"
                    }
                };
            }
        }

        public class SleepyInfo {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;
            [JsonPropertyName("desc")]
            public string Description { get; set; } = string.Empty;
            [JsonPropertyName("color")]
            public string Color { get; set; } = string.Empty;
        }

        public class SleepyDevice {
            [JsonPropertyName("show_name")]
            public string ShowName { get; set; } = string.Empty;
            [JsonPropertyName("using")]
            public bool Using { get; set; }
            [JsonPropertyName("app_name")]
            public string AppName { get; set; } = string.Empty;
        }
    }
}