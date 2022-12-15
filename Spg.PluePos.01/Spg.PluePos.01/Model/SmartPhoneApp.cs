using System.Collections.Generic;

namespace Spg.PluePos._01.Model
{
    public class SmartPhoneApp : List<Post>
    {
        public string SmartPhoneId { get; set; } = string.Empty;

        public SmartPhoneApp(string smartPhoneId)
        {
            SmartPhoneId = smartPhoneId;
        }

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

        public string ProcessPosts()
        {
            string result = string.Empty;
            foreach (var postItem in this)
            {
                result = string.Concat(result, postItem.Html);
                //result += postItem.Html;
            }
            return result;
        }

        public int CalcRating()
        {
            int sum = 0;
            foreach (Post item in this)
            {
                sum += item.Rating;
            }
            return sum;
        }

        public Post? this[string title] 
        {
            get
            {
                foreach (Post post in this)
                {
                    if (post.Title == title)
                    {
                        return post;
                    }
                }
                return null;
            }
        }

    }
}