﻿namespace PunchService;

public class Document
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] FileContent { get; set; }
    public List<Punch> PunchList { get; set; }
}
