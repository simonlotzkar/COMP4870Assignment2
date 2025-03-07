using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Library;

public class Article
{
    [Key]
    public int ArticleId { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public DateTime CreateDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Email { get; set; }
}