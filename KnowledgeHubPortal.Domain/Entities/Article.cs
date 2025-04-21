﻿namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ArticleUrl { get; set; }
        public int CatagoryId { get; set; }
        public Catagory? Catagory { get; set; }
        public bool IsApproved { get; set; }
        public string? SubmitedBy { get; set; }
        public DateTime DateSubmited { get; set; }
    }
}
