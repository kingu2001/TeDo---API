﻿namespace SignDocumentService.Models
{
    public class SignedDocument : Document
    {
        public string TestType { get; set; }
        public List<Punch>? Punches { get; set; }
        public List<Revision>? Revisions { get; set; }
        public List<Stamp> Stamps { get; set; } 

    }
}