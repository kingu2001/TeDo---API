﻿using System.Text.Json.Serialization;

namespace SignDocumentService.Models
{
    public class Stamp
    {
        public int Id { get; set; }
        public byte[] Signature { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public string SigneeName { get; set; }
        public int StampIdentity { get; set; }
        public string? TestType { get; set; }
        public int SignedDocumentId { get; set; }
    }
}