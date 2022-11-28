using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01.Model
{
    public abstract class Post
    {
        public string Title { get; }
        public DateTime Created { get; }

        private int _rating;
        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("Range muss zwischen 1 und 5liegen!");
                }
                _rating = value;
            }
        }

        public abstract string Html { get; }
        public SmartPhoneApp SmartPhone { get; set; } = default!;

        public Post(string title, DateTime created)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Titel war NULL!");
            }
            else
            {
                Title = title;
            }
            Created = created;
        }

        public Post(string title) : this(title, DateTime.Now)
        { }

        public override string ToString()
        {
            return Html;
        }
    }
}
