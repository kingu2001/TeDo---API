﻿using System.Text.Json.Serialization;

namespace ConverterService;

public class Document
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? ContentType { get; set; } 
    public byte[]? FileContent { get; set; }
}
