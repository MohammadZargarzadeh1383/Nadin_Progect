namespace Nadin_Soft_Api_Project.Application.Models.Dto.CommentDto
{
    public class CreateCommentDto
    {
        public int UserRef { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
