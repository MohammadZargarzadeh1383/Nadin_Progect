using Microsoft.AspNetCore.Builder;
using Nadin_Soft_Api_Project.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nadin_Soft_Api_Project.Domain.Entities.Comment;

public class Comment : BaseEntity
{
    public int UserRef { get; set; }
    [ForeignKey("UserRef")]
    public User.User User { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}
