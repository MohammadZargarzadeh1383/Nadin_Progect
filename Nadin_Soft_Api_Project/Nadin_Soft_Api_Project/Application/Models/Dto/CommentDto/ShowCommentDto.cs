namespace Nadin_Soft_Api_Project.Application.Models.Dto.CommentDto
{
    public class ShowCommentDto
    {
        public int Id { get; set; }

        public int UserRef { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
