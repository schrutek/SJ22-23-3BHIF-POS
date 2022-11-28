using System.Collections.Generic;

namespace Spg.PluePos._01.Model
{
    public class SmartPhoneApp : List<Post>
    {
        public string SmartPhoneId { get; set; } = string.Empty;

        public new void Add(Post post)
        {
            if (post is null)
            {
                return;
            }
            else
            {
                post.SmartPhone = this;
                base.Add(post);
            }
        }
    }
}