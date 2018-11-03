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
        
        public IList<Emoji> Emojis {
            get;
            set;
        }

        public async Task OnGet() {
            Emojis = await _emojiService.GetEmojis();
        }
    }
}
