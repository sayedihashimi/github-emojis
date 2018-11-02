using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GithubEmojis.Pages {
    public class IndexModel : PageModel {
        private IGithubEmojiService _emojiService;

        public IndexModel(IGithubEmojiService emojiService) {
            _emojiService = emojiService;
        }

        const string GithubEmojiUrl = "https://api.github.com/emojis";

        public IList<Emoji> Emojis {
            get;
            set;
        }

        public void OnGet() {
            string filepath = "/Users/sayedhashimi/temp/emojis.json";
            var text = System.IO.File.ReadAllText(filepath);
            Emojis = _emojiService.GetEmojisFrom(text);
        }
    }
}
