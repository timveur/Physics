using System;
using System.Collections.Generic;

namespace Physics.Models
{

    public partial class Chapter
    {
        public int IdChapter { get; set; }

        public int ParentId { get; set; }

        public string TitleChapter { get; set; } = null;

        public string NameFile { get; set; }

        public string FullParagraphPath 
        { get 
            { return "../Assets/" + NameFile; }
        }
        
    }
}