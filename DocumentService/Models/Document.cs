﻿using System.ComponentModel.DataAnnotations;

namespace DocumentService.Models;

public class Document
{
    [Key]
    public int Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] FileContent { get; set; }
}
