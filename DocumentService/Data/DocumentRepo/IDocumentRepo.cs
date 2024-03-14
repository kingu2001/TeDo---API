﻿using DocumentService.Models;

namespace DocumentService.Data
{
    public interface IDocumentRepo
    {
        bool SaveChanges();
        Task<IEnumerable<Document>> GetAllDocuments();
        Document GetDocumentById(int id);
        void UploadDocumentToDb(Document document);

    }
}


